using System.Linq;
using System.Web.Mvc;

namespace Validation.Controllers
{
    public class ChooseUsernameModel
    {
        [Remote("IsTaken", "Username", 
            ErrorMessage = "Username is taken!")]
        public string Username { get; set; }
    }


















    public class UsernameController : Controller
    {
        public ViewResult RemoteAttribute()
        {
            return View(new ChooseUsernameModel());
        }

        public JsonResult IsTaken(string username)
        {
            bool result = !new[] {"matt", "admin", "root"}.Contains(username.ToLower());
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}