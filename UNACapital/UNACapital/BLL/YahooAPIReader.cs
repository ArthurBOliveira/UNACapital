using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using UNACapital.Models;
using YSQ.core.Historical;

namespace UNACapital.BLL
{
    public class YahooAPIReader
    {
        public static List<Cotation> YahooAPIRead(string action, DateTime startDate, DateTime endDate)
        {
            List<Cotation> cotations = new List<Cotation>();

            //Create the historical price service
            HistoricalPriceService historical_price_service = new HistoricalPriceService();

            //Get the historical prices
            IEnumerable<HistoricalPrice> historical_prices = historical_price_service.Get(action, startDate, endDate, Period.Daily);

            //Use the prices!
            foreach (HistoricalPrice price in historical_prices)
            {
                cotations.Add(new Cotation(price.Date, price.Price));
            }

            return cotations;
        }
    }
}