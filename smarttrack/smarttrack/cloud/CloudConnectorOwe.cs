using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace smarttrack.Cloud
{
    class CloudConnectorOwe
    {
        string username;
        string password;
        string baseUrl;

        #if DEBUG
        public const string URL_DEV = "http://staging.smarttrack.co/api/";

        #endif
        public const string URL_PROD = "http://smarttrack.co/api/";

        public CloudConnectorOwe(string url = URL_DEV)
        {

        }

        internal async Task<bool> GetUserTokenAsync(User user)
        {
            using (var c = new HttpClient())
            {
                var client = new System.Net.Http.HttpClient();
                client.BaseAddress = new Uri(URL_DEV);
                var jsonRequest = new { client_id = "e6ee15809f8932272006585b07aa46d9", client_secret = "eecfb107b14d4935019e45ff02f79fac", grant_type = "client_credentials" };

                var serializedJsonRequest = JsonConvert.SerializeObject(jsonRequest);
                HttpContent content = new StringContent(serializedJsonRequest, Encoding.UTF8, ("application/json"));

                HttpResponseMessage result =  await client.PostAsync(new Uri(URL_DEV + "token"), content);

                if (result.IsSuccessStatusCode)
                {
                    var response = JsonConvert.DeserializeObject(result.Content.ReadAsStringAsync().Result);
                    App.UserToken = result.ToString();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        //modify this method to generate label
        internal async Task<bool> GenerateLabel(ShippingLabel shippingLabel)
        {
            using (var c = new HttpClient())
            {
                var client = new System.Net.Http.HttpClient();
                client.BaseAddress = new Uri(URL_DEV);
                var jsonRequest = new { client_id = "e6ee15809f8932272006585b07aa46d9", client_secret = "eecfb107b14d4935019e45ff02f79fac", grant_type = "client_credentials" };

                var serializedJsonRequest = JsonConvert.SerializeObject(jsonRequest);
                HttpContent content = new StringContent(serializedJsonRequest, Encoding.UTF8, ("application/json"));

                HttpResponseMessage result = await client.PostAsync(new Uri(URL_DEV + "token"), content);

                if (result.IsSuccessStatusCode)
                {
                    var response = JsonConvert.DeserializeObject(result.Content.ReadAsStringAsync().Result);
                    App.UserToken = result.ToString();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

    }
}
