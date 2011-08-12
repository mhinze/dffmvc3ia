using System;
using System.Linq;
using System.Web.Mvc;
using Validation.Models;

namespace Validation.Controllers
{
    public class FunctionalTestRunnerController : Controller
    {
         public ViewResult Index(string test)
         {
             var models = FunctionalTestModel.All();
             if (!string.IsNullOrWhiteSpace(test))
             {
                 models = models.Where(x => string.Equals(x.TestName, test, StringComparison.OrdinalIgnoreCase));
             }
             return View(models);
         }
    }
}