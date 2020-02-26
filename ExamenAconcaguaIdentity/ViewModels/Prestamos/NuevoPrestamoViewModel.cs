using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExamenAconcaguaIdentity.ViewModels.Prestamos
{
    public class NuevoPrestamoViewModel
    {
        [Required]
        public string Dni { get; set; }
        [Required]
        public string NombreCompleto { get; set; }
        [Required, DataType(DataType.Currency)]
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

