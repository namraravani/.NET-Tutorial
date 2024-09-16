using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SeriLoggingDemo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            _logger.LogInformation("You requested the index page");

            try
            {
                for (int i = 0; i < 100; i++) {
                    if(i==56)
                    {
                        throw new Exception("This is our demp exception");
                    }
                }
            }
            catch (Exception ex) {
                _logger.LogError(ex, "We Caught this exception");
            }
        }
    }
}
