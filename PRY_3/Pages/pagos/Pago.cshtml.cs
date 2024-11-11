using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class PagoModel : PageModel
{
    [BindProperty]
    public decimal MontoTotal { get; set; } 

    [BindProperty]
    public decimal MontoPagado { get; set; }

    [BindProperty]
    public string NumeroTarjeta { get; set; }

    [BindProperty]
    public string FechaExpiracion { get; set; }

    [BindProperty]
    public string CVV { get; set; }

    [BindProperty]
    public decimal MontoEntregado { get; set; }

    [BindProperty]
    public decimal Cambio { get; set; }

    public void OnGet(decimal montoTotal)
    {
        MontoTotal = montoTotal;
    }

    public IActionResult OnPost()
    {
        if (MontoPagado < MontoTotal)
        {
            ModelState.AddModelError("", "El monto ingresado es insuficiente.");
            return Page();
        }

        if (!string.IsNullOrEmpty(NumeroTarjeta) && (NumeroTarjeta.Length != 16 || string.IsNullOrEmpty(CVV)))
        {
            ModelState.AddModelError("", "Los datos de la tarjeta son incorrectos.");
            return Page();
        }

        if (MontoEntregado > 0)
        {
            Cambio = MontoEntregado - MontoTotal;
            if (Cambio < 0)
            {
                ModelState.AddModelError("", "El monto entregado es insuficiente.");
                return Page();
            }
        }

        return Page();
    }
}
