using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UNACapital.BLL;
using UNACapital.Models;
using UNACapital.ViewModels;

namespace UNACapital.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        /*public ActionResult Index()
        {
            string currAction = "01ABEV3";

            IndexVM ivm = new IndexVM(currAction, CBLCReader.Read(currAction), CDIReader.CDIRead(10));

            return View(ivm);
        }*/
        public ActionResult Index(string currAction, string type, long? startDate = null, long? endDate = null)
        {
            DateTime start, end;
            string action;

            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            if (startDate.HasValue)
                start = epoch.AddMilliseconds(startDate.Value);
            else
                start = DateTime.Now.AddMonths(-1).Date;

            if (endDate.HasValue)
                end = epoch.AddMilliseconds(endDate.Value);
            else
                end = DateTime.Now.Date;

            action = string.IsNullOrEmpty(currAction) ? "ABEV3" : currAction;
            type = string.IsNullOrEmpty(type) ? "Diário" : type;

            IndexVM ivm = new IndexVM(action, CBLCReader.Read(action), CDIReader.CDIRead(start, end), YahooAPIReader.YahooAPIRead(action, start, end, type));

            return View(ivm);
        }
    }
}