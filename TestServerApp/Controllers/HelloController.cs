using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestServerApp.Controllers
{
    public class HelloController : Controller
    {
        // GET: Hello
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Customer_Sale_List()
        {
            return View(new POSNew12Entities().Customer_Sale.ToList());
        }
    }
}