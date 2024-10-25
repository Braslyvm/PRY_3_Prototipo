using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class inicio_secionModel : PageModel {
    [BindProperty]
    public string Password { get; set; }

    [BindProperty]
    public string User { get; set; }

    public string MensajeError { get; set; }


    public bool MostrarAlerta { get; set; }

    private readonly ILogger<inicio_secionModel> _logger;

    public inicio_secionModel(ILogger<inicio_secionModel> logger)
    {
        _logger = logger;
    }

    public void OnGet() {
    }
    public IActionResult OnPost() {
        bool resultadoValidacion = Validar_acceso(User , Password);

        if (resultadoValidacion){
            return RedirectToPage("/Men/Menu");
        }
        else{
            ModelState.AddModelError(string.Empty, "Credenciales inválidas. Inténtalo de nuevo.");
            MostrarAlerta = true;
            return Page();
        }
    }

    public bool Validar_acceso (string u ,string pass) { 

        if (u == "eyden@gmail.com" && pass == "1234")
            return true;
        else if (u == "elder@gmail.com" && pass == "12345679")
            return true;
        else if (u == "brasly@gmail.com" && pass == "12345671")
            return true;
        else
            return false;

    }
    
}
