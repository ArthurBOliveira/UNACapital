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
        public static List<CDI> CDIRead(int days)
        {
            List<CDI> result = new List<CDI>();

            DateTime date = DateTime.Now;

            for(int i = 0; i < days; i++)
            {
                int aux = ReadFromURL(date.ToString("yyyyMMdd"));

                if (aux != 0)
                    result.Add(new CDI(date, aux));

                date = date.AddDays(-1);
            }

            result.Reverse();

            return result;
        }

        public static List<CDI> CDIRead(DateTime startDate, DateTime endDate)
        {
            List<CDI> result = new List<CDI>();

            while(startDate <= endDate)
            {
                int aux = ReadFromURL(startDate.ToString("yyyyMMdd"));

                if (aux != 0)
                    result.Add(new CDI(startDate, aux));

                startDate = startDate.AddDays(1);
            }

            result.Reverse();

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