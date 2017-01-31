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
        public ActionResult Index(string currAction, DateTime? startDate = null, DateTime? endDate = null)
        {
            DateTime start, end;
            string action;

            start = startDate.HasValue ? startDate.Value : DateTime.Now.AddDays(-5);
            end = endDate.HasValue ? endDate.Value : DateTime.Now;

            action = string.IsNullOrEmpty(currAction) ? "01ABEV3" : currAction;

            IndexVM ivm = new IndexVM(action, CBLCReader.Read(action), CDIReader.CDIRead(start, end), YahooAPIReader.YahooAPIRead(currAction, start, end));

            return View(ivm);
        }
    }
}