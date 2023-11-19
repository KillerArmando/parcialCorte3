using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ParcialLenguajeInformatico.Data;
using ParcialLenguajeInformatico.Models;

namespace ParcialLenguajeInformatico.Pages.Pacientes
{
    public class DeleteModel : PageModel
    {
        private readonly ParcialContext _context;
        public DeleteModel(ParcialContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Paciente Paciente { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Paciente == null)
            {
                return NotFound();
            }
            var paciente = await _context.Paciente.FirstOrDefaultAsync(c => c.Id == id);
            if (paciente == null)
            {
                return NotFound();
            }
            else
            {
                Paciente = paciente;
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Paciente == null)
            {
                return NotFound();
            }
            var paciente = await _context.Paciente.FindAsync(id);
            if (paciente != null)
            {
                Paciente = paciente;
                _context.Paciente.Remove(paciente);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Index");
        }
    }
}