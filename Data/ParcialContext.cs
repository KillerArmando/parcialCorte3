using Microsoft.EntityFrameworkCore;
using ParcialLenguajeInformatico.Models;

namespace ParcialLenguajeInformatico.Data
{
    public class ParcialContext : DbContext
    {
        public ParcialContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Consulta> Consulta { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ParcialDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
    }
}
