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
            IndexVM ivm = new IndexVM(CBLCReader.Read("01ABEV3"), CDIReader.CDIRead(10));

            return View(ivm);
        }
    }
}