using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using UNACapital.Models;

namespace UNACapital.BLL
{
    public class CBLCReader
    {
        public static CBLC Read(string actionId)
        {
            CBLC result;

            result = new CBLC(ReadFromURL(actionId), actionId);

            return result;
        }

        private static string ReadFromURL(string actionId)
        {
            WebRequest webRequest = WebRequest.Create(@"http://www.cblc.com.br/cblc/consultas/Arquivos/DBTCER9999.txt");
            WebResponse response = webRequest.GetResponse();
            Stream content = response.GetResponseStream();
            StreamReader reader = new StreamReader(content);

            return reader.ReadToEnd();
        }
    }
}