using System.Linq;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BlogManagement.Endpoints.API.Filters
{
    public class RequestFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var keys = context.ActionArguments.Keys.ToList();
            foreach (var key in keys)
            {
                var type = context.ActionArguments[key].GetType();
                if (type == typeof(string))
                {
                    context.ActionArguments[key] = NormalizeString(context.ActionArguments[key].ToString());
                }
                else
                {
                    var propList = type.GetProperties().ToList();
                    foreach (var prop in propList)
                    {
                        if (prop.PropertyType == typeof(string) && prop.CanWrite)
                            prop.SetValue(context.ActionArguments[key], NormalizeString(prop.GetValue(context.ActionArguments[key])?.ToString()));
                    }
                }
            }
        }

        private string NormalizeString(string input)
        {
            return input.Replace("ي", "ی").Replace("ك", "ک");
        }
    }
}