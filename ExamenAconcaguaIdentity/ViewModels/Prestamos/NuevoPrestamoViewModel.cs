using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ExamenAconcaguaIdentity.ViewModels.Prestamos
{
    public class NuevoPrestamoViewModel
    {
        [Required]
        [DisplayName("D.N.I.")]
        public string Dni { get; set; }
        [Required]
        [DisplayName("Nombre")]
        public string NombreCompleto { get; set; }
        [Required, DataType(DataType.Currency)]
        [DisplayName("Monto del prestamo")]
        [Range(1,double.MaxValue)]
        public decimal Valor { get; set; }
        [Required]
        
        public int Cuotas { get; set; }
        public IEnumerable<int> ListaCuotas { get; }

        public NuevoPrestamoViewModel()
        {
            ListaCuotas = new List<int> { 1, 2, 3, 4, 5, 6 };
        }

    }
}

