using Microsoft.AspNetCore.Mvc.Filters;

namespace ControllersAndMethods.Filters
{
    public class ResourceFilter : Attribute,IResourceFilter
    {
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            Console.WriteLine("NotImplementedException"); 
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            Console.WriteLine("NotImplementedException");
        }
    }
}
