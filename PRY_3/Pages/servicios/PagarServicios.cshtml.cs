using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TuNamespace
{
    public class PagarServiciosModel : PageModel
    {
        [BindProperty]
        public string Servicio { get; set; }
        [BindProperty]
        public string MetodoPago { get; set; }
        [BindProperty]
        public string NumeroCuenta { get; set; }
        [BindProperty]
        public string CodigoCliente { get; set; }
        [BindProperty]
        public string NumeroRecibo { get; set; }
        [BindProperty]
        public string NumeroTelefono { get; set; }

        public void OnGet()
        {
            // Método para cargar la página inicialmente
        }

        public IActionResult OnPost()
        {
            // Validar y procesar el pago
            if (ModelState.IsValid)
            {
                // Conectar con el Banco de Costa Rica y procesar el pago
                // Simulación de respuesta
                bool pagoExitoso = true; // Esto debe ser el resultado real de la operación

                if (pagoExitoso)
                {
                    // Lógica para confirmar el pago y registrar en el sistema
                    return RedirectToPage("PagoExitoso"); // Página de éxito
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "El pago fue rechazado. Intente nuevamente.");
                }
            }

            return Page();
        }
    }
}
