using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class inicio_secionModel : PageModel {
    [BindProperty]
    public string Password { get; set; }

    [BindProperty]
    public string User { get; set; }

    public string MensajeError { get; set; }

    private readonly ILogger<inicio_secionModel> _logger;

    public inicio_secionModel(ILogger<inicio_secionModel> logger)
    {
        _logger = logger;
    }

    public void OnGet() {
    }
    public IActionResult OnPost() {
        return RedirectToPage("/Men/Menu");
    }
    
}
