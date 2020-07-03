using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shift.Application.Services.Interfaces;
using Shift.Application.ViewModels;

namespace Shift.Web.Controllers
{
    public class OrdemServicoController : BaseController
    {
        private readonly IOrdemServicoAppService _ordemServicoAppService;
        private readonly IMedicoAppService _medicoAppService;
        private readonly IConvenioAppService _convenioAppService;
        private readonly IPacienteAppService _pacienteAppService;
        private readonly IPostoColetaAppService _postoColetaAppService;

        public OrdemServicoController(IOrdemServicoAppService ordemServicoAppService, 
                                      IMedicoAppService medicoAppService,
                                      IConvenioAppService convenioAppService,
                                      IPacienteAppService pacienteAppService,
                                      IPostoColetaAppService postoColetaAppService)
        {
            _ordemServicoAppService = ordemServicoAppService;
            _medicoAppService = medicoAppService;
            _convenioAppService = convenioAppService;
            _pacienteAppService = pacienteAppService;
            _postoColetaAppService = postoColetaAppService;
        }

        // GET: OrdemServico
        [HttpGet("ordem")]
        public async Task<IActionResult> Index()
        {
            return View(await _ordemServicoAppService.GetAll());
        }

        // GET: OrdemServico/Details/5
        [HttpGet("ordem/details/{id:guid}")]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
                return NotFound();

            var ordemServiceViewModel = await _ordemServicoAppService.GetById(id.Value);

            if (ordemServiceViewModel == null)
                return NotFound();

            return View(ordemServiceViewModel);
        }

        // GET: OrdemServico/Create
        [HttpGet("ordem/create")]
        public IActionResult Create()
        {
            ViewData["Numero"] = _ordemServicoAppService.GetLastNumber().Result + 1;
            ViewData["ConvenioId"] = new SelectList(_convenioAppService.GetAll().Result, "Id", "Nome");
            ViewData["MedicoId"] = new SelectList(_medicoAppService.GetAll().Result, "Id", "Nome");
            ViewData["PacienteId"] = new SelectList(_pacienteAppService.GetAll().Result, "Id", "Nome");
            ViewData["PostoColetaId"] = new SelectList(_postoColetaAppService.GetAll().Result, "Id", "Descricao");

            return View();
        }

        // POST: OrdemServico/Create
        [HttpPost("ordem/create")]
        public async Task<IActionResult> Create(OrdemServicoViewModel ordemServicoViewModel)
        {
            bool hasErrors = !ModelState.IsValid;

            if (!hasErrors)
                hasErrors = ResponseHasErrors(await _ordemServicoAppService.Add(ordemServicoViewModel));

            if (hasErrors)
            {
                ViewData["ConvenioId"] = new SelectList(_convenioAppService.GetAll().Result, "Id", "Nome", ordemServicoViewModel.Convenio?.Id);
                ViewData["MedicoId"] = new SelectList(_medicoAppService.GetAll().Result, "Id", "Nome", ordemServicoViewModel.Medico?.Id);
                ViewData["PacienteId"] = new SelectList(_pacienteAppService.GetAll().Result, "Id", "Nome", ordemServicoViewModel.Paciente?.Id);
                ViewData["PostoColetaId"] = new SelectList(_postoColetaAppService.GetAll().Result, "Id", "Descricao", ordemServicoViewModel.PostoColeta?.Id);

                return View(ordemServicoViewModel);
            }
            ordemServicoViewModel = await _ordemServicoAppService.GetByNumber(ordemServicoViewModel.Numero);
            return RedirectToAction("edit", "ordem", new { id = ordemServicoViewModel.Id });
        }

        // GET: OrdemServico/Edit/5
        [HttpGet("ordem/edit/{id:guid}")]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
                return NotFound();

            var ordemServicoViewModel = await _ordemServicoAppService.GetById(id.Value);
            
            if (ordemServicoViewModel == null)
                return NotFound();

            ViewData["ConvenioId"] = new SelectList(_convenioAppService.GetAll().Result, "Id", "Nome", ordemServicoViewModel.Convenio?.Id);
            ViewData["MedicoId"] = new SelectList(_medicoAppService.GetAll().Result, "Id", "Nome", ordemServicoViewModel.Medico?.Id);
            ViewData["PacienteId"] = new SelectList(_pacienteAppService.GetAll().Result, "Id", "Nome", ordemServicoViewModel.Paciente?.Id);
            ViewData["PostoColetaId"] = new SelectList(_postoColetaAppService.GetAll().Result, "Id", "Descricao", ordemServicoViewModel.PostoColeta?.Id);

            return View(ordemServicoViewModel);
        }

        // POST: OrdemServico/Edit/
        [HttpPost("ordem/edit/{id:guid}")]
        public async Task<IActionResult> Edit(OrdemServicoViewModel ordemServicoViewModel)
        {
            if (!ModelState.IsValid)
                return View(ordemServicoViewModel);

            if (ResponseHasErrors(await _ordemServicoAppService.Update(ordemServicoViewModel)))
                return View(ordemServicoViewModel);

            ViewBag.Sucesso = "Ordem de Serviços atualizada!";

            return RedirectToAction("details", "ordem", new { Id = ordemServicoViewModel.Id });
        }

        // GET: OrdemServico/Delete/5
        [HttpGet("ordem/delete/{id:guid}")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
                return NotFound();

            var ordemServicoViewModel = await _ordemServicoAppService.GetById(id.Value);

            if (ordemServicoViewModel == null)
                return NotFound();

            return View(ordemServicoViewModel);
        }

        // POST: OrdemServico/Delete/5
        [HttpPost("ordem/delete/{id:guid}"), ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (ResponseHasErrors(await _ordemServicoAppService.Remove(id)))
                return View(await _ordemServicoAppService.GetById(id));

            ViewBag.Sucesso = "Ordem de Serviços removida";
            return RedirectToAction("Index");
        }
    }
}
