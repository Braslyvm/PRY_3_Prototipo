using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PRY_3.Pages
{
    public class AgregaModel : PageModel
    {
        [BindProperty]
        public string Cedula { get; set; }
        [BindProperty]
        public string Nombre { get; set; }
        [BindProperty]
        public string Apellido_1 { get; set; }
        [BindProperty]
        public string Apellido_2 { get; set; }
        [BindProperty]
        public string Sexo { get; set; }
        [BindProperty]
        public string Lugar_Recidencia { get; set; }
        [BindProperty]
        public string Role { get; set; }
        [BindProperty]
        public string Estado { get; set; }
        [BindProperty]
        public string Correo { get; set; }
        [BindProperty]
        public string Contrasena { get; set; }

        // Método que maneja la lógica para agregar el usuario
        public IActionResult OnPost()
        {
            // Aquí iría la lógica para agregar el usuario a la base de datos, por ejemplo.
            // Por ahora, simplemente redirigimos a otra página.

            // Agregar lógica de almacenamiento, como agregar a la base de datos

            // Redirige a la página de éxito o a la página deseada después de procesar los datos
            return RedirectToPage("/Success");  // Cambia "/Success" a la página a la que quieras redirigir
        }
    }
}
