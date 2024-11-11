using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PRY_3.Pages
{
    public class tiquete : PageModel
    {


        // Método que maneja la lógica para agregar el usuario
        public IActionResult OnPost()
        {

            return RedirectToPage("/Success");  
        }
    }
}
