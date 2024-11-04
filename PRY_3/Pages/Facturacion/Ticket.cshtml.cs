using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Text.Json;

namespace PRY_3.Pages
{
    public class TicketModel : PageModel
    {
        public List<Producto> Productos { get; set; } = new List<Producto>();
        public decimal Total { get; set; }

        public void OnGet(string productos)
        {
            if (!string.IsNullOrEmpty(productos))
            {
                Productos = JsonSerializer.Deserialize<List<Producto>>(productos);
                Total = 0;

                foreach (var producto in Productos)
                {
                    Total += producto.Precio * producto.Cantidad;
                }
            }
        }
    }

    public class Producto
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
    }
}
