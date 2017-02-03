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
        public static List<Cotation> YahooAPIRead(string action, DateTime startDate, DateTime endDate, string type)
        {
            List<Cotation> cotations = new List<Cotation>();

            action = action + ".SA";

            type = type == "Diário" ? "d" : "w";

            string url = "http://ichart.yahoo.com/table.csv?s=" + action + "&g=" + type;

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

                for (int i = 1; i <= delimiter+1; i++)
                {
                    string[] aux = lines[i].Split(',');

                    date = DateTime.Parse(aux[0]);
                    number = float.Parse(aux[4].Replace('.', ','));

                    if (date >= startDate)
                    {
                        if (date <= endDate)
                            cotations.Add(new Cotation(date, number, 100));
                    }
                    else
                        break;
                }

                cotations.Reverse();

                float max = cotations[0].Number;

                foreach(Cotation c in cotations)
                {
                    c.Percentage = (float)(c.Number * 100.0 / max);
                    c.Percentage = float.Parse(c.Percentage.ToString("0.00"));
                }
            }
            catch (Exception e)
            {
                
            }            

            return cotations;
        }
    }
}