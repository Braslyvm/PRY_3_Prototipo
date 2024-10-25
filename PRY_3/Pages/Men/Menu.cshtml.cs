using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace PRY_3.Pages
{
    public class MenuModel : PageModel
    {
        private readonly ILogger<MenuModel> _logger;

        public MenuModel(ILogger<MenuModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
           
        }
    }
}
