using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class inicio_secionModel : PageModel {
    [BindProperty]
    public string Contraseña { get; set; }

    [BindProperty]
    public string correo { get; set; }

    public string MensajeError { get; set; }


    

    private readonly ILogger<inicio_secionModel> _logger;

    public inicio_secionModel(ILogger<inicio_secionModel> logger)
    {
        _logger = logger;
    }

    public void OnGet() {
    }
    public IActionResult OnPost() {
        bool resultadoValidacion = Validar_acceso(correo , Contraseña);

        if (resultadoValidacion){
            return RedirectToPage("/Men/Menu");
        }
        else{
            ModelState.AddModelError(string.Empty, "Credenciales inválidas. Inténtalo de nuevo.");
            return Page();
        }
    }

    public bool Validar_acceso (string correo1 ,string Contraseña1) { 

        if (correo1 == "eyden@gmail.com" && Contraseña1 == "12345678")
            return true;
        else if (correo1 == "elder@gmail.com" && Contraseña1 == "12345679")
            return true;
        else if (correo1 == "brasly@gmail.com" && Contraseña1 == "12345671")
            return true;
        else
            return false;

    }
}
