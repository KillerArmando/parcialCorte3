using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ParcialLenguajeInformatico.Data;
using ParcialLenguajeInformatico.Models;

namespace ParcialLenguajeInformatico.Pages.Consultas
{
    public class EditModel : PageModel
    {
        private readonly ParcialContext _context;
        public EditModel(ParcialContext context) 
        {
            _context = context;
        }
        [BindProperty]
        public Consulta Consulta { get; set; } = default!;
        public SelectList Pacientes { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Consulta == null)
            {
                return NotFound();
            }
            var consulta = await _context.Consulta.FirstOrDefaultAsync(m => m.Id == id);
            if (consulta == null)
            {
                return NotFound();
            }
            Consulta = consulta;
            ListPacientes();
            return Page();
        }
        private void ListPacientes()
        {
            var pacientes = _context.Paciente.ToList();
            Pacientes = new SelectList(pacientes, "Id", "Name");
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ListPacientes();
                return NotFound();
            }
            _context.Attach(Consulta).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(Consulta.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }

            }
            return RedirectToPage("./Index");
        }
        private bool ProductExists(int id)
        {
            return (_context.Consulta?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}