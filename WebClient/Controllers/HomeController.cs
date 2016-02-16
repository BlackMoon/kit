using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kit.Dal;
using Kit.Dal.Oracle;
using StructureMap;

namespace WebClient.Controllers
{
    public class HomeController : Controller
    {
        private IDbManager _testClass;

        public HomeController(IDbManager dbManager)
        {
            _testClass = dbManager;
        }

        public ActionResult Index()
        {
            

            IDbManager dbManager = DependencyResolver.Current.GetService<IDbManager>();

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