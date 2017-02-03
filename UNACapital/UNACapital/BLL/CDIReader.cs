using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using UNACapital.Models;

namespace UNACapital.BLL
{
    public class CDIReader
    {
        public static List<CDI> CDIRead(DateTime startDate, DateTime endDate)
        {
            List<CDI> result = new List<CDI>();

            while (startDate <= endDate)
            {
                int aux = ReadFromURL(startDate.ToString("yyyyMMdd"));

                if (aux != 0)
                    result.Add(new CDI(startDate, aux, 100));

                startDate = startDate.AddDays(1);
            }

            //result.Reverse();
            try
            {
                float max = result[0].Number;

                foreach (CDI c in result)
                {
                    c.Percentage = (float)(c.Number * 100.0 / max);
                    c.Percentage = float.Parse(c.Percentage.ToString("0.00"));
                }
            }
            catch
            {

            }

            return result;
        }

        private static int ReadFromURL(string date)
        {
            try
            {
                WebRequest webRequest = WebRequest.Create(@"ftp://ftp.cetip.com.br/IndiceDI/" + date + ".txt");
                WebResponse response = webRequest.GetResponse();
                Stream content = response.GetResponseStream();
                StreamReader reader = new StreamReader(content);

                int result = int.Parse(reader.ReadToEnd());

                return result;
            }
            catch (Exception e)
            {
                return 0;
            }
        }
    }
}