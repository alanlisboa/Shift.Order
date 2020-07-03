using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shift.Application.Services.Interfaces;

namespace Shift.Web.Controllers
{
    public class GerenciamentoController : BaseController
    {
        private readonly IMedicoAppService _medicoAppService;
        private readonly IConvenioAppService _convenioAppService;
        private readonly IPacienteAppService _pacienteAppService;
        private readonly IPostoColetaAppService _postoColetaAppService;
        private readonly IExameAppService _exameAppService;

        public GerenciamentoController(IMedicoAppService medicoAppService,
                                       IConvenioAppService convenioAppService,
                                       IPacienteAppService pacienteAppService,
                                       IPostoColetaAppService postoColetaAppService,
                                       IExameAppService exameAppService)
        {
            _medicoAppService = medicoAppService;
            _convenioAppService = convenioAppService;
            _pacienteAppService = pacienteAppService;
            _postoColetaAppService = postoColetaAppService;
            _exameAppService = exameAppService;
        }

        public async Task<IActionResult> Convenio()
        {
            return View(await _convenioAppService.GetAll());
        }

        public async Task<IActionResult> Exame()
        {
            return View(await _exameAppService.GetAll());
        }

        public async Task<IActionResult> Medico()
        {
            return View(await _medicoAppService.GetAll());
        }

        public async Task<IActionResult> Paciente()
        {
            return View(await _pacienteAppService.GetAll());
        }

        public async Task<IActionResult> Posto()
        {
            return View(await _postoColetaAppService.GetAll());
        }
    }
}
