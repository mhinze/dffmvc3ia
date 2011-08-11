using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace Validation.Controllers
{
    public class ChooseValidUsernameModel
    {
        [ClientValidUsername]
        [Remote("IsTaken", "Username", ErrorMessage = "Username is taken!")]
        public string Username { get; set; }
    }

    public class ClientUsernameController : Controller
    {
        [HttpGet]
        public ViewResult ValidUsername()
        {
            return View(new ChooseValidUsernameModel());
        }

        [HttpPost]
        public ActionResult ValidUsername(ChooseValidUsernameModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            return RedirectToAction("Valid", new {username = model.Username});
        }

        public ViewResult Valid(string username)
        {
            return View(username as object);
        }
    }

    public class ValidUsernameAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return (string) value == Regex.Replace(value.ToString(), "[^a-zA-Z]", string.Empty);
        }
    }

    public class ClientValidUsernameAttribute : ValidUsernameAttribute, IClientValidatable
    {
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule
            {
                ErrorMessage = "Invalid username (client)",
                ValidationType = "username",
            };

            yield return rule;
        }
    }



}