using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApp.Model
{
    [Serializable]
    internal class Currency
    {
        public string Id { get; set; }
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public decimal PriceUsd { get; set; }
    }
}
