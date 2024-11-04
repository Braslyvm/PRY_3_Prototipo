using System;
using System.Collections.Generic;
using System.Linq;

namespace Facturacion
{
    public class Producto
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; } = 1;
    }

    public class FacturacionApp
    { 
        public List<Producto> factura { get; set; }
        private List<Producto> productos;

        public FacturacionApp()
        {
           
            productos = new List<Producto>
            {
                new Producto { Codigo = "001", Nombre = "Manzana", Tipo = "Fruta", Precio = 0.5m },
                new Producto { Codigo = "002", Nombre = "Pan", Tipo = "Panadería", Precio = 1.0m },
                new Producto { Codigo = "003", Nombre = "Leche", Tipo = "Lácteos", Precio = 1.2m },
                 new Producto { Codigo = "004", Nombre = "Cafe", Tipo = "Fruta", Precio = 1.2m }
                 
            };
            factura = new List<Producto>();  // Inicializa la lista de productos en la factura
        }

        // Agregar un producto a la factura
        public string AgregarProducto(string nombre)
        {
            var producto = productos.FirstOrDefault(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
            if (producto != null)
            {
                factura.Add(producto);
                return $"{producto.Nombre} agregado a la factura.";
            }
            else
            {
                return "Producto no encontrado.";
            }
        }

        // Eliminar un producto de la factura
        public string EliminarProducto(string nombre)
        {
            var producto = factura.FirstOrDefault(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
            if (producto != null)
            {
                factura.Remove(producto);
                return $"{producto.Nombre} eliminado de la factura.";
            }
            else
            {
                return "Producto no encontrado en la factura.";
            }
        }

        // Modificar la cantidad de un producto en la factura
        public string ModificarCantidad(string nombre, int cantidad)
        {
            var producto = factura.FirstOrDefault(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
            if (producto != null)
            {
                producto.Cantidad = cantidad;
                return $"Cantidad de {producto.Nombre} actualizada a {cantidad}.";
            }
            else
            {
                return "Producto no encontrado en la factura.";
            }
        }

        // Calcular el total y finalizar la factura
        public decimal FinalizarFactura()
        {
            decimal total = factura.Sum(p => p.Precio * p.Cantidad);
            factura.Clear();  // Limpia la factura después de finalizar
            return total;
        }
    }
}
