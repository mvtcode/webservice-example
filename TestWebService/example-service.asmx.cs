using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;

namespace TestWebService
{
    public class AuthHeader : SoapHeader
    {
        public string Username;
        public string Password;
    }

    /// <summary>
    /// Summary description for example_service
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class example_service : System.Web.Services.WebService
    {
        public AuthHeader Authentication;

        [WebMethod(Description = "return Hello World")]
        public string HelloWorld() {
            return "Hello World";
        }

        [WebMethod(Description = "return a + b")]
        public int Add(int a, int b) {
            return (a + b);
        }

        [WebMethod(Description = "return a - b")]
        public System.Single Subtract(System.Single A, System.Single B) {
            return (A - B);
        }

        [WebMethod(Description = "return a * b")]
        public System.Single Multiply(System.Single A, System.Single B) {
            return A * B;
        }

        [WebMethod(Description = "return a / b")]
        public System.Single Divide(System.Single A, System.Single B) {
            if (B == 0)
                return -1;
            return Convert.ToSingle(A / B);
        }

        [SoapHeader("Authentication", Required = true)]
        [WebMethod(Description = "return a + b, authentication(Username = tanmv, Password = 123456)")]
        public int AuthAdd(int a, int b)
        {
            if (Authentication.Username == "tanmv" && Authentication.Password == "123456") {
                //Do your thing
                return (a + b);

            } else {
                //if authentication fails
                return -1;
            }
        }
    }
}
