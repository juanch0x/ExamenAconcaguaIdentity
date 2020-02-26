using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ExamenAconcagua.ViewModels.Solicitante
{
    public class NuevoSolicitanteViewModel
    {
        [Required]
        [DisplayName("D.N.I.")]
        public string Dni { get; set; }
        [Required]
        [DisplayName("Nombre")]
        public string Nombre { get; set; }
        [Required]
        [DisplayName("Primer apellido")]
        public string PrimerApellido { get; set; }
        [Required]
        [DisplayName("Segundo apellido")]
        public string SegundoApellido { get; set; }
        [DisplayName("Teléfono fijo")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(\d{11})$", ErrorMessage = "El número telefónico es inválido.")]
        public string TelefonoFijo { get; set; }
        [DisplayName("Teléfono móvil")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "El número telefónico es inválido.")]
        public string TelefonoMovil { get; set; }        
        
    }
}
