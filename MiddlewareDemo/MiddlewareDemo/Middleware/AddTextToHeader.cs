namespace MiddlewareDemo.Middleware
{
    public class AddTextToHeader
    {
        public RequestDelegate _next;

        public AddTextToHeader(RequestDelegate requestDelegate)
        {
            _next = requestDelegate;
        }
    }
}
