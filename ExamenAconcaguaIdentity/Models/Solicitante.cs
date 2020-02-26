using ExamenAconcagua.Models.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExamenAconcagua.Models
{
    public class Solicitante : EntityBase, IPersona
    {
        [Required]
        public string Dni { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string PrimerApellido { get; set; }
        [Required]
        public string SegundoApellido { get; set; }
        public string TelefonoFijo { get; set; }
        public string TelefonoMovil { get; set; }
        public ICollection<Prestamo> Prestamos = new HashSet<Prestamo>();
    }   

}
