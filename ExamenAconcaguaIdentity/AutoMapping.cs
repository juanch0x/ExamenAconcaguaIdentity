using AutoMapper;
using ExamenAconcagua.Models;
using ExamenAconcagua.Models.Interfaces;
using ExamenAconcagua.ViewModels.Solicitante;
using ExamenAconcaguaIdentity.ViewModels.Prestamos;
using ExamenAconcaguaIdentity.ViewModels.Solicitante;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenAconcaguaIdentity
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<NuevoSolicitanteViewModel, Solicitante>();
            CreateMap<Solicitante, SolicitanteViewModel>()
                .ForMember(x => x.NombreCompleto, x => x.MapFrom(c => c.NombreCompleto()));

            //Solicitante no apto.
            CreateMap<Solicitante, SolicitanteNoAptoViewModel>()
                .ForMember(x => x.Nombre, x => x.MapFrom(c => c.NombreCompleto()));
            PrestamoMapping();
        }

        private void PrestamoMapping()
        {
            CreateMap<Prestamo, DetallePrestamoViewModel>()
                .ForMember(x => x.DniSolicitante, x => x.MapFrom(c => c.Solicitante.Dni))
                .ForMember(x => x.NombreCompletoSolicitante, x => x.MapFrom(c => c.Solicitante.NombreCompleto()))
                .ForMember(x => x.MontoPrestamo, x => x.MapFrom(c => c.MontoSolicitado))
                .ForMember(x => x.FechaAutorizacion, x => x.MapFrom(c => c.AutorizacionDelPrestamo))
                .ForMember(x => x.FechaTentativa, x => x.MapFrom(c => c.FechaTentativaDeEntrega))
                .ForMember(x => x.Pagos, x => x.MapFrom(c => c.Pagos))
                .AfterMap((enitty,viewModel) => 
                {
                    int i = 1;
                    foreach(var pago in viewModel.Pagos.OrderBy(c => c.Id))
                    {
                        pago.NumeroDeCuota = i++;
                    }
                });

            CreateMap<Cuota, CuotaViewModel>()
                .ForMember(x => x.FechaCuota, x => x.MapFrom(c => c.FechaPago))
                .ForMember(x => x.Monto, x => x.MapFrom(c => c.TotalCuota))
                .ForMember(x => x.Pagado, x => x.MapFrom(c => c.Pagado));  

        }
    }
}
