using System.Security.Cryptography.Xml;

namespace prc3Web3BerzerkCodes.Modelos
{
    public class Nota
    {
        public int Id { get; set; }
        public decimal Nota1 { get; set; }
        public decimal Nota2 { get; set; }
        public decimal ExFin { get; set; }
        public decimal NotaFinal { get; set; }
        // Otras propiedades de nota

        public int EstudianteId { get; set; } // Clave foránea a Estudiante
        public Estudiante Estudiante { get; set; } // Propiedad de navegación a Estudiante

        public int AsignaturaId { get; set; } // Clave foránea a Asignatura
        public Asignatura Asignatura { get; set; } // Propiedad de navegación a Asignatura
    }

}
