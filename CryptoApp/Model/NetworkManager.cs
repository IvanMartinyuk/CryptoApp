using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoApp.Model
{
    internal static class NetworkManager
    {
        static HttpClient httpClient = new HttpClient();
        const string baseUrl = "https://api.coincap.io/v2/";
        const int pageSize = 10;
        static string baseAssetsUrl = $"assets?limit={pageSize}&offset=";
        static string assetsUrl;
        static string searchListUrl = "https://api.coingecko.com/api/v3/search?query=";
        static string AssetsUrl 
        {
            get => assetsUrl;
            set => assetsUrl = baseAssetsUrl + value;
        }

        public static async Task<List<Currency>> GetPage(int page)
        {
            AssetsUrl = (page * pageSize).ToString();
            List<Currency> list = new List<Currency>();
            JObject obj = JsonConvert.DeserializeObject<JObject>(await SendRequest(baseUrl + AssetsUrl));
            JArray arr = (JArray)obj["data"];
            foreach (JObject el in arr)
                list.Add(FillCurrency(el));
            return list;
        }
        public static async Task<List<Currency>> Searching(string parametr)
        {
            List<Currency> list = new List<Currency>();
            JObject data = JsonConvert.DeserializeObject<JObject>(await SendRequest(searchListUrl + parametr));
            JArray arr = (JArray)data["coins"];
            int end = arr.Count > 10 ? 10 : arr.Count;
            for (int i = 0; i < end; i++)
            {
                try
                {
                    JObject cur = JsonConvert.DeserializeObject<JObject>
                                (await SendRequest(baseUrl + "assets/" + arr[i]["id"].ToString()));
                    if (cur != null)
                    {
                        cur = (JObject)cur["data"];
                        list.Add(FillCurrency(cur));
                    }
                }
                catch { }
            }
            return list;
        }
        private static Currency FillCurrency(JObject cur)
        {
            Currency currency = new Currency()
            {
                Id = cur["id"].ToString(),
                Name = cur["name"].ToString(),
                PriceUsd = Convert.ToDouble(cur["priceUsd"]),
                Symbol = cur["symbol"].ToString(),
                ImageUrl = $"https://assets.coincap.io/assets/icons/{cur["symbol"].ToString().ToLower()}@2x.png",
                PriceChangePercent = Convert.ToDouble(cur["changePercent24Hr"]),
                Volume = Convert.ToDouble(cur["volumeUsd24Hr"]),
                MarketURL = "https://www.blockchain.com/explorer/assets/" + cur["symbol"].ToString()
            };
            return currency;
        }
        public static async Task<string> SendRequest(string uri)
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