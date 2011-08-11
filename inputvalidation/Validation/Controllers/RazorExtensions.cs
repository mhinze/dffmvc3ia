using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.WebPages;

namespace Validation.Controllers
{
    public static class RazorExtensions
    {
        public static HelperResult TemplatedJoin<T>(
            this IEnumerable<T>items, 
            Func<T, HelperResult> template, 
            string separator)
        {
            return new HelperResult(
                writer =>
                    {
                        var array = items.Select(item => template(item).ToString()).ToArray();
                        var result = string.Join(separator, array);
                        writer.Write(result);
                    }
                );
        }
    }
}