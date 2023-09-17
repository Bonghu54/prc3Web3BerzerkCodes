namespace prc3Web3BerzerkCodes.Modelos
{
    public class Estudiante
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        // Otras propiedades de estudiante

        public List<Nota> Notas { get; set; } = new List<Nota>(); // Relación uno a muchos con Nota
    }

}
