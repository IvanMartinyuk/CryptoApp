using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApp.Model
{
    internal static class CoinCapParser
    {
        static HttpClient httpClient = new HttpClient();
        const string baseUrl = "https://api.coincap.io/v2/";
        const int pageSize = 10;
        static string baseAssetsUrl = $"assets?limit={pageSize}&offset=";
        static string assetsUrl;
        static string AssetsUrl 
        {
            get => assetsUrl;
            set => assetsUrl = baseAssetsUrl + value;
        }

        public static async Task<List<Currency>> GetPage(int page)
        {
            AssetsUrl = (page * pageSize).ToString();
            List<Currency> list = new List<Currency>();
            JObject obj = JsonConvert.DeserializeObject<JObject>(await SendRequset(baseUrl + AssetsUrl));
            JArray arr = (JArray)obj["data"];
            foreach (JObject el in arr)
                list.Add(new Currency() { Id = el["id"].ToString(),
                                          Name = el["name"].ToString(),
                                          PriceUsd = Convert.ToDecimal(el["priceUsd"]),
                                          Symbol = el["symbol"].ToString(),
                                          ImageUrl = $"https://assets.coincap.io/assets/icons/{el["symbol"].ToString().ToLower()}@2x.png"
                });
            //https://assets.coincap.io/assets/icons/eth@2x.png
            return list;
        }
        public static async Task<string> SendRequset(string uri)
        {
            string result = "";
            var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(uri)
            };
            using (var response = await httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                result = await response.Content.ReadAsStringAsync();
            }
            return result;
        }
    }
}