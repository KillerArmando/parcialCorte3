using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ParcialLenguajeInformatico.Data;
using ParcialLenguajeInformatico.Models;

namespace ParcialLenguajeInformatico.Pages.Pacientes
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ParcialContext _context;
        public IndexModel (ParcialContext context)
        {
            _context = context;
        }
        public IList<Paciente> Pacientes { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Paciente != null)
            {
                Pacientes = await _context.Paciente.ToListAsync();
            }
        }
    }
}
