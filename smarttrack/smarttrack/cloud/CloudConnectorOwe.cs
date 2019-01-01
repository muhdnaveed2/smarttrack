using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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

                HttpResponseMessage result = await client.PostAsync(new Uri(URL_DEV + Constants.ACCESS_TOKEN_PATH), content);

                if (result.IsSuccessStatusCode)
                {
                    var response = (JObject)JsonConvert.DeserializeObject(result.Content.ReadAsStringAsync().Result);
                    App.UserToken = response["access_token"].Value<string>();
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
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "60de225c88489983f3db74f0a3cfeb2b02c3722c");




                var objShippingLabel = new ShippingLabel();
                objShippingLabel.company = "One World Express";
                objShippingLabel.contact = "One World Express";
                objShippingLabel.address_line_1 = "One World House";
                objShippingLabel.address_line_2 = "Pump lane";
                objShippingLabel.address_line_3 = "Hayes";
                objShippingLabel.city = "London";
                objShippingLabel.countryIso = "GB";
                objShippingLabel.postcode = "UB3 3NB";
                objShippingLabel.currency = "GBP";
                objShippingLabel.value = Convert.ToInt32(10.00);
                objShippingLabel.weight = Convert.ToInt32(10.500);
                objShippingLabel.serviceCode = "1H";
                objShippingLabel.number_pieces = 1;
                objShippingLabel.description = "Test";

                /*var jsonRequest = new {
                                
                                           ""    
                                      };*/

                var serializedJsonRequest = JsonConvert.SerializeObject(objShippingLabel);
                HttpContent content = new StringContent(serializedJsonRequest, Encoding.UTF8, ("application/json"));

                HttpResponseMessage result = await client.PostAsync(new Uri(URL_DEV + Constants.GENERATE_LABEL_PATH), content);

                if (result.IsSuccessStatusCode)
                {
                    var response = JsonConvert.DeserializeObject(result.Content.ReadAsStringAsync().Result);
                    App.UserToken = response.ToString();
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
