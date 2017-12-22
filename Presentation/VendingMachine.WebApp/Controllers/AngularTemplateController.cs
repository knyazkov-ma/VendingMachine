using System.Collections.Generic;
using System.Web.Mvc;
using VendingMachine.WebApp.Resources;

namespace VendingMachine.WebApp.Controllers
{
        
    public class AngularTemplateController : Controller
    {
       
        #region Layout
        
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Menu = new Dictionary<string, string>()
                {
                    { "order", Resource.Menu_Order }
                };

            return View("~/App/Main/views/layout/layout.cshtml");
        }
        #region layout

        

        [HttpGet]
        public ActionResult Header()
        {
            return PartialView("~/App/Main/views/layout/header.cshtml");
        }

        #endregion layout
        #endregion Layout

        #region Order
        [HttpGet]
        public ActionResult Order()
        {
            return PartialView("~/App/Main/views/order/order.cshtml");
        }

        #endregion Order


    }
}