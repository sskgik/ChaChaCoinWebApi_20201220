using System;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Miyabi;
using Miyabi.Asset.Client;
using Miyabi.Asset.Models;
using Miyabi.NFT.Client;
using Miyabi.NFT.Models;
using Miyabi.Cryptography;
using Miyabi.Common.Models;
using Miyabi.ClientSdk;
using WalletService;
using Miyabi.Serialization.Json;
using System.Text.Json;
using System.Diagnostics;
using System.ComponentModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChaChaCoin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class miyabiController : ControllerBase
    {

        //recieve send_info
        [DataContract]
        public class Transactioninfo
        {
            [DataMember]
            public string TableName { get; set; }     //送金情報のテーブル
            [DataMember]
            public string my_privatekey { get; set; }  //送金元のプライベートキー 
            [DataMember]
            public string opponet_pubkey { get; set; } //送金先のパブリックキー 
            [DataMember]
            public string send_amount { get; set; }    //送金枚数
        }
        //send resulet responce
        [DataContract]
        public class Result
        {
            [DataMember]
            public  int code { get; set; }            //レスポンスコードの種類
            [DataMember]
            public string transactionId { get; set; } //トランザクションID情報
            [DataMember]
            public string result { get; set; }        //トランザクションの結果
        }
        //coin amount
        [DataContract]
        public class Showamount
        {
            [DataMember]
            public string my_publickey { get; set; } //枚数開示のパブリックキー 
            [DataMember]
            public string Tablename { get; set; }    //枚数を開示するテーブルの名前
        }
        [DataContract]
        public class Showresult
        {
            [DataMember]
            public  string coin_amount { get; set; }  //レスポンスに乗せるコインの枚数
        }
         //privatekey regist
        [DataContract]
        public class RegistName
        {
            [DataMember]
            public string nickname { get; set; }     //pkcs12file's Name
        }

        [DataContract]
        public class  getkeypair
        {
            [DataMember]
            public string PrivateKey { get; set; }   //レスポンスに乗せるプライベートキー
            [DataMember]
            public string PublicKey { get; set; }    //レスポンスに載せるパブリックキー 

        }
        //裏オプション（プライベートキーの手動登録）
        [DataContract]
        public class BeforeParse
        {
            [DataMember]
            public string BeforeParsePrivateKey { get; set; } //個人のプライベートキー 文字列

        }
        [DataContract]
        public class AfterParse
        {
            [DataMember]
            public string AfterParsepublickey { get; set; }  //個人のパブリックキー 文字列

        }

        //recieve swap_info
        [DataContract]
        public class SwapTransactioninfo
        {
            [DataMember]
            public string BeforeSwapTable { get; set; }        //Swap Source Asset Table Name
            [DataMember]
            public string SwapTable { get; set; }              //Opponet Swap Table Name
            [DataMember]
            public string my_privatekey { get; set; }          //Swap Source Privatekey
            [DataMember]
            public string swap_opponet_pubkey { get; set; }    //Swap Distination Publickey
            [DataMember]
            public string swap_amount { get; set; }            //Swap Amount
        }

        //NFT buy_info
        [DataContract]
        public class BuyNFTInfo
        {
            [DataMember]
            public string PaymentSourceTable { get; set; }     //Payment Source Asset Table Name
            [DataMember]
            public string NFTTableNametobuy { get; set; }      //Opponet NFTTable Name
            [DataMember]
            public string TokenID { get; set; }                //Opponet NFT TokenID
            [DataMember]
            public string PaymentSourcePrivateKey { get; set; }//Payment Source Privatekey
            [DataMember]
            public string PaymentPublicKey { get; set; }       //Opponetpublickey
            [DataMember]
            public string Amountofmoney { get; set; }          //Payment Amount
        }
        // GET: api/<miyabiController>/
        /*[HttpGet]
        [Route("aaa")]
        public async Task<string> Get()
        {*/

        //return new string[] { "value1", "value2" };
        //}

        // POST api/<miyabiController>
        /// <summary>
        /// coinsend application
        /// </summary>
        /// <param name="info">受け取ったJsonデータのオブジェクト(送金情報)</param>
        /// <returns>return resultjson</returns>
        /// <returns>return successresultjson</returns>

        //post /api/<miyabiController>/send
        [Route("send")]
        [HttpPost]
        public async Task<string>  Coinsend([FromBody] Transactioninfo info)
        {
            AssetTypesRegisterer.RegisterTypes();
            string tablename = info.TableName;
            WAction walletservice = new WAction();
            KeyPair privatekey = walletservice.GetKeyPair(info.my_privatekey);
            if(privatekey == null)
            {
                // comment:プライベートキーが適正ではありません！
                Result txresult = new Result();
                txresult.code = 1;
                txresult.transactionId = string.Empty;
                txresult.result = string.Empty;
                string resultjson = JsonSerializer.Serialize(txresult);
                return resultjson;
            }
            Address mypublickey = Inputjudgement1(privatekey);
            if(mypublickey == null)
            {
                //comment:パブリックキーを適正に変換できませんでした！
                Result txresult = new Result();
                txresult.code = 2;
                txresult.transactionId = string.Empty;
                txresult.result = string.Empty;
                string resultjson = JsonSerializer.Serialize(txresult);
                return resultjson;
            }
            Address opponetpublickey = Inputjudgement2(info.opponet_pubkey);
            if(opponetpublickey == null)
            {
                // comment:入力された送信相手のパブリックキーが不適正です！入力値を再確認してください!
                Result txresult = new Result();
                txresult.code = 3;
                txresult.transactionId =  string.Empty;
                txresult.result = string.Empty;
                string resultjson = JsonSerializer.Serialize(txresult);
                return resultjson;
            }
            decimal amount = Inputnumjudgement(info.send_amount);
            if (amount == 0m)
            {
                //comment:数字ではない文字が入力されています！数字に直してください
                Result txresult = new Result();
                txresult.code = 4;
                txresult.transactionId = string.Empty;
                txresult.result = string.Empty;
                string resultjson = JsonSerializer.Serialize(txresult);
                return resultjson;
            }
            (string transaction, string result) = await walletservice.Send(tablename,privatekey, mypublickey, opponetpublickey, amount);
            Result successtxresult = new Result();
            successtxresult.code = 5;
            successtxresult.transactionId = transaction;
            successtxresult.result = result;
            string successresultjson = JsonSerializer.Serialize(successtxresult);
            return successresultjson;
        }
        /// <summary>
        /// coinswap Asset Table
        /// </summary>
        /// <param name="info">受け取ったJsonデータのオブジェクト(スワップ情報)</param>
        /// <returns></returns>
        //post /api/<miyabiController>/swap
        [Route("swap")]
        [HttpPost]
        public async Task<string> Coinswap([FromBody] SwapTransactioninfo  swapinfo)
        {
            AssetTypesRegisterer.RegisterTypes();
            WAction walletservice = new WAction();
            string formerswapTable = swapinfo.BeforeSwapTable;
            String SwapTablename = swapinfo.SwapTable;
            //Convert PrivateKey
            KeyPair privatekey = walletservice.GetKeyPair(swapinfo.my_privatekey);
            if (privatekey == null)
            {
                // comment:プライベートキーが適正ではありません！
                Result txresult = new Result();
                txresult.code = 1;
                txresult.transactionId = string.Empty;
                txresult.result = string.Empty;
                string resultjson = JsonSerializer.Serialize(txresult);
                return resultjson;
            }
            //Convert Publickey
            Address  swapopponetpublickey = Inputjudgement2(swapinfo.swap_opponet_pubkey);
            if (swapopponetpublickey == null)
            {
                // comment:入力された送信相手のパブリックキーが不適正です！入力値を再確認してください!
                Result txresult = new Result();
                txresult.code = 3;
                txresult.transactionId = string.Empty;
                txresult.result = string.Empty;
                string resultjson = JsonSerializer.Serialize(txresult);
                return resultjson;
            }
            decimal swapamount = Inputnumjudgement(swapinfo.swap_amount);
            if (swapamount == 0m)
            {
                //comment:数字ではない文字が入力されています！数字に直してください
                Result txresult = new Result();
                txresult.code = 4;
                txresult.transactionId = string.Empty;
                txresult.result = string.Empty;
                string resultjson = JsonSerializer.Serialize(txresult);
                return resultjson;
            }
            var ToSwapPrivatekey = "584fb281470a0d9adef69b52a0ce5cf7aae9c083733e21450306e8d862e81a45";// Privatekey with Swap
            var ToSwapPublickey = "02680681c9d83141817559a31cd4b85156d2669e4530d7def5e6d11fb5a350e123";//Publickey with Swap
            KeyPair SwapPrivateKey = walletservice.GetKeyPair(ToSwapPrivatekey);
            Address SwapPublickey = Inputjudgement2(ToSwapPublickey);
            (string transaction, string result) = await walletservice.SwapAsset( formerswapTable,SwapTablename , privatekey, SwapPrivateKey, swapopponetpublickey, SwapPublickey , swapamount);
            Result successtxresult = new Result();
            successtxresult.code = 5;
            successtxresult.transactionId = transaction;
            successtxresult.result = result;
            string successresultjson = JsonSerializer.Serialize(successtxresult);
            return successresultjson;
        }


        /// <summary>
        /// Buy NFT Token
        /// </summary>
        /// <param name="info">受け取ったJsonデータのオブジェクト(NFTの購入情報)</param>
        /// <returns></returns>
        //post /api/<miyabiController>/buynft
        [Route("buynft")]
        [HttpPost]
        public async Task<string> BuyNFT([FromBody] BuyNFTInfo  info )
        {
            AssetTypesRegisterer.RegisterTypes();
            NFTTypesRegisterer.RegisterTypes();
            WAction walletservice = new WAction();
            string SourceTableName = info.PaymentSourceTable;
            string NFTTablename = info.NFTTableNametobuy;
            string tokenID = info.TokenID;
            //Convert PrivateKey
            KeyPair Sourcekeypair = walletservice.GetKeyPair(info.PaymentSourcePrivateKey);
            if (Sourcekeypair == null)
            {
                // comment:プライベートキーが適正ではありません！
                Result txresult = new Result();
                txresult.code = 1;
                txresult.transactionId = string.Empty;
                txresult.result = string.Empty;
                string resultjson = JsonSerializer.Serialize(txresult);
                return resultjson;
            }
            //
            Address SourcePublickey = Inputjudgement1(Sourcekeypair);
            if (SourcePublickey == null)
            {
                //comment:パブリックキーを適正に変換できませんでした！
                Result txresult = new Result();
                txresult.code = 2;
                txresult.transactionId = string.Empty;
                txresult.result = string.Empty;
                string resultjson = JsonSerializer.Serialize(txresult);
                return resultjson;
            }
            //Convert Publickey
            Address PaymentDestination  = Inputjudgement2(info.PaymentPublicKey);
            if (PaymentDestination == null)
            {
                // comment:入力された送信相手のパブリックキーが不適正です！入力値を再確認してください!
                Result txresult = new Result();
                txresult.code = 3;
                txresult.transactionId = string.Empty;
                txresult.result = string.Empty;
                string resultjson = JsonSerializer.Serialize(txresult);
                return resultjson;
            }
            decimal amountofmoney = Inputnumjudgement(info.Amountofmoney);
            if (amountofmoney == 0m)
            {
                //comment:数字ではない文字が入力されています！数字に直してください
                Result txresult = new Result();
                txresult.code = 4;
                txresult.transactionId = string.Empty;
                txresult.result = string.Empty;
                string resultjson = JsonSerializer.Serialize(txresult);
                return resultjson;
            }
            var ToSwapPrivatekey = "a93f8caacd63b42f39121153267efdd403ac0f28ca76dd2830fe91e398e87543";// Distributor Privatekey
            var ToSwapPublickey = "0266752d0e7cccc0c539cef223e4361adbf724cdbbb625a5fcb1e69bb1c1e92e11";//Distributor Publickey
            KeyPair DistributorKeypair = walletservice.GetKeyPair(ToSwapPrivatekey);
            Address DistributorPublickey = Inputjudgement2(ToSwapPublickey);
            (string transaction, string result) = await walletservice.BuyNFTCard(SourceTableName, NFTTablename, tokenID, Sourcekeypair, DistributorKeypair, 
                SourcePublickey, DistributorPublickey, amountofmoney);
            Result successtxresult = new Result();
            successtxresult.code = 5;
            successtxresult.transactionId = transaction;
            successtxresult.result = result;
            string successresultjson = JsonSerializer.Serialize(successtxresult);
            return successresultjson;
        }
        /// <summary>
        /// showcoin Asset table
        /// </summary>
        /// <param name="showdata">受け取ったJsonデータのオブジェクト(開示情報)</param>
        /// <returns>return amountjson</returns>
        //post /api/<miyabiController>/show
        [Route("show")]
        [HttpPost]
        public async Task<string> showcoin([FromBody] Showamount showdata)
        {
            decimal coinamount = 0m;
            WAction walletservice = new WAction();
            coinamount = await walletservice.ShowAsset(showdata.my_publickey,showdata.Tablename);
            Showresult amountresult = new Showresult();
            amountresult.coin_amount = Convert.ToString(coinamount);    
            string amountjson = JsonSerializer.Serialize(amountresult);
            return amountjson;
        }
        /// <summary>
        ///  Get KeyPair at first
        /// </summary>
        /// <param name="registname">受け取ったJsonデータのオブジェクト(登録情報)</param>
        /// <returns></returns>
        //post /api/<miyabiController>/regist
        [Route("regist")]
        [HttpPost]
        public string Get_Keypair([FromBody]RegistName registname)
        {
            AssetTypesRegisterer.RegisterTypes();
            Process process = new Process();
            string arg = registname.nickname ;//argumenrt

            ProcessStartInfo psinfo = new ProcessStartInfo()
            {
                FileName = "/usr/local/bin/Generate_Privekey.sh",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true,
                Arguments = "\t" + arg,
            };
            Process p = Process.Start(psinfo);

            p.WaitForExit();
            string privatekey = p.StandardOutput.ReadToEnd();
            privatekey = privatekey.Substring(0, privatekey.Length - 1);
            p.Close();

            WAction walletservice = new WAction();
            KeyPair privatekey1 = walletservice.GetKeyPair(privatekey);
            if (privatekey1 == null)
            {
                // comment:プライベートキーが正しく取得できませんでした！
                getkeypair getkeypair = new getkeypair();
                getkeypair.PrivateKey = string.Empty;
                getkeypair.PublicKey = string.Empty;
                string resultjson = JsonSerializer.Serialize(getkeypair);
                return resultjson;
            }
            Address mypublickey = Inputjudgement1(privatekey1);
            if (mypublickey == null)
            {
                //comment:パブリックキーに変換できませんでした！
                getkeypair getkeypair = new getkeypair();
                getkeypair.PrivateKey = string.Empty;
                getkeypair.PublicKey = string.Empty;
                string resultjson = JsonSerializer.Serialize(getkeypair);
                return resultjson;
            }
            string ParsePublicKey = Convert.ToString(mypublickey);

            getkeypair keypair = new getkeypair();
            keypair.PrivateKey = privatekey;
            keypair.PublicKey = ParsePublicKey;
            string keypairjson = JsonSerializer.Serialize(keypair);
            return keypairjson;
        }
        /// <summary>
        /// Private to Publickey Parse
        /// </summary>
        /// <param name="parse">受け取ったJsonデータのオブジェクト</param>
        /// <returns></returns>
        [Route("parse")]
        [HttpPost]
        public string Parse([FromBody] BeforeParse parse)
        {
            AssetTypesRegisterer.RegisterTypes();
            WAction walletservice = new WAction();
            KeyPair privatekey = walletservice.GetKeyPair(parse.BeforeParsePrivateKey);
            if (privatekey == null)
            {
                // comment:プライベートキーが適正ではありません！
                AfterParse missparse = new AfterParse();
                missparse.AfterParsepublickey = string.Empty;
                string resultjson = JsonSerializer.Serialize(missparse);
                return resultjson;
            }
            Address mypublickey = Inputjudgement1(privatekey);
            if (mypublickey == null)
            {
                //comment:パブリックキーに変換できませんでした！
                AfterParse  missparse = new AfterParse();
                missparse.AfterParsepublickey = string.Empty;
                string resultjson = JsonSerializer.Serialize(missparse);
                return resultjson;
            }
            string ParsePublicKey = Convert.ToString(mypublickey);

            AfterParse afterparse = new AfterParse();
            afterparse.AfterParsepublickey = ParsePublicKey;
            string successjson = JsonSerializer.Serialize(afterparse);
            return successjson;
        }

        /// <summary>
        /// ReadPKCS12file
        /// </summary>
        /// <param name="registname">受け取ったJsonデータのオブジェクト</param>
        /// <returns></returns>
        [Route("readfile")]
        [HttpPost]
        public string ReadFile([FromBody] RegistName registname)
        {
            AssetTypesRegisterer.RegisterTypes();
            Process process = new Process();
            string arg = registname.nickname;//argumenrt

            ProcessStartInfo psinfo = new ProcessStartInfo()
            {
                FileName = "/usr/local/bin/ReadKeyFile.sh",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true,
                Arguments = "\t" + arg,
            };
            Process p = Process.Start(psinfo);

            p.WaitForExit();
            string privatekey = p.StandardOutput.ReadToEnd();
            privatekey = privatekey.Substring(0, privatekey.Length - 1);
            p.Close();

            WAction walletservice = new WAction();
            KeyPair privatekey1 = walletservice.GetKeyPair(privatekey);
            if (privatekey1 == null)
            {
                // comment:プライベートキーが正しく取得できませんでした！
                getkeypair getkeypair = new getkeypair();
                getkeypair.PrivateKey = string.Empty;
                getkeypair.PublicKey = string.Empty;
                string resultjson = JsonSerializer.Serialize(getkeypair);
                return resultjson;
            }
            Address mypublickey = Inputjudgement1(privatekey1);
            if (mypublickey == null)
            {
                //comment:パブリックキーに変換できませんでした！
                getkeypair getkeypair = new getkeypair();
                getkeypair.PrivateKey = string.Empty;
                getkeypair.PublicKey = string.Empty;
                string resultjson = JsonSerializer.Serialize(getkeypair);
                return resultjson;
            }
            string ParsePublicKey = Convert.ToString(mypublickey);

            getkeypair keypair = new getkeypair();
            keypair.PrivateKey = privatekey;
            keypair.PublicKey = ParsePublicKey;
            string keypairjson = JsonSerializer.Serialize(keypair);
            return keypairjson;
        }

        /// <summary>
        /// privatekey parse publickeyaddress
        /// </summary>
        /// <param name="mykeypair">KeyPairからのParse</param>
        /// <returns></returns>
        private Address Inputjudgement1( KeyPair mykeypair)
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
        /// <summary>
        /// publickey string parse publickey
        /// </summary>
        /// <param name="text">//パブリックキー から文字列のParse</param>
        /// <returns></returns>
        private Address Inputjudgement2(string text)
        {
            Address inputaddress = null;
            try
            {
                var value = PublicKey.Parse(text);
                inputaddress = new PublicKeyAddress(value);
            }
            catch (Exception)
            {
                return null;
            }

            return inputaddress;
        }
        /// <summary>
        /// amount string parse amount
        /// </summary>
        /// <param name="text">変換する枚数の文字列</param>
        /// <returns></returns>
        private decimal Inputnumjudgement(string text)
        {
            decimal inputamount = 0m;

            try
            {
                inputamount = Convert.ToDecimal(text);
            }
            catch (Exception)
            {
                return 0m;
            }

            return inputamount;
        }
    }
}
