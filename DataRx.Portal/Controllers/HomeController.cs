using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataRx.SDK.Common;
using DataRx.SDK.Model;
using DataRx.SDK.Service;

namespace DataRx.Portal.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<TaxonomyObject> taxObjs = TaxonomyObjectServiceProvider.Instance.GetCompositeModelByTNS("A2Z");





            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}