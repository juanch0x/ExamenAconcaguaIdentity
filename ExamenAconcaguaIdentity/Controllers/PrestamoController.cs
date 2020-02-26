using AutoMapper;
using ExamenAconcagua.Models;
using ExamenAconcagua.Services.Interfaces;
using ExamenAconcaguaIdentity.Data;
using ExamenAconcaguaIdentity.ViewModels.ApiResponse;
using ExamenAconcaguaIdentity.ViewModels.Prestamos;
using ExamenAconcaguaIdentity.ViewModels.Solicitante;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace ExamenAconcaguaIdentity.Controllers
{
    public class PrestamoController : Controller
    {
        private readonly ILogger<PrestamoController> _logger;
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PrestamoController(ILogger<PrestamoController> logger, ApplicationDbContext dbContext, IMapper mapper)
        {
            _logger = logger;
            _unitOfWork = new UnitOfWork(dbContext);
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("[controller]/NuevoPrestamo/{dni?}")]
        public IActionResult NuevoPrestamo() 
        {            
            return View(new NuevoPrestamoViewModel());
        }

        [HttpPost]
        public IActionResult NuevoPrestamo(NuevoPrestamoViewModel viewModel)
        {            
            if (viewModel == null) return BadRequest();

            if (ModelState.IsValid)
            {
                try { 
                    //Chequeo que el solicitante no tenga prestamos vigentes.
                    var solicitante = _unitOfWork.SolicitanteRepository.GetByDni(viewModel.Dni);
                    if (solicitante.Prestamos.Any(x => x.Pagos.Any(c => c.Pagado == false)))
                    {
                        ModelState.AddModelError(nameof(viewModel.Dni), "El solicitante tiene prestamos vigentes");
                        ModelState.AddModelError(nameof(viewModel.NombreCompleto), "El solicitante tiene prestamos vigentes");
                    }

                    Prestamo prestamo = new Prestamo
                    {
                        IdSolicitante = solicitante.Id,
                        MontoSolicitado = viewModel.Valor,
                        Cuotas = viewModel.Cuotas
                    };


                    using (var transaction = _unitOfWork.BeingTransaction())
                    {
                        _unitOfWork.PrestamoRepository.Add(prestamo);
                        _unitOfWork.Save();
                        transaction.Commit();
                    }

                    return RedirectToAction(nameof(DetallePrestamo), new { id = prestamo.Id });

                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    _logger.LogError(ex.Message);
                    return View(viewModel);
                }
            }
            return View(viewModel);
        }

        [HttpGet("[controller]/DetallePrestamo/{id}")]
        public IActionResult DetallePrestamo(long id)
        {            
            try
            {
                var entity = _unitOfWork.PrestamoRepository.Get(id);
                if (entity == null) return NotFound();
                var viewModel = _mapper.Map<Prestamo, DetallePrestamoViewModel>(entity);
                return View(viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        [HttpGet("[controller]/AutorizarPrestamo/{id}")]
        public IActionResult AutorizarPrestamo(long id)
        {
            try
            {
                var entity = _unitOfWork.PrestamoRepository.Get(id);
                if (entity == null) throw new ArgumentOutOfRangeException(nameof(id), id, "El id no corresponde a ningúna persona en la base de datos.");

                if (entity.Pagos.Any(c => !c.Pagado))
                    throw new ArgumentOutOfRangeException(nameof(id), id, "La persona tiene un prestamo no pagado vigente.");
                
                using (var transaction = _unitOfWork.BeingTransaction())
                {
                    entity.AutorizacionDelPrestamo = DateTimeOffset.Now;
                    entity.FechaTentativaDeEntrega = DateTimeOffset.Now.AddDays(7);

                    decimal valorcuota = entity.MontoSolicitado / entity.Cuotas;
                    for(int i = 1; i<=entity.Cuotas; i++)
                    {
                        Cuota cuota = new Cuota
                        {
                            FechaPago = entity.FechaTentativaDeEntrega.Value.AddMonths(i),
                            Pagado = false,
                            PrestamoId = entity.Id,
                            TotalCuota = valorcuota
                        };
                        entity.Pagos.Add(cuota);
                    }
                    _unitOfWork.PrestamoRepository.Update(entity);
                    return Json(ApiResponse.Ok());
                }

            } 
            catch(Exception ex)
            {
                return Json(ApiResponse.Error(ex.Message));
            }
        }

        public IActionResult SolicitanteNoApto(SolicitanteNoAptoViewModel viewModel)
        {
            if(viewModel == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                return View(viewModel);
            }
        }

    }
}