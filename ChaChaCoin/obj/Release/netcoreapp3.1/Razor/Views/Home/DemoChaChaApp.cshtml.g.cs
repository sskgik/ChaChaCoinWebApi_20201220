#pragma checksum "C:\Users\sasakigaiki\Desktop\ChaChaCoin\ChaChaCoin\Views\Home\DemoChaChaApp.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2338c402e698214ada09f9dd4761c5c523d2d252"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_DemoChaChaApp), @"mvc.1.0.view", @"/Views/Home/DemoChaChaApp.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\sasakigaiki\Desktop\ChaChaCoin\ChaChaCoin\Views\_ViewImports.cshtml"
using ChaChaCoin;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\sasakigaiki\Desktop\ChaChaCoin\ChaChaCoin\Views\_ViewImports.cshtml"
using ChaChaCoin.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2338c402e698214ada09f9dd4761c5c523d2d252", @"/Views/Home/DemoChaChaApp.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bc17ffb5006abd39bef835a53eaa4f61ae6eba73", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_DemoChaChaApp : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/DemoChaChaApp.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", "~/js/DemoChaChaApp.js", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", "~/js/qrcode.min.js", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", new global::Microsoft.AspNetCore.Html.HtmlString("inputform"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/image/DemoChaCha.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("90"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("height", new global::Microsoft.AspNetCore.Html.HtmlString("90"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("ChaChaCoinの画像"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("inputform"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", new global::Microsoft.AspNetCore.Html.HtmlString("scanresult"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("swapinputform"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_12 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", new global::Microsoft.AspNetCore.Html.HtmlString("swapresult"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "C:\Users\sasakigaiki\Desktop\ChaChaCoin\ChaChaCoin\Views\Home\DemoChaChaApp.cshtml"
  
    ViewData["Title"] = "BrockChain Explorer";
    Layout = "_Layout2";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<style>
    .jumbotron {
        height: 270vh;
        margin-bottom: 60px;
        margin-top: -15px;
        background-image: url(../image/background.jpg);
        background-repeat: no-repeat;
        background-position: center;
        background-size: cover;
    }
    .Demomobilemanualbtn {
        width: 330px;
        height: 60px;
        background-color: yellow;
        color: black;
        margin-left:-15px;
        margin-bottom:20px;
        border-radius: 10px;
        border: none;
        font-size:  1.3em;
    }
    /*キーペア発行読み出し画面*/
    .ChaChaMobileDemotext {
        background-color: black;
        position: relative;
        width: 330px;
        height: 400px;
        margin-left: -15px;
        margin-bottom: 40px;
    }
    .input1 {
        color: yellow;
        line-height: 10px;
        font-size: 125%;
    }

    .keyinfo {
        position: absolute;
        top: 10px;
        left: 5px;
    }

    #registnametext {
        width:");
            WriteLiteral(@" 320px;
        height: 30px;
        border-radius: 5px;
        font-size: 100%;
    }

    #privatekeytext {
        width: 320px;
        height: 60px;
        border-radius: 5px;
        font-size: 100%;
    }

    #publickeytext {
        width: 320px;
        height: 60px;
        border-radius: 5px;
        font-size: 100%;
    }
    .button1 {
        position: absolute;
        width: 100%;
        left: 0px;
        top: 260px;
        text-align: center;
    }
    #Generatebutton {
        position: relative;
        width:  250px;
        height: 55px;
        font-size: 1.3em;
        font-weight: bold;
        margin-left: auto;
        background-color: white;
        text-align: center;
        border: none;
        border-radius: 10px;
        margin-bottom:10px;
    }
    #Readbutton {
        position: relative;
        width: 250px;
        height: 55px;
        font-size: 1.3em;
        font-weight: bold;
        margin-left: auto;
        ba");
            WriteLiteral(@"ckground-color: greenyellow;
        text-align: center;
        border: none;
        border-radius: 10px;
    }
    .QRbutton {
        position: absolute;
        left: 10px;
        bottom: 90px;
        width: 171px;
        height: 60px;
        font-size: 1.2em;
        font-weight: bold;
        padding: 10px 5px;
        background-color: greenyellow;
        text-align: center;
        border: none;
        border-radius: 10px;
    }
    #lergeqr {
        position: relative;
        width: 280px;
        height: 280px;
        top: 50%;
        left: 50%;
        -webkit-transform: translate(-50%,-50%);
        transform: translate(-50%,-50%);
        border: 5px solid;
        border-color: white;
    }
    /*Swap Flame*/
    .ChaChaMobileSwapDemo {
        background-color: black;
        position: relative;
        margin-left: 2px;
        margin-bottom: 20px;
        width: 330px;
        height: 600px;
    }

    #swapdeistinationTable {
        width:");
            WriteLiteral(@" 320px;
        height: 30px;
        border-radius: 5px;
        font-size: 100%;
    }
    #swapdeistination {
        width: 320px;
        height: 70px;
        border-radius: 5px;
        font-size: 100%;
    }
    #swapamount1 {
        width: 320px;
        height: 30px;
        border-radius: 5px;
        font-size: 100%;
    }

    .forswapbutton {
        position: absolute;
        width: 100%;
        left: 0px;
        top: 340px;
        text-align: center;
    }
    #swapbutton {
        position: relative;
        width: 145px;
        height: 45px;
        font-size: 1em;
        font-weight: bold;
        margin-right: auto;
        background-color: greenyellow;
        text-align: center;
        border: none;
        border-radius: 10px;
    }

    .swaptransaction {
        position: absolute;
        color: white;
        top: 400px;
        left: 5px;
        font-size: 120%;
    }

    #swaprecent {
        position: absolute;
        co");
            WriteLiteral("lor: white;\r\n        top: 430px;\r\n        left: 5px;\r\n        font-size: 115%;\r\n        text-align: left;\r\n    }\r\n</style>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "2338c402e698214ada09f9dd4761c5c523d2d25212597", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2338c402e698214ada09f9dd4761c5c523d2d25213712", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.Src = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
#nullable restore
#line 196 "C:\Users\sasakigaiki\Desktop\ChaChaCoin\ChaChaCoin\Views\Home\DemoChaChaApp.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion = true;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2338c402e698214ada09f9dd4761c5c523d2d25215599", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.Src = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
#nullable restore
#line 197 "C:\Users\sasakigaiki\Desktop\ChaChaCoin\ChaChaCoin\Views\Home\DemoChaChaApp.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion = true;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
<script src=""https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js""></script>
<script src=""https://dmla.github.io/jsqrcode/src/qr_packed.js""></script>

<!--Page Layout-->
<input class=""Demomobilemanualbtn"" type=""button"" onclick=""location.href='https://chal-convenience-info.net/demo-chacha/'"" value=""デモチャチャ&nbsp;マニュアルへ"">
<div class=""ChaChaMobileDemotext"">
    <div class=""keyinfo"">
        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2338c402e698214ada09f9dd4761c5c523d2d25217909", async() => {
                WriteLiteral(@"
           <p class=""input1"">Regist Name(pkcs12_file Name)</p>
           <textarea id=""registnametext"" type=""text"" name=""registname"" placeholder=""Regist Name""></textarea>
           <p class=""input1"">PrivateKey</p>
           <textarea id=""privatekeytext"" type=""text"" name=""MyPrivateKey"" placeholder=""Your PrivateKey"" readonly></textarea>
           <p class=""input1"">PublicKey</p>
           <textarea id=""publickeytext"" type=""text"" name=""MyPublicKey"" placeholder=""Your PublicKey"" readonly></textarea>
        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
    </div>
    <div class=""button1"">
       <input id=""Generatebutton"" type=""button"" onclick=""getkeypair()"" value=""キーペア発行"">
       <input id=""Readbutton"" type=""button"" onclick=""Readkeypair()"" value=""キーペア読み出し"">
    </div>
</div>
<div class=""Demoimage"">
    <div class=""ChaChaMobileDemo"">
        <div class=""Balance"">
            <button class=""balancebutton"" type=""button"" onclick=""get_balance()"" name=""qrreaderbottun"">
                <p class=""content1"">Your_Balance</p>
                <p class=""content2"" id=""content2"">&nbsp;</p>
                <p class=""content1"">ChaChaCoin</p>
            </button>
        </div>
        <div class=""ChaChaCoin"">
            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "2338c402e698214ada09f9dd4761c5c523d2d25220495", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n        <!--入力フォーム-->\r\n        <div class=\"sendinfomation\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2338c402e698214ada09f9dd4761c5c523d2d25221873", async() => {
                WriteLiteral(@"
                <p class=""input"">送金先</p>
                <textarea id=""deistination"" type=""text"" name=""Destinationpubkey"" placeholder=""Destination PublicKey""></textarea><label class=qrcode-text-btn><input class=""accesscamera"" type=file accept=""image/*"" capture=environment onchange=""openQRCamera(this);"" tabindex=""-1""></label>
                <p class=""input"">送金枚数</p>
                <textarea id=""amount1"" type=""text"" name=""Amount"" placeholder=""amount""></textarea>
            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
        </div>
        <!--各種button-->
        <div class=""button"">
            <input id=""clearbutton"" type=""button"" onclick=""clearinput()"" value=""Clear Input(消去)"">
            <input id=""sendbutton"" type=""button"" onclick=""send()"" value=""Send(送金)"">
        </div>
        <!--Reacent transaction-->
        <p class=""showtransaction"">Recent&nbsp;&nbsp;Transaction</p>
        <!--Recrnt Table-->
        <table id=""recent"">
            <tbody id=""recentTable"">
                <tr>
                    <td id=""date"">Send_Date</td>
                    <td id=""amount"">Amount</td>
                </tr>
            </tbody>
        </table>
    </div>
    <!--Swap Flame-->
    <div class=""ChaChaMobileSwapDemo"">
        <div class=""Balance"">
            <button class=""balancebutton"" type=""button"" onclick=""get_balance()"" name=""qrreaderbottun"">
                <p class=""content1"">Your_Balance</p>
                <p class=""content2"" id=""content3"">&nbsp;</p>
                <p class=""content1"">Cha");
            WriteLiteral("ChaCoin</p>\r\n            </button>\r\n        </div>\r\n        <div class=\"ChaChaCoin\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "2338c402e698214ada09f9dd4761c5c523d2d25224990", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n        <!--入力フォーム-->\r\n        <div class=\"sendinfomation\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2338c402e698214ada09f9dd4761c5c523d2d25226368", async() => {
                WriteLiteral(@"
                <p class=""input"">スワップ先コイン</p>
                <textarea id=""swapdeistinationTable"" type=""text"" name=""SwapDestinationTable"" placeholder=""Destination PublicKey"">SAKURAcoin</textarea>
                <p class=""input"">スワップアドレス</p>
                <textarea id=""swapdeistination"" type=""text"" name=""SwapDestinationpubkey"" placeholder=""Swqp Destination PublicKey"" readonly></textarea>
                <p class=""input"">スワップ枚数</p>
                <textarea id=""swapamount1"" type=""text"" name=""SwapAmount"" placeholder=""amount""></textarea>
            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_11);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_12);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
        </div>
        <!--各種button-->
        <div class=""forswapbutton"">
            <input id=""clearbutton"" type=""button"" onclick=""clearSwapinput()"" value=""Clear Input(消去)"">
            <input id=""swapbutton"" type=""button"" onclick=""Swap()"" value=""Swap(交換)"">
        </div>
        <!--Reacent transaction-->
        <p class=""swaptransaction"">Recent&nbsp;Swap&nbsp;Transaction</p>
        <!--Recrnt Table-->
        <table id=""swaprecent"">
            <tbody id=""swaprecentTable"">
                <tr>
                    <td id=""date"">Swap_Date</td>
                    <td id=""amount"">Swap_Amount</td>
                </tr>
            </tbody>
        </table>
    </div>
    <!--largeQR image-->
    <div class=""ChaChaMobileDemoQR"">
        <div class=""ChaChaCoin"">
            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "2338c402e698214ada09f9dd4761c5c523d2d25229197", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n\r\n        <div id=\"lergeqr\"></div>\r\n        <input class=\"storageclear\" type=\"button\" onclick=\"localclear()\" value=\"ローカルクリア\">\r\n        <button class=\"QRbutton\" type=\"button\" onclick=\"lergeQR()\" name=\"QR\">QR作成</button>\r\n    </div>\r\n</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591