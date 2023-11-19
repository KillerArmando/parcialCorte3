using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ParcialLenguajeInformatico.Data;
using ParcialLenguajeInformatico.Models;

namespace ParcialLenguajeInformatico.Pages.Pacientes
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
            return Page();
        }

        [BindProperty]
        public Paciente Paciente { get; set; } = default!;

        public async Task<ActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Paciente == null || Paciente == null)
            {
                return Page();
            }
            _context.Paciente.Add(Paciente);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }

    }
}
