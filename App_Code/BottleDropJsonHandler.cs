using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;
using System.Windows.Forms;

namespace Solum.App_Code
{
    public class BottleDropJsonHandler
    {
        private static readonly HttpClient client = new HttpClient();

        public string Response = "";

        bool result = false;

        public static string BottleDropURL = "https://app.bottledrop.ca/api/por/";

        

        private async Task<bool> SendPost(string url, Dictionary<string, string> values)
        {
            try
            {
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                       | SecurityProtocolType.Tls11
                       | SecurityProtocolType.Tls12
                       | SecurityProtocolType.Ssl3;
                var content = new FormUrlEncodedContent(values);

                var response = await client.PostAsync(url, content);

                Response = await response.Content.ReadAsStringAsync();
            }
            catch
            {
                MessageBox.Show("Could Not Connect to BottleDrop Servers", "Connection Error");
                result = false;
                return result;
            }
            result = true;
            return result;

        }
        public bool ConfirmJWT(out BottleDropJsonResponse jsonResponse)
        {
            var content = new Dictionary<string, string> { { "cmd", "verifytoken" }, { "token", Main.MainForm.BottleDropAuthorizationToken } };
            var runTask = Task.Run(() => SendPost(BottleDropURL, content));
            runTask.Wait();
            jsonResponse = new BottleDropJsonResponse();
            if (result)
            jsonResponse = JsonConvert.DeserializeObject<BottleDropJsonResponse>(Response);
            return result;
        }
        public bool GetUsers(out BottleDropJsonResponse jsonResponse)
        {
            var content = new Dictionary<string, string> { { "cmd", "getusers" } };
            var runTask = Task.Run(() => SendPost(BottleDropURL, content));
            runTask.Wait();
            jsonResponse = new BottleDropJsonResponse();
            if (result)
                jsonResponse = JsonConvert.DeserializeObject<BottleDropJsonResponse>(Response);
            return result;
        }
        public bool Login(string username, string passkey, out BottleDropJsonResponse jsonResponse)
        {
            var content = new Dictionary<string, string> { { "cmd", "login" }, { "username", username }, { "pin", passkey } };
            var runTask = Task.Run(() => SendPost(BottleDropURL, content));
            runTask.Wait();
            jsonResponse = new BottleDropJsonResponse();
            if (result)
            {
                jsonResponse = JsonConvert.DeserializeObject<BottleDropJsonResponse>(Response);
                if (jsonResponse.Verified)
                {
                    Main.MainForm.BottleDropAuthorizationToken = jsonResponse.Token;
                }
            }
            return result;
        }
        public bool VerifyLabel(string labelNumber, out BottleDropJsonResponse jsonResponse)
        {
            var content = new Dictionary<string, string> { { "cmd", "verifylabel" }, { "token", Main.MainForm.BottleDropAuthorizationToken }, { "label", labelNumber } };
            var runTask = Task.Run(() => SendPost(BottleDropURL, content));
            runTask.Wait();
            jsonResponse = new BottleDropJsonResponse();
            if (result)
            {
                jsonResponse = JsonConvert.DeserializeObject<BottleDropJsonResponse>(Response);
                if (jsonResponse.Error != "0") result = false;
            }
            return result;
        }

        public bool SaveCount(List<BottleDropOrderDetail> orderDetails, decimal orderTotal, string bagID, out BottleDropJsonResponse jsonResponse)
        {
            var content = new Dictionary<string, string> { { "cmd", "savecount" }, { "token", Main.MainForm.BottleDropAuthorizationToken }, { "bagid", bagID.ToString() }, { "bagtotal", orderTotal.ToString() }, { "json", JsonConvert.SerializeObject(orderDetails) } };
            var runTask = Task.Run(() => SendPost(BottleDropURL, content));
            runTask.Wait();
            jsonResponse = new BottleDropJsonResponse();
            if (result)
            {
                jsonResponse = JsonConvert.DeserializeObject<BottleDropJsonResponse>(Response);
                if (jsonResponse.Error != "0") result = false;
            }
            return result;
        }

        public bool ConfirmCertifiedCountingLocation()
        {
            var jres = new BottleDropJsonResponse();
            var content = new Dictionary<string, string> { { "cmd", "verifydepot" }};
            var runTask = Task.Run(() => SendPost(BottleDropURL, content));
            runTask.Wait();
            if (result)
            {
                jres = JsonConvert.DeserializeObject<BottleDropJsonResponse>(Response);
                result = jres.Verified;
            }
            return result;
        }
    }
}
