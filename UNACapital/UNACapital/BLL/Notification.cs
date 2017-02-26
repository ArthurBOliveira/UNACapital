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
        public static string Send(Models.Notification n)
        {
            var request = WebRequest.Create("https://onesignal.com/api/v1/notifications") as HttpWebRequest;

            request.KeepAlive = true;
            request.Method = "POST";
            request.ContentType = "application/json; charset=utf-8";

            request.Headers.Add("authorization", "Basic " + n.RestKey);

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            object obj = new
            {
                app_id = n.ApiKey,
                contents = new { en = "English Content", pt = n.Content },
                headings = new { en = "English Title", pt = n.Title },
                subtitle = new { en = "English Subtitle", pt = n.SubTitle },
                url = n.Url,
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
                responseContent = ex.Message;
            }

            return responseContent;
        }
    }
}