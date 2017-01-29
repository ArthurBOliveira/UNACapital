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
        public ActionResult Index()
        {
            List<CDI> CDI = CDIReader.CDIRead(5);

            IndexVM ivm = new IndexVM(CBLCReader.Read("01ABEV3"));

            return View(ivm);
        }
    }
}