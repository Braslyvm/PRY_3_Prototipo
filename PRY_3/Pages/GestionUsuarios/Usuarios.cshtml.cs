using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PRY_3.Pages
{
    public class UsuariosModel : PageModel
    {
        public List<User> users { get; set; } = new List<User>();

        [BindProperty]
        public User NewUser { get; set; } = new User();

        public async Task<IActionResult> OnGetAsync()
        {
            getusuarios();
            return Page();
        }

        public IActionResult OnPostBorrar(int cedula){
            borrar(cedula);
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
                if (values.Length == 4)
                {
                    users.Add(new User
                    {
                        Cedula = int.Parse(values[0]),
                        UserName = values[1],
                        Email = values[2],
                        Role = values[3]
                    });
                }
            }
        }
    }

    public class User
    {
        public int Cedula { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
