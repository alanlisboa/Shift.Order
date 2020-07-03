using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shift.Application.Services.Interfaces;
using Shift.Application.ViewModels;

namespace Shift.Web.Controllers
{
    public class OrdemServicoExameController : BaseController
    {
        private readonly IOrdemServicoExameAppService _ordemServicoExameAppService;
        private readonly IOrdemServicoAppService _ordemServicoAppService;
        private readonly IExameAppService _exameAppService;

        public OrdemServicoExameController(IOrdemServicoExameAppService ordemServicoExameAppService,
                                           IOrdemServicoAppService ordemServicoAppService,
                                           IExameAppService exameAppService)
        {
            _ordemServicoExameAppService = ordemServicoExameAppService;
            _ordemServicoAppService = ordemServicoAppService;
            _exameAppService = exameAppService;
        }

        // GET: ordem-item/details/5
        [HttpGet("ordem-item/details/{id:guid}")]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
                return NotFound();

            var ordemServiceExameViewModel = await _ordemServicoExameAppService.GetById(id.Value);

            if (ordemServiceExameViewModel == null)
                return NotFound();

            return View(ordemServiceExameViewModel);
        }

        // GET: ordem-item/create/5
        [HttpGet("ordem-item/create/{id:guid}")]
        public IActionResult Create(Guid? id)
        {
            ViewData["ExameId"] = new SelectList(_exameAppService.GetAll().Result, "Id", "Descricao");
            ViewData["OrdemServicoId"] = id;
            return View();
        }

        // POST: ordem-item/create/5
        [HttpPost("ordem-item/create/{id:guid}")]
        public async Task<IActionResult> Create(Guid? id, OrdemServicoExameViewModel ordemServicoExameViewModel)
        {
            ordemServicoExameViewModel.OrdemServico = await _ordemServicoAppService.GetById(id.Value);

            bool hasErrors = !ModelState.IsValid;

            if (!hasErrors)
                hasErrors = ResponseHasErrors(await _ordemServicoExameAppService.Add(ordemServicoExameViewModel));
            
            if (hasErrors)
            {
                ViewData["ExameId"] = new SelectList(await _exameAppService.GetAll(), "Id", "Nome", ordemServicoExameViewModel.Exame?.Id);
                ViewData["OrdemServicoId"] = id;
                
                return View(ordemServicoExameViewModel);
            }

            ViewBag.Sucesso = "Item registrado!";

            return RedirectToAction("edit", "ordem", new { Id = id });
        }

        // GET: ordem-item/edit/5
        [HttpGet("ordem-item/edit/{id:guid}")]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
                return NotFound();

            var ordemServicoExameViewModel = await _ordemServicoExameAppService.GetById(id.Value);
            
            if (ordemServicoExameViewModel == null)
                return NotFound();

            ViewData["ExameId"] = new SelectList(await _exameAppService.GetAll(), "Id", "Descricao", ordemServicoExameViewModel.Exame?.Id);
            
            return View(ordemServicoExameViewModel);
        }

        // POST: ordem-item/edit/5
        [HttpPost("ordem-item/edit/{id:guid}")]
        public async Task<IActionResult> Edit(OrdemServicoExameViewModel ordemServicoExameViewModel)
        {
            var ordemServicoViewModel = await _ordemServicoAppService.GetById(ordemServicoExameViewModel.OrdemServico.Id);

            ordemServicoExameViewModel.OrdemServico = ordemServicoViewModel;

            if (ResponseHasErrors(await _ordemServicoExameAppService.Update(ordemServicoExameViewModel)))
                return View(ordemServicoExameViewModel);

            return RedirectToAction("edit", "ordem", new { id = ordemServicoViewModel.Id });
        }

        // GET: ordem-item/delete/5
        [HttpGet("ordem-item/delete/{id:guid}")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
                return NotFound();

            var ordemServicoExameViewModel = await _ordemServicoExameAppService.GetById(id.Value);

            if (ordemServicoExameViewModel == null)
                return NotFound();

            return View(ordemServicoExameViewModel);
        }

        // POST: ordem-item/delete/5
        [HttpPost("ordem-item/delete/{id:guid}"), ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var ordemServicoExameViewModel = await _ordemServicoExameAppService.GetById(id);

            if (ResponseHasErrors(await _ordemServicoExameAppService.Remove(id)))
                return View(ordemServicoExameViewModel);

            ViewBag.Sucesso = "Item de Ordem de Serviços removido!";

            return RedirectToAction("edit", "ordem", new { id = ordemServicoExameViewModel.OrdemServico.Id });
        }
    }
}
