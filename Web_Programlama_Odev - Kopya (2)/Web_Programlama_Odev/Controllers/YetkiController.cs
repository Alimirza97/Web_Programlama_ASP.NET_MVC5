using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_Programlama_Odev.Controllers
{
    public class YetkiController : Controller
    {
        // GET: Yetki
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if(Session["username"]==null)
            {
                filterContext.Result = new HttpNotFoundResult();
                return;
            }
            base.OnActionExecuting(filterContext);
        }
    }
}