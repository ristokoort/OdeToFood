using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace OdeToFood.Controllers
{
    public class CuisineController : Controller
    {
        // [Authorize]
        public IActionResult Search(string name = "unknown")
        {
            var message = HtmlEncoder.Default.Encode(name);

            return Content(message);
            // return new EmptyResult();
            //return File("/css/site.css", "text/css");
            //return Json(HtmlEncoder.Default);
            //return Redirect("https://www.tthk.ee");
            //return RedirectToRoute("default",new {controller:"cuisine",
            //action = "Second", count=5}); 
            //return RedirectToAction(nameof(Second), new{count=5 });
            //return View("/home/index");
        }

            public IActionResult Second(int count)
        {
            return Content($"Teine on siin!{count}");
        }

        }
    }

