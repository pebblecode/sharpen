using System.Web.Mvc;

namespace MvcApp.Controllers
{
    public class TestController : Controller
    {
        private readonly API.TestController api = new API.TestController();
        //
        // GET: /Test/

        public ActionResult Send()
        {
            return View(api.Get());
        }

    }
}
