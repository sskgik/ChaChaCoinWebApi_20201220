using Miyabi;
using Miyabi.ClientSdk;
using Miyabi.Common.Models;
using Miyabi.Contract.Client;
using Miyabi.Contract.Models;
using Miyabi.Asset.Models;
using Miyabi.Cryptography;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Diagnostics;

namespace WalletService
{
    public class ContractService
    {
        private static string ApiUrl = "https://playground.blockchain.bitflyer.com/";
        const string ContractName = "Miyabi.Tests.SCs.ChaChaVote"; 
        const string InstanceName = "SmartContract";
        const string Filename = "sc\\voteChaCha.cs";

        static readonly ByteString s_AssemblyId =
            ContractUtils.GetAssemblyId(new[] { File.ReadAllText(Filename) });

        /// <summary>
        /// Participate Event (イベントの参加登録):一般側のメソッド
        /// </summary>
        /// <param name="Participantkeypair"></param>
        /// <param name="EventName"></param>
        /// <returns>txSigned.Id.ToString()</returns>
        /// <returns>result</returns>
        public async Task<Tuple<string,string>> InvokeContract_ParticipateEvent(KeyPair Participantkeypair,string EventName)
        {
            var client = this.SetClient();
            var generalApi = new GeneralApi(client);

            var participantAddress = new PublicKeyAddress(Participantkeypair.PublicKey);
            // Create gen entry
            var entry = new ContractInvoke(s_AssemblyId, ContractName, InstanceName, "ParticipateEvent", new[] { participantAddress.ToString() ,EventName});

            // Create signed transaction with builder. To invoke a smart contract,
            // contract owner's private key is required.
            var txSigned = TransactionCreator.CreateTransactionBuilder(
                new [] { entry },
                new []
                {
                    new SignatureCredential(Participantkeypair.PublicKey)
                })
                .Sign(Participantkeypair.PrivateKey)
                .Build();

            await generalApi.SendTransactionAsync(txSigned);

            var result = await WaitTx(generalApi, txSigned.Id);
            return new Tuple<string, string>(txSigned.Id.ToString(), result);
        }

        /// <summary>
        /// Regist_Issurance_Right (票の発行権の登録):イベント運営側用の話
        /// </summary>
        /// <param name="IssuanceRightKeypair"></param>
        /// <returns>txSigned.Id.ToString()</returns>
        /// <returns>result</returns>
        public async Task<Tuple<string,string>> InvokeContract_RegistIssuanceRight(KeyPair IssuanceRightKeypair)
        {
            var client = this.SetClient();
            var generalApi = new GeneralApi(client);
            var IssuanceRightAddress = new PublicKeyAddress(IssuanceRightKeypair);
            // Create gen entry
            var entry = new ContractInvoke(s_AssemblyId, ContractName, InstanceName, "RegistIssuanceRight", new[] { IssuanceRightAddress.ToString()});

            // Create signed transaction with builder. To invoke a smart contract,
            // contract owner's private key is required.
            var txSigned = TransactionCreator.CreateTransactionBuilder(
                new[] { entry },
                new[]
                {
                    new SignatureCredential(IssuanceRightKeypair.PublicKey)
                })
                .Sign(IssuanceRightKeypair.PrivateKey)
                .Build();

            await generalApi.SendTransactionAsync(txSigned);

            var result = await WaitTx(generalApi, txSigned.Id);
            return new Tuple<string, string>(txSigned.Id.ToString(), result);
        }

