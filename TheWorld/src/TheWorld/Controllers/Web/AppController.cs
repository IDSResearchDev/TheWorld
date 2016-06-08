using System;
using System.ComponentModel.Design;

namespace TheWorld.Controllers.Web
{

    public class AppController
    {
        public IActionResult Index()
        {
            return View();
        }
    }


}
