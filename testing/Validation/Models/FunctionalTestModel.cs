using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using Validation.Controllers;

namespace Validation.Models
{
    public class FunctionalTestModel
    {
        public string TestName { get; set; }
        public string ControllerName { get; set; }

        public static IEnumerable<FunctionalTestModel> All()
        {
            Type type = typeof(FunctionalTestFixturesController);
            var models = type
                .GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public)
                .Where(x => x.ReturnType == typeof (ViewResult))
                .Select(x => new FunctionalTestModel {ControllerName = type.Name.Replace("Controller", ""), TestName = x.Name});
            return models;
        }
    }
}