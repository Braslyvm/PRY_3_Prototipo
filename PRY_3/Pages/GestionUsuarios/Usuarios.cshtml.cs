using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace PRY_3.Pages
{
    public class UsuariosModel : PageModel
    {
        public List<User> users { get; set; } = new List<User>();

        [BindProperty]
        public User NewUser { get; set; } = new User();
        public string Role { get; set; }
        public string Estado { get; set; }
        public string Sexo { get; set; }

        public async Task<IActionResult> OnGetAsync(){
            getusuarios();
            return Page();
        }

        public IActionResult OnPostBorrar(int cedula){
            borrar(cedula);
            return RedirectToPage();
        }

        public IActionResult OnPostModificar(int cedula, string userName, string apellido_1, string apellido_2, string sexo, string lugar_Recidencia, string estado, string rol, string correo){ 
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "usuarios.txt");
            var lines = System.IO.File.ReadAllLines(filePath);
            var updatedLines = new List<string>();
            foreach (var line in lines)
            {
                var values = line.Split(',');
                if (values.Length == 9 && int.Parse(values[0]) == cedula){
                    updatedLines.Add($"{cedula},{userName},{apellido_1},{apellido_2},{sexo},{lugar_Recidencia},{rol},{estado},{correo}");
                }
                else{
                    updatedLines.Add(line);
                }
            }
            System.IO.File.WriteAllLines(filePath, updatedLines);

            // Redirigir a la página actual después de la actualización
            return RedirectToPage();
        }
        public void borrar(int cedula){
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "usuarios.txt");
            var lines = System.IO.File.ReadAllLines(filePath);
            var updatedLines = lines.Where(line => 
            {
                var values = line.Split(',');
                return values.Length > 0 && int.Parse(values[0]) != cedula; 
            }).ToArray();
            System.IO.File.WriteAllLines(filePath, updatedLines);
        }

        public void getusuarios()
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "usuarios.txt");
            var lines = System.IO.File.ReadAllLines(filePath);
            users.Clear();
            foreach (var line in lines)
            {
                var values = line.Split(',');
                if (values.Length == 9)
                {
                    users.Add(new User{
                        Cedula = int.Parse(values[0]),
                        UserName = values[1],
                        Apellido_1 = values[2],
                        Apellido_2 = values[3],
                        Sexo = values[4],
                        Lugar_Recidencia = values[5],
                        Role = values[6],
                        Estado = values[7],
                        correo = values[8]
                        
                    });
                }
            }
        }
    }

    public class User
    {
        public int Cedula { get; set; }
        public string UserName { get; set; }
        public string Apellido_1 { get; set; }
        public string Apellido_2 { get; set; }
        public string Sexo { get; set; }
        public string Lugar_Recidencia { get; set; }
        public string Role { get; set; }
        public string Estado { get; set; }
        public string correo { get; set; }
    }
}
