using System;
using System.Collections.Generic;
using AutoMapper;
using ExamenAconcagua.Models;
using ExamenAconcagua.Models.Interfaces;
using ExamenAconcagua.Services.Interfaces;
using ExamenAconcagua.ViewModels.Solicitante;
using ExamenAconcaguaIdentity.Data;
using ExamenAconcaguaIdentity.ViewModels.ApiResponse;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ExamenAconcaguaIdentity.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SolicitanteController : Controller
    {
        private readonly ILogger<SolicitanteController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SolicitanteController(ILogger<SolicitanteController> logger, ApplicationDbContext context, IMapper mapper)
        {
            _logger = logger;
            _unitOfWork = new UnitOfWork(context);
            _mapper = mapper;
        }

        public IActionResult NuevoSolicitante()
        {
            NuevoSolicitanteViewModel viewModel = new NuevoSolicitanteViewModel();
            return View(viewModel);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult NuevoSolicitante(NuevoSolicitanteViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var persona = _unitOfWork.SolicitanteRepository.GetByDni(viewModel.Dni);
                if (persona != null)
                    ModelState.AddModelError(nameof(viewModel.Dni), "El dni ya se encuentra asociado a " + persona.NombreCompleto());

                using (var transaction = _unitOfWork.BeingTransaction())
                {
                    try
                    {
                        var model = _mapper.Map<Solicitante>(viewModel);
                        _unitOfWork.SolicitanteRepository.Add(model);
                        _unitOfWork.Save();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        _logger.LogError(ex.Message);
                    }
                }
            }
            return View(viewModel);
        }

        public IActionResult Index()
        {
            try
            {
                var data = _unitOfWork.SolicitanteRepository.GetAll();
                IEnumerable<SolicitanteViewModel> viewModel = _mapper.Map<IEnumerable<SolicitanteViewModel>>(data);
                return View(viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(404);
            }

        }

        /// <summary>
        /// Json method
        /// </summary>
        /// <param name="dni"></param>
        /// <returns></returns>
        [HttpGet("[controller]/ObtenerSolicitante/{dni}")]
        public IActionResult ObtenerSolicitante(string dni)
        {
            if (!string.IsNullOrWhiteSpace(dni))
            {
                try
                {
                    var solicitante = _unitOfWork.SolicitanteRepository.GetByDni(dni);
                    if (solicitante == null)
                        return Json(ApiResponse.Error("Dni no encontrado en la base de datos"));
                    return Json(ApiResponse<string>.Ok(solicitante.NombreCompleto()));
                }
                catch(Exception ex)
                {
                    _logger.LogError(ex.Message);
                    return Json(ApiResponse.Error(ex.Message));
                }
            }

            return BadRequest();
        }

    }
}