        /// <summary>
        /// Replenishment_votes (スマートコントラクトへの票の発行)
        /// </summary>
        /// <param name="IssuanceRequesterKeypair"></param>
        /// <param name="ReplenishmentVotesamount"></param>
        /// <returns>txSigned.Id.ToString()</returns>
        /// <returns>result</returns>
        public async Task<Tuple<string, string>> InvokeContract_ReplenishmentVotes(KeyPair IssuanceRequesterKeypair,string ReplenishmentVotesamount)
        {
            var client = this.SetClient();
            var generalApi = new GeneralApi(client);
            var RequestAddress = new PublicKeyAddress(IssuanceRequesterKeypair);
            // Create gen entry
            var entry = new ContractInvoke(s_AssemblyId, ContractName, InstanceName, "ReplenishmentVotes", new[] { RequestAddress.ToString(),ReplenishmentVotesamount });

            // Create signed transaction with builder. To invoke a smart contract,
            // contract owner's private key is required.
            var txSigned = TransactionCreator.CreateTransactionBuilder(
                new[] { entry },
                new[]
                {
                    new SignatureCredential(IssuanceRequesterKeypair.PublicKey)
                })
                .Sign(IssuanceRequesterKeypair.PrivateKey)
                .Build();

            await generalApi.SendTransactionAsync(txSigned);

            var result = await WaitTx(generalApi, txSigned.Id);
            return new Tuple<string, string>(txSigned.Id.ToString(), result);
        }

        /// <summary>
        ///  Distribute_votes (票の配布)
        /// </summary>
        /// <param name="TableName"></param>
        /// <param name="RequesterKeypair"></param>
        /// <param name="EventownerKeypair"></param>
        /// <param name="EventName"></param>
        /// <param name="EventName"></param>
        /// <returns>txSigned.Id.ToString()</returns>
        /// <returns>resultTx</returns>
        public async Task<Tuple<string, string>> InvokeContract_Distributevotes(string TableName, KeyPair RequesterKeypair,KeyPair EventownerKeypair,string EventName,decimal PaidCoinAmount)
        {
            var client = this.SetClient();
            var generalApi = new GeneralApi(client);
            var from = parsepublickey(RequesterKeypair);
            var to = parsepublickey(EventownerKeypair);
            var requesterAddress = from;
            //participant check
            var result =await Query_confirmparticipate("Confirmpaticipate", new[] { requesterAddress.ToString(),EventName});
            if(result == null)
            {
                return new Tuple<string, string>("", "error");
            }
            //Too many numbers value check 
            if (PaidCoinAmount % 100 != 0m)
            {
                return new Tuple<string, string>("", "error");
            }

            // Pay ChaChaCoin from participant
            var moveassetentry = new AssetMove(TableName,PaidCoinAmount,from,to);
            // Create contract entry (requesterAddress = from) 
            var vote = PaidCoinAmount / 100;
            string convertvote = Convert.ToString(vote);
            var contractentry = new ContractInvoke(s_AssemblyId, ContractName, InstanceName, "Distributevotes", new[] { requesterAddress.ToString(), EventName, convertvote });

            // Create signed transaction with builder. To invoke a smart contract,
            // contract owner's private key is required.
            var txSigned = TransactionCreator.CreateTransactionBuilder(
                new ITransactionEntry[] { moveassetentry,contractentry },
                new[]
                {
                    new SignatureCredential( RequesterKeypair.PublicKey)
                })
                .Sign(RequesterKeypair.PrivateKey)
                .Build();

            await generalApi.SendTransactionAsync(txSigned);

            var resultTx = await WaitTx(generalApi, txSigned.Id);
            return new Tuple<string, string>(txSigned.Id.ToString(), resultTx);
        }

        /// <summary>
        ///  regist vote target (投票対象の登録)
        /// </summary>
        /// <param name="votetargetAddress"></param>
        /// <returns></returns>
        public async Task<Tuple<string, string>> InvokeContract_Registvotetarget(KeyPair EventownerKeypair,string votetargetAddress, string Eventname)
        {
            var client = this.SetClient();
            var generalApi = new GeneralApi(client);

            // Create gen entry
            var entry = new ContractInvoke(s_AssemblyId, ContractName, InstanceName, "registvotetarget", new string[] { votetargetAddress, Eventname});

            // Create signed transaction with builder. To invoke a smart contract,
            // contract owner's private key is required.
            var txSigned = TransactionCreator.CreateTransactionBuilder(
                new[] { entry },
                new[]
                {
                    new SignatureCredential(EventownerKeypair.PublicKey)
                })
                .Sign(EventownerKeypair.PrivateKey)
                .Build();

            await generalApi.SendTransactionAsync(txSigned);

            var result = await WaitTx(generalApi, txSigned.Id);
            return new Tuple<string, string>(txSigned.Id.ToString(), result);
        }

