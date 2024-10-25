using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PRY_3.Pages;

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

