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
using Miyabi.Contract.Client;
using Miyabi.Contract.Models;
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
    public class SmartContractController : ControllerBase
    {
        //Participant Event (RegistPublicKey)
        [DataContract]
        public class ParticipateInfo
        {
            [DataMember]
            public string ParticipantPrivateKey { get; set; }  //Event participant's private key
            [DataMember]
            public string Eventname { get; set; } //The name of the event to attend

        }
        //return Transaction result
        [DataContract]
        public class ParticipateTransactionResult
        {
            [DataMember]
            public string ParticipantTransactionID { get; set; }  //Transaction execution result ID
            [DataMember]
            public string result { get; set; } //Transaction execution result

        }
        // POST api/<SmartContractController>/paticipate
        /// <summary>
        /// イベントの参加登録
        /// </summary>
        /// <param name="pinfo"></param>
        /// <returns></returns>
        [Route("event/paticipate")]
        [HttpPost]
        public async Task<string> Participantevent([FromBody] ParticipateInfo pinfo)
        {
            ContractTypesRegisterer.RegisterTypes();
            ContractService contract = new ContractService();
            KeyPair ParticipantKeypair = contract.GetKeyPair(pinfo.ParticipantPrivateKey);
            if(ParticipantKeypair == null)
            {
                // comment:プライベートキーが適正ではありません！
                var txresult = new ParticipateTransactionResult();
                txresult.ParticipantTransactionID = string.Empty;
                txresult.result = string.Empty;
                string resultjson = JsonSerializer.Serialize(txresult);
                return resultjson;
            }
            (string transaction, string result) = await contract.InvokeContract_ParticipateEvent(ParticipantKeypair, pinfo.Eventname);
            var successresult = new ParticipateTransactionResult();
            successresult.ParticipantTransactionID = transaction;
            successresult.result = result;
            string successresultjson = JsonSerializer.Serialize(successresult);
            return successresultjson;
        }

        //Participant Event (RegistPublicKey)
        [DataContract]
        public class ConfirmInfo
        {
            [DataMember]
            public string ParticipantPublickey { get; set; }  //Event participant's private key
            [DataMember]
            public string Eventname { get; set; } //The name of the event to attend

        }
        //return Transaction result
        [DataContract]
        public class ConfirmnResult
        {
            [DataMember]
            public string value { get; set; }  //Confirm result 

        }
        // POST api/<SmartContractController>/paticipate
        /// <summary>
        /// イベントの参加登録
        /// </summary>
        /// <param name="pinfo"></param>
        /// <returns></returns>
        [Route("event/confirm")]
        [HttpPost]
        public async Task<string> ConfirmParticipant([FromBody] ConfirmInfo confirminfo)
        {
            ContractTypesRegisterer.RegisterTypes();
            ContractService contract = new ContractService();
            var ParticipantPublickey = parsepublickeytype(confirminfo.ParticipantPublickey);
            if(ParticipantPublickey == null)
            {
                var confirmresult = new ConfirmnResult();
                confirmresult.value = string.Empty;
                string resultjson = JsonSerializer.Serialize(confirmresult);
                return resultjson;
            }
            var result = await contract.Query_confirmparticipate("Confirmpaticipate", new[] {confirminfo.ParticipantPublickey , confirminfo.Eventname });
            var successresult = new ConfirmnResult();
            successresult.value = result;
            string successresultjson = JsonSerializer.Serialize(successresult);
            return successresultjson;
        }

        //Regist IssuranceRight Info (RegistPublicKey)
        [DataContract]
        public class IssuranceRightRegistInfo
        {
            [DataMember]
            public string IssuranceRightPrivatekey { get; set; }  //Regist vote of Issurance Right privatekey
        }
        //return Transaction result
        [DataContract]
        public class IssuranceRightRegistTransactionResult
        {
            [DataMember]
            public string IssuranceRightRegistTransactionID { get; set; }  //Transaction execution result ID
            [DataMember]
            public string result { get; set; } //Transaction execution result

        }
        // POST api/<SmartContractController>/regist/issuranceright
        /// <summary>
        /// 票の発行権の登録
        /// </summary>
        /// <param name="registinfo"></param>
        /// <returns></returns>
        [Route("regist/issuranceright")]
        [HttpPost]
        public async Task<string> IssuranceRightRegist([FromBody] IssuranceRightRegistInfo registinfo)
        {
            ContractTypesRegisterer.RegisterTypes();
            ContractService contract = new ContractService();
            KeyPair IssuranceRightKeypair = contract.GetKeyPair(registinfo.IssuranceRightPrivatekey);
            if (IssuranceRightKeypair == null)
            {
                // comment:プライベートキーが適正ではありません！
                var txresult = new IssuranceRightRegistTransactionResult();
                txresult.IssuranceRightRegistTransactionID = string.Empty;
                txresult.result = string.Empty;
                string resultjson = JsonSerializer.Serialize(txresult);
                return resultjson;
            }
            (string transaction, string result) = await contract.InvokeContract_RegistIssuanceRight(IssuranceRightKeypair);
            var successresult = new IssuranceRightRegistTransactionResult();
            successresult.IssuranceRightRegistTransactionID = transaction;
            successresult.result = result;
            string successresultjson = JsonSerializer.Serialize(successresult);
            return successresultjson;
        }

        //Replenishment Votes
        [DataContract]
        public class Replenishmentvoteinfo
        {
            [DataMember]
            public string Requesterprivatekey { get; set; }  //Replenishment vote RequestPrivateKey
            [DataMember]
            public string ReplenishmentVotesamount { get; set; } //Replenishment Votes amount
        }
        //return Transaction result
        [DataContract]
        public class ReplenishmentvoteTransactionResult
        {
            [DataMember]
            public int code { get; set; }            // kind of responcecode
            [DataMember]
            public string ReplenishmentvoteTransactionID { get; set; }  //Transaction execution result ID
            [DataMember]
            public string result { get; set; } //Transaction execution result

        }
        // POST api/<SmartContractController>/issurancevote
        /// <summary>
        /// 登録されたアドレスのよる票の発行
        /// </summary>
        /// <param name="replenishmentinfo"></param>
        /// <returns></returns>
        [Route("issurancevote")]
        [HttpPost]
        public async Task<string> Issurancevotes([FromBody] Replenishmentvoteinfo replenishmentinfo)
        {
            ContractTypesRegisterer.RegisterTypes();
            ContractService contract = new ContractService();
            KeyPair RequesterKeypair = contract.GetKeyPair(replenishmentinfo.Requesterprivatekey);
            if (RequesterKeypair == null)
            {
                // comment:プライベートキーが適正ではありません！
                var txresult = new ReplenishmentvoteTransactionResult();
                txresult.code = 1;
                txresult.ReplenishmentvoteTransactionID = string.Empty;
                txresult.result = string.Empty;
                string resultjson = JsonSerializer.Serialize(txresult);
                return resultjson;
            }
            decimal convertcheckvoteamount = parsenumjudgement(replenishmentinfo.ReplenishmentVotesamount);
            if(convertcheckvoteamount == 0m)
            {
                // comment:数値に変換できません半角数字を入力してください
                var txresult = new ReplenishmentvoteTransactionResult();
                txresult.code = 2;
                txresult.ReplenishmentvoteTransactionID = string.Empty;
                txresult.result = string.Empty;
                string resultjson = JsonSerializer.Serialize(txresult);
                return resultjson;
            }
            (string transaction, string result) = await contract.InvokeContract_ReplenishmentVotes(RequesterKeypair, replenishmentinfo.ReplenishmentVotesamount);
            var successresult = new ReplenishmentvoteTransactionResult();
            successresult.code = 3;
            successresult.ReplenishmentvoteTransactionID = transaction;
            successresult.result = result;
            string successresultjson = JsonSerializer.Serialize(successresult);
            return successresultjson;
        }

        //Distribute Votes info
        [DataContract]
        public class Distributevoteinfo
        {
            [DataMember]
            public string Tablename { get; set; }    //The name of the table that moves the coins
            [DataMember]
            public string Requesterprivatekey { get; set; }  //Replenishment vote RequestPrivateKey
            [DataMember]
            public string Eventname { get; set; } //The name of the event to attend
            [DataMember]
            public string Paycoinamount { get; set; } //Replenishment Votes amount
        }
        //return Transaction result
        [DataContract]
        public class DistributevoteTransactionResult
        {
            [DataMember]
            public int code { get; set; }            // kind of responcecode
            [DataMember]
            public string DistributevoteTransactionID { get; set; }  //Transaction execution result ID
            [DataMember]
            public string result { get; set; } //Transaction execution result

        }
        // POST api/<SmartContractController>/getvote
        /// <summary>
        /// 
        /// </summary>
        /// <param name="replenishmentinfo"></param>
        /// <returns></returns>
        [Route("getvote")]
        [HttpPost]
        public async Task<string> Distributevotes([FromBody] Distributevoteinfo distributeinfo)
        {
            AssetTypesRegisterer.RegisterTypes();
            ContractTypesRegisterer.RegisterTypes();
            ContractService contract = new ContractService();
            KeyPair RequesterKeypair = contract.GetKeyPair(distributeinfo.Requesterprivatekey);
            if (RequesterKeypair == null)
            {
                // comment:プライベートキーが適正ではありません！
                var txresult = new DistributevoteTransactionResult();
                txresult.code = 1;
                txresult.DistributevoteTransactionID = string.Empty;
                txresult.result = string.Empty;
                string resultjson = JsonSerializer.Serialize(txresult);
                return resultjson;
            }
            decimal convertpaycoinamount = parsenumjudgement(distributeinfo.Paycoinamount);
            if (convertpaycoinamount == 0m)
            {
                // comment:数値に変換できません半角数字を入力してください
                var txresult = new DistributevoteTransactionResult();
                txresult.code = 2;
                txresult.DistributevoteTransactionID = string.Empty;
                txresult.result = string.Empty;
                string resultjson = JsonSerializer.Serialize(txresult);
                return resultjson;
            }
            string EventownerPrivatekey = "a93f8caacd63b42f39121153267efdd403ac0f28ca76dd2830fe91e398e87543"; //Event owner Privatekey
            //string EventownerPublickey = "0266752d0e7cccc0c539cef223e4361adbf724cdbbb625a5fcb1e69bb1c1e92e11";//Event owner Publickey
            KeyPair EventownerKeypair = contract.GetKeyPair(EventownerPrivatekey);
            (string transaction, string result) = await contract.InvokeContract_Distributevotes(distributeinfo.Tablename,RequesterKeypair,EventownerKeypair, distributeinfo.Eventname,convertpaycoinamount);
            var successresult = new DistributevoteTransactionResult();
            successresult.code = 3;
            successresult.DistributevoteTransactionID = transaction;
            successresult.result = result;
            string successresultjson = JsonSerializer.Serialize(successresult);
            return successresultjson;
        }

        //Distribute Votes info
        [DataContract]
        public class Registvotetargetinfo
        {

            [DataMember]
            public string  Registerprivatekey { get; set; }  //Replenishment vote RequestPrivateKey
            [DataMember]
            public string targetpublickey { get; set; } //The name of the event to attend
            [DataMember]
            public string Eventname { get; set; } //Replenishment Votes amount
        }
        //return Transaction result
        [DataContract]
        public class RegistvotetargetTransactionResult
        {
            [DataMember]
            public int code { get; set; }            // kind of responcecode
            [DataMember]
            public string RegistvotetargetTransactionID { get; set; }  //Transaction execution result ID
            [DataMember]
            public string result { get; set; } //Transaction execution result

        }
        // POST api/<SmartContractController>/getvote
        /// <summary>
        /// 
        /// </summary>
        /// <param name="replenishmentinfo"></param>
        /// <returns></returns>
        [Route("regist/votetarget")]
        [HttpPost]
        public async Task<string>  Registvotetarget([FromBody] Registvotetargetinfo Registvoteinfo)
        {
            ContractTypesRegisterer.RegisterTypes();
            ContractService contract = new ContractService();
            KeyPair RegisterKeypair = contract.GetKeyPair(Registvoteinfo.Registerprivatekey);
            if (RegisterKeypair == null)
            {
                // comment:プライベートキーが適正ではありません！
                var txresult = new RegistvotetargetTransactionResult();
                txresult.code = 1;
                txresult.RegistvotetargetTransactionID = string.Empty;
                txresult.result = string.Empty;
                string resultjson = JsonSerializer.Serialize(txresult);
                return resultjson;
            }
            var targetpubrickey = parsepublickeytype(Registvoteinfo.targetpublickey);
            if (targetpubrickey ==  null)
            {
                // comment:入力されたパブリックキー が適切ではありません
                var txresult = new RegistvotetargetTransactionResult();
                txresult.code = 2;
                txresult.RegistvotetargetTransactionID = string.Empty;
                txresult.result = string.Empty;
                string resultjson = JsonSerializer.Serialize(txresult);
                return resultjson;
            }
            (string transaction, string result) = await contract.InvokeContract_Registvotetarget(RegisterKeypair, Registvoteinfo.targetpublickey,Registvoteinfo.Eventname);
            var successresult = new RegistvotetargetTransactionResult();
            successresult.code = 3;
            successresult.RegistvotetargetTransactionID = transaction;
            successresult.result = result;
            string successresultjson = JsonSerializer.Serialize(successresult);
            return successresultjson;
        }

        //Distribute Votes info
        [DataContract]
        public class voteinfo
        {

            [DataMember]
            public string Voterprivatekey { get; set; }  //Replenishment vote RequestPrivateKey
            [DataMember]
            public string votetargetpublickey { get; set; } //The name of the event to attend
            [DataMember]
            public string Eventname { get; set; } //Replenishment Votes amount
            [DataMember]
            public string voteamount { get; set; } // Votes amount
        }
        //return Transaction result
        [DataContract]
        public class voteTransactionResult
        {
            [DataMember]
            public int code { get; set; }            // kind of responcecode
            [DataMember]
            public string voteTransactionID { get; set; }  //Transaction execution result ID
            [DataMember]
            public string result { get; set; } //Transaction execution result

        }
        // POST api/<SmartContractController>/getvote
        /// <summary>
        /// 
        /// </summary>
        /// <param name="replenishmentinfo"></param>
        /// <returns></returns>
        [Route("vote")]
        [HttpPost]
        public async Task<string> vote([FromBody] voteinfo voteinfo)
        {
            ContractTypesRegisterer.RegisterTypes();
            ContractService contract = new ContractService();
            KeyPair VoterKeypair = contract.GetKeyPair(voteinfo.Voterprivatekey);
            if (VoterKeypair == null)
            {
                // comment:プライベートキーが適正ではありません！
                var txresult = new voteTransactionResult();
                txresult.code = 1;
                txresult.voteTransactionID = string.Empty;
                txresult.result = string.Empty;
                string resultjson = JsonSerializer.Serialize(txresult);
                return resultjson;
            }
            var targetpubrickey = parsepublickeytype(voteinfo.votetargetpublickey);
            if (targetpubrickey == null)
            {
                // comment:入力されたパブリックキー が適切ではありません
                var txresult = new voteTransactionResult();
                txresult.code = 2;
                txresult.voteTransactionID = string.Empty;
                txresult.result = string.Empty;
                string resultjson = JsonSerializer.Serialize(txresult);
                return resultjson;
            }
            decimal checkamount = parsenumjudgement(voteinfo.voteamount);
            if(checkamount == 0m)
            {
                // comment:数値に変換できません半角数字を入力してください
                var txresult = new voteTransactionResult();
                txresult.code = 3;
                txresult.voteTransactionID = string.Empty;
                txresult.result = string.Empty;
                string resultjson = JsonSerializer.Serialize(txresult);
                return resultjson;
            }
            (string transaction, string result) = await contract.InvokeContract_Vote(VoterKeypair, voteinfo.votetargetpublickey, voteinfo.Eventname,voteinfo.voteamount);
            var successresult = new voteTransactionResult();
            successresult.code = 4;
            successresult.voteTransactionID = transaction;
            successresult.result = result;
            string successresultjson = JsonSerializer.Serialize(successresult);
            return successresultjson;
        }

        /// <summary>
        /// publickey string parse publickey
        /// </summary>
        /// <param name="text">//パブリックキー から文字列のParse</param>
        /// <returns></returns>
        private Address parsepublickeytype(string text)
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
        private decimal parsenumjudgement(string text)
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
