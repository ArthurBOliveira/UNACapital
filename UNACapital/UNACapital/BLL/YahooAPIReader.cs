using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using UNACapital.Models;

namespace UNACapital.BLL
{
    public class YahooAPIReader
    {
        public static List<Cotation> YahooAPIRead(string action, DateTime startDate, DateTime endDate)
        {
            List<Cotation> cotations = new List<Cotation>();

            string url = "http://ichart.yahoo.com/table.csv?s=" + action + "&a=" + startDate.Day.ToString() + "&b=" + startDate.Month.ToString() + "&c=" + startDate.Year.ToString() + "&d=" + endDate.Day.ToString() + "&e=" + endDate.Month.ToString() + "&f=" + endDate.Year.ToString() + "&g=d";

            try
            {
                WebRequest webRequest = WebRequest.Create(url);
                WebResponse response = webRequest.GetResponse();
                Stream content = response.GetResponseStream();
                StreamReader reader = new StreamReader(content);

                string csv = reader.ReadToEnd();
                string[] lines = Regex.Split(csv, "\r\n|\r|\n");

                DateTime date;
                float number;

                int delimiter = (int)(endDate - startDate).TotalDays;

                for (int i = 1; i <= delimiter; i++)
                {
                    string[] aux = lines[i].Split(',');

                    date = DateTime.Parse(aux[0]);
                    number = float.Parse(aux[4].Replace('.', ','));

                    cotations.Add(new Cotation(date, number));
                }
                
            }
            catch (Exception e)
            {
                
            }

            return cotations;
        }
    }
}