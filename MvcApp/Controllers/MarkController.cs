using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApp.Controllers
{
    public class MarkController : Controller
    {
        //
        // GET: /Mark/

        public ActionResult NextTest()
        {
            var next = API.AnswerController.Answers.Values.First();
            return View(next);
        }

    }
}