        /// <summary>
        ///  regist vote target (投票)
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public async Task<Tuple<string, string>> InvokeContract_Vote(KeyPair VoterKeyPair ,string votetargetAddress, string Eventname, string votenumber)
        {
            var client = this.SetClient();
            var generalApi = new GeneralApi(client);
            var voterAddress = new PublicKeyAddress(VoterKeyPair);
            // Create gen entry
            var entry = new ContractInvoke(s_AssemblyId, ContractName, InstanceName, "vote", new string[] { voterAddress.ToString(),votetargetAddress, Eventname,votenumber });

            // Create signed transaction with builder. To invoke a smart contract,
            // contract owner's private key is required.
            var txSigned = TransactionCreator.CreateTransactionBuilder(
                new[] { entry },
                new[]
                {
                    new SignatureCredential(VoterKeyPair.PublicKey)
                })
                .Sign(VoterKeyPair.PrivateKey)
                .Build();

            await generalApi.SendTransactionAsync(txSigned);

            var result = await WaitTx(generalApi, txSigned.Id);
            return new Tuple<string, string>(txSigned.Id.ToString(), result);
        }

        /// <summary>
        /// 指定メソッドでブロックチェーン上のバイナリデータの取得
        /// </summary>
        /// <param name="method"></param>
        /// <param name="arguments"></param>
        /// <returns></returns>
        public async Task<string> Query_confirmparticipate( string method, string[] arguments)
        {
            // ContractClient has access to asset endpoints
            var client = this.SetClient();
            var contractClient = new ContractClient(client);

            var result = await contractClient.QueryContractAsync(s_AssemblyId, ContractName, InstanceName, method, arguments);
            return result.Value;
        }

        /// <summary>
        /// client set method.
        /// </summary>
        /// <returns>client</returns>
        public Client SetClient()
        {
            Client client;
            var config = new SdkConfig(ApiUrl);
            client = new Client(config);
            return client;
        }

        /// <summary>
        /// トランザションの結果判定
        /// </summary>
        /// <param name="api"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static async Task<string> WaitTx(GeneralApi api, ByteString id)
        {
            while (true)
            {
                var result = await api.GetTransactionResultAsync(id);
                if (result.Value.ResultCode != TransactionResultCode.Pending)
                {
                    return result.Value.ResultCode.ToString();
                }
            }
        }

        /// <summary>
        ///  プライベートキー文字列のParse
        /// </summary>
        /// <param name="privateKey">プライベートキーの文字列</param>
        /// <returns></returns>
        public KeyPair GetKeyPair(string privateKey)
        {
            PrivateKey adminPrivateKey;
            try
            {
                adminPrivateKey = PrivateKey.Parse(privateKey);
            }
            catch (Exception)
            {
                //失敗のHTTPリクエストを投げるようにする
                return null;
            }
            return new KeyPair(adminPrivateKey);
        }

        /// <summary>
        /// privatekey parse publickeyaddress
        /// </summary>
        /// <param name="mykeypair">KeyPairからのParse</param>
        /// <returns></returns>
        private Address parsepublickey(KeyPair mykeypair)
        {
            Address parsepublickey;
            try
            {
                parsepublickey = new PublicKeyAddress(mykeypair);
            }
            catch (Exception)
            {
                return null;
            }
            return parsepublickey;
        }
    }
}
