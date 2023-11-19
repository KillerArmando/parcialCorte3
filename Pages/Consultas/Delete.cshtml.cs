using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ParcialLenguajeInformatico.Data;
using ParcialLenguajeInformatico.Models;

namespace ParcialLenguajeInformatico.Pages.Consultas
{
    public class DeleteModel : PageModel
    {
        private readonly ParcialContext _context;
        public DeleteModel(ParcialContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Consulta Consulta { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Consulta == null)
            {
                return NotFound();
            }
            var consulta = await _context.Consulta.FirstOrDefaultAsync(c => c.Id == id);
            if (consulta == null)
            {
                return NotFound();
            }
            else
            {
                Consulta = consulta;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Consulta == null)
            {
                return NotFound();
            }
            var consulta = await _context.Consulta.FindAsync(id);
            if (consulta != null)
            {
                Consulta = consulta;
                _context.Consulta.Remove(consulta);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Index");
        }
    }
}