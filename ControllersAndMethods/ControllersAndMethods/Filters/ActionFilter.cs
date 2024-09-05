using Microsoft.AspNetCore.Mvc.Filters;

namespace ControllersAndMethods.Filters
{
    public class ActionFilter : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("NotImplementedException");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("NotImplementedException");   
        }
    }
}
