namespace ParcialLenguajeInformatico.Models
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int edad { get; set; }
        public string TipoDocumento { get; set; }
        public int NroDocumento { get; set; }
        public long Contacto { get; set; }
        public ICollection<Consulta>? Consultas { get; set; }
    }
}
