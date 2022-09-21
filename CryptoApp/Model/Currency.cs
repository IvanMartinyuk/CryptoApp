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
        public double priceUsd;
        public double PriceUsd 
        {
            get => priceUsd;
            set => priceUsd = Math.Round(value, 2);
        }
        public double volume;
        public double Volume
        {
            get => volume;
            set => volume = Math.Round(value, 2);
        }
        public double priceChangePercent;
        public double PriceChangePercent
        {
            get => priceChangePercent;
            set => priceChangePercent = Math.Round(value, 2);
        }
        public string MarketURL { get; set; }
}
}
