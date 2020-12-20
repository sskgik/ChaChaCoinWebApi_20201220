namespace WalletService
{
    using System;
    using System.Threading.Tasks;
    using System.Net.Http;
    using Miyabi;
    using Miyabi.Asset.Client;
    using Miyabi.Asset.Models;
    using Miyabi.NFT.Client;
    using Miyabi.NFT.Models;
    using Miyabi.ClientSdk;
    using Miyabi.Common.Models;
    using Miyabi.Cryptography;
    using System.Diagnostics;


    /// <summary>
    /// Wallt action class.
    /// </summary>
    public class WAction
    {
        private static string ApiUrl = "https://playground.blockchain.bitflyer.com/";


        /// <summary>
        /// Send Asset Method
        /// </summary>
        /// <param name="TableName">         コインを動かすテーブルの名前       </param>
        /// <param name="formerKeypair">     署名に必要なキーペアー             </param>
        /// <param name="myaddress">         送金元のアドレス（パブリックキー ） </param>
        /// <param name="opponetaddress">    送金先のパブリックキー             </param>
        /// <param name="amount">            送金枚数                          </param>
        /// <returns></returns>
        public async Task<Tuple<string, string>> Send(string TableName,KeyPair formerKeypair, Address myaddress, Address opponetaddress, decimal amount)
        {
            var client = this.SetClient();
            var generalApi = new GeneralApi(client);
            var from = myaddress;
            var to = opponetaddress;
           
            // enter the send amount
            var moveCoin = new AssetMove(TableName, amount, from, to);
            var tx = TransactionCreator.SimpleSignedTransaction(
                new ITransactionEntry[] { moveCoin },
                new[] { formerKeypair.PrivateKey });
            await this.SendTransaction(tx);
            //20201126karisyuusei
            //var result = await WaitTx(generalApi, tx.Id);
            return new Tuple<string, string>(tx.Id.ToString(), "success");
        }
        /// <summary>
        /// SwapAsset on AssetTable:AssetTable
        /// </summary>
        /// <param name="beforeSwapTablename"> スワップ元のテーブルネーム  </param>
        /// <param name="SwapTablename">       スワップ先のテーブルネーム  </param>
        /// <param name="formerKeypair">       スワップ元のキーペア        </param>
        /// <param name="SwapPrivatekey">      スワップに使う中継のキーペア</param>
        /// <param name="Myaddress">           スワップ元のアドレス       </param>
        /// <param name="SwapAddress">         スワップ中継のアドレス     </param>
        /// <param name="amount">              スワップ枚数               </param>
        /// <returns>txSigned.Id.ToString(), "success"</returns>
        public async Task<Tuple<string, string>> SwapAsset(string beforeSwapTablename,string SwapTablename,KeyPair formerKeypair, KeyPair SwapKeypair,
                                                           Address Myaddress,Address SwapAddress, decimal amount)
        {
            var client = this.SetClient();
            var generalApi = new GeneralApi(client);
            var from = Myaddress;
            var to = SwapAddress;//Publickey with Swap

            //  ChaChaCoin Table
            var coinA = new AssetMove(beforeSwapTablename,amount,from,to);
            // SAKURAcoin Table
            var coinB = new AssetMove(SwapTablename,amount, to,from);

            var txSigned = TransactionCreator.CreateTransactionBuilder(
                new[] { coinA, coinB },
                new[]
                {
                    new SignatureCredential(formerKeypair.PublicKey),
                    new SignatureCredential(SwapKeypair.PublicKey),
                })
                .Sign(formerKeypair.PrivateKey)
                .Sign(SwapKeypair.PrivateKey)
                .Build();

            await generalApi.SendTransactionAsync(txSigned);
            return new Tuple<string, string>(txSigned.Id.ToString(), "success");

            //var result = await Utils.WaitTx(generalApi, txSigned.Id);
            //Console.WriteLine($"txid={txSigned.Id}, result={result}");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="PaymentSourceTableName">支払い元のテーブル名      </param>
        /// <param name="NFTtablename">          対象のNFTテーブルの名前   </param>
        /// <param name="tokenID">               購入するトークンの名前    </param>
        /// <param name="formerprivatekey">      支払い元のプライベートキー</param>
        /// <param name="DistributorPrivatekey"> 販売者のプライベートキー  </param>
        /// <param name="PaymentsourceAddress">  支払い元のパブリックキー  </param>
        /// <param name="DistributorAddress">    販売者のパブリックキー    </param>
        /// <param name="amountofmoney">         金額                     </param>
        /// <returns></returns>
        public async Task<Tuple<string, string>>  BuyNFTCard(string  PaymentSourceTableName, string NFTtablename, string tokenID, 
            KeyPair formerKeypair, KeyPair  DistributorKeypair, Address PaymentsourceAddress, Address DistributorAddress, decimal amountofmoney)
        {
            var client = this.SetClient();
            var generalApi = new GeneralApi(client);
            var from = PaymentsourceAddress;
            var NFTto = from;
            var to = DistributorAddress;//Distributor publickey

            //  ChaChaCoin Table
            var coinA = new AssetMove(PaymentSourceTableName, amountofmoney, from, to);
            // SAKURAcoin Table
            var coinB = new NFTMove(NFTtablename, tokenID, NFTto);

            var txSigned = TransactionCreator.CreateTransactionBuilder(
                new ITransactionEntry[] { coinA, coinB },
                new[]
                {
                    new SignatureCredential(formerKeypair.PublicKey),
                    new SignatureCredential(DistributorKeypair.PublicKey),
                })
                .Sign(formerKeypair.PrivateKey)
                .Sign(DistributorKeypair.PrivateKey)
                .Build();

            await generalApi.SendTransactionAsync(txSigned);
            return new Tuple<string, string>(txSigned.Id.ToString(), "success");

            //var result = await Utils.WaitTx(generalApi, txSigned.Id);
            //Console.WriteLine($"txid={txSigned.Id}, result={result}");
        }

        /// <summary>
        /// show Asset of designated publickeyAddress
        /// </summary>
        /// <param name="publickey">開示するパブリックキー </param>
        /// <param name="tablename">情報を開示するテーブルネーム</param>
        /// <returns>result.Value</returns>
        public async Task<decimal> ShowAsset(string publickey ,string tablename)
        {
            PublicKeyAddress myaddress = null;
            var client = this.SetClient();
            var assetClient = new AssetClient(client);
            AssetTypesRegisterer.RegisterTypes();

            try
            {
                var value = PublicKey.Parse(publickey);
                myaddress = new PublicKeyAddress(value);
            }
            catch (Exception)
            {
                return 0m;
            }
            
            var result = await assetClient.GetAssetAsync(tablename, myaddress);
            return result.Value;
        }

        /// <summary>
        /// Send Transaction to miyabi blockchain
        /// </summary>
        /// <param name="tx">トランザクション情報</param>
        /// <returns></returns>
        public async Task SendTransaction(Transaction tx)
         {
            var client = this.SetClient();
            var generalClient = new GeneralApi(client);

            try
            {
                var send = await generalClient.SendTransactionAsync(tx);
                var result_code = send.Value;

                if (result_code != TransactionResultCode.Success
                   && result_code != TransactionResultCode.Pending)
                {
                    // Console.WriteLine("取引が拒否されました!:\t{0}", result_code);
                }
            }
            catch (Exception)
            {
                // Console.Write("例外を検知しました！{e}");
                return;
            }
         }
        /// <summary>
        ///  Get Publickey from Keypair
        /// </summary>
        /// <returns></returns>
        public Address GetAddress(KeyPair formerkeypair)
        {
            return new PublicKeyAddress(formerkeypair);
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
            catch(Exception)
            {
                //失敗のHTTPリクエストを投げるようにする
                return null;
            }
            return new KeyPair(adminPrivateKey);
        }
    }
}