using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestWebService.ServiceReference1;
using Newtonsoft.Json;

namespace TestWebService
{
    /// <summary>
    /// Summary description for Rest
    /// </summary>
    public class Rest : IHttpHandler
    {
        private VMGAPISoapClient client = new ServiceReference1.VMGAPISoapClient("VMGAPISoap");
        private String username = "vmgtest1";
        private String password = "vmg123456";
        private String alias = "VMGtest";

        public void ProcessRequest(HttpContext context) {
            context.Response.ContentType = "application/json";
            //context.Response.ContentType = "text/plain";
            var method = context.Request.RequestType;

            if(method == "POST") {
                var action = context.Request.QueryString.Get("action");
                switch(action)
                {
                    case "AdsGPCSendSms":
                        AdsGPCSendSms(context);
                        break;
                    case "AdsSendSms":
                        AdsSendSms(context);
                        break;
                    case "BulkMessageBlockReciver":
                        BulkMessageBlockReciver(context);
                        break;
                    case "BulkSendSms":
                        BulkSendSms(context);
                        break;
                    case "BulkSendSmsTest":
                        BulkSendSmsTest(context);
                        break;
                    case "BulkSendSmsWithRequestId":
                        BulkSendSmsWithRequestId(context);
                        break;
                    case "getBalance":
                        getBalance(context);
                        break;

                }
            } else {
                context.Response.Write("hello");
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public void AdsGPCSendSms(HttpContext context)
        {
            //client.AdsGPCSendSms()
        }

        public void AdsSendSms(HttpContext context)
        {
            // client.getBalance
        }

        public void BulkMessageBlockReciver(HttpContext context)
        {
            // client.getBalance
        }

        public void BulkSendSms(HttpContext context)
        {
            var msisdn = context.Request.Form.Get("msisdn");
            var message = context.Request.Form.Get("message");

            var results = client.BulkSendSms(msisdn, alias, message, "", username, password);
            context.Response.Write(JsonConvert.SerializeObject(results));
        }

        public void BulkSendSmsTest(HttpContext context)
        {
            var msisdn = context.Request.Form.Get("msisdn");
            var message = context.Request.Form.Get("message");

            var results = client.BulkSendSms(msisdn, alias, message, "", username, password);
            context.Response.Write(JsonConvert.SerializeObject(results));
        }

        public void BulkSendSmsWithRequestId(HttpContext context)
        {
            // client.getBalance
        }

        public void getBalance(HttpContext context)
        {
            var results = client.getBalance(username, password);
            context.Response.Write(JsonConvert.SerializeObject(results));
        }
    }
}