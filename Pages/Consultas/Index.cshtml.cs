using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ParcialLenguajeInformatico.Data;
using ParcialLenguajeInformatico.Models;

namespace ParcialLenguajeInformatico.Pages.Consultas
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ParcialContext _context;
        public IndexModel(ParcialContext context)
        {
            _context = context;
        }
        public IList<Consulta> consultas { get; set; }

        public async Task OnGetAsync()
        {
            if (_context.Consulta != null)
            {
                consultas = await _context.Consulta.Include(p => p.Paciente).ToListAsync();
            }
        }
    }
}
