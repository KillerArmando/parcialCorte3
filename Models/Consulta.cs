namespace ParcialLenguajeInformatico.Models
{
    public class Consulta
    {
        public int Id { get; set; }
        public string NombreConsulta { get; set; }
        public DateTime Fecha { get; set; }
        public string NombreMedico { get; set; }
        public string Observacion { get; set; }
        public int PacienteId { get; set; }
        public Paciente? Paciente { get; set; }
    }
}
