using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ParcialLenguajeInformatico.Data;
using ParcialLenguajeInformatico.Models;

namespace ParcialLenguajeInformatico.Pages.Consultas
{
    public class CreateModel : PageModel
    {
        private readonly ParcialContext _context; 
        public CreateModel(ParcialContext context)
        {
            _context = context;
        }
        public IActionResult OnGet()
        {
            ListarPacientes();
            return Page();
        }

        [BindProperty]
        public Consulta consulta { get; set; } = default!;

        public SelectList ListaPacientes { get; set; }

        private void ListarPacientes()
        {
            var pacientes = _context.Paciente.ToList();
            ListaPacientes = new SelectList(pacientes, "Id", "Name");
        }
        public async Task<ActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Consulta == null || consulta == null)
            {
                ListarPacientes();
                return Page();
            }
            _context.Consulta.Add(consulta);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
