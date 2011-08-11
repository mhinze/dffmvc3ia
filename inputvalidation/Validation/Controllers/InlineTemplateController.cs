using System.Web.Mvc;

namespace Validation.Controllers
{
    public class InlineTemplateController : Controller
    {
         public ViewResult Index()
         {
             var model = new[] {"First", "Second", "Third", "Forth"};

             return View(model);
         }
    }
}