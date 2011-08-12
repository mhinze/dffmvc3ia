using System.Web.Mvc;
using Validation.Models;

namespace Validation.Controllers
{
    public class FunctionalTestFixturesController : Controller
    {
        public ViewResult Later()
        {
            return View(new TwoDatesModel());
        }
    }
}