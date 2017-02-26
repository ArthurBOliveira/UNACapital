using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace UNACapital.BLL
{
    public static class Notification
    {
        public static string Send()
        {
            var request = WebRequest.Create("https://onesignal.com/api/v1/notifications") as HttpWebRequest;

            request.KeepAlive = true;
            request.Method = "POST";
            request.ContentType = "application/json; charset=utf-8";

            request.Headers.Add("authorization", "Basic OTQ3MTdiZjMtMjlkNC00OTkyLWJjMzEtZmI0NDA5MWQ2NjY1");

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            object obj = new
            {
                app_id = "b9c9c9f2-1a0f-4fd7-b472-0dc927831253",
                contents = new { en = "English Content", pt = "Conteúdo em Português" },
                headings = new { en = "English Title", pt = "Título em Português" },
                subtitle = new { en = "English Subtitle", pt = "Subtítulo em Português" },
                //url = "http://xn--aesagora-s0a4l.azurewebsites.net/home/index?currAction=PETR3&startDate=1483322400000&endDate=NaN&type=Di%C3%A1rio",
                included_segments = new string[] { "All" }
            };
            string param = serializer.Serialize(obj);
            byte[] byteArray = Encoding.UTF8.GetBytes(param);

            string responseContent = null;

            try
            {
                using (var writer = request.GetRequestStream())
                {
                    writer.Write(byteArray, 0, byteArray.Length);
                }

                using (var response = request.GetResponse() as HttpWebResponse)
                {
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        responseContent = reader.ReadToEnd();
                    }
                }
            }
            catch (WebException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                System.Diagnostics.Debug.WriteLine(new StreamReader(ex.Response.GetResponseStream()).ReadToEnd());
            }

            return responseContent;
        }
    }
}