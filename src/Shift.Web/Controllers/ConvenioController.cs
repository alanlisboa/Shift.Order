using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shift.Application.Services.Interfaces;
using Shift.Application.ViewModels;

namespace Shift.Web.Controllers
{
    public class ConvenioController : BaseController
    {
        private readonly IConvenioAppService _convenioAppService;

        public ConvenioController(IConvenioAppService convenioAppService)
        {
            _convenioAppService = convenioAppService;
        }

        // GET: Convenio
        [HttpGet("convenio")]
        public async Task<IActionResult> Index()
        {
            return View(await _convenioAppService.GetAll());
        }

        // GET: convenio/details/5
        [HttpGet("convenio/details/{id:guid}")]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
                return NotFound();

            var convenioViewModel = await _convenioAppService.GetById(id.Value);

            if (convenioViewModel == null)
                return NotFound();

            return View(convenioViewModel);
        }

        // GET: Convenio/Create
        [HttpGet("convenio/create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Convenio/Create
        [HttpPost("convenio/create")]
        public async Task<IActionResult> Create(ConvenioViewModel convenioViewModel)
        {
            if (!ModelState.IsValid)
                return View(convenioViewModel);

            if (ResponseHasErrors(await _convenioAppService.Add(convenioViewModel)))
                return View(convenioViewModel);

            ViewBag.Sucesso = "Convenio registrado!";

            return View(convenioViewModel);
        }

        // GET: convenio/edit/5
        [HttpGet("convenio/edit/{id:guid}")]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
                return NotFound();

            var convenioViewModel = await _convenioAppService.GetById(id.Value);

            if (convenioViewModel == null)
                return NotFound();

            return View(convenioViewModel);
        }

        // POST: convenio/edit/5
        [HttpPost("convenio/edit/{id:guid}")]
        public async Task<IActionResult> Edit(ConvenioViewModel convenioViewModel)
        {
            if (!ModelState.IsValid)
                return View(convenioViewModel);

            if (ResponseHasErrors(await _convenioAppService.Update(convenioViewModel)))
                return View(convenioViewModel);

            ViewBag.Sucesso = "Convenio atualizado!";

            return View(convenioViewModel);
        }

        // GET: convenio/delete/5
        [HttpGet("convenio/delete/{id:guid}")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null) 
                return NotFound();

            var convenioViewModel = await _convenioAppService.GetById(id.Value);

            if (convenioViewModel == null) 
                return NotFound();

            return View(convenioViewModel);
        }

        // POST: convenio/delete/5
        [HttpPost("convenio/delete/{id:guid}"), ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (ResponseHasErrors(await _convenioAppService.Remove(id)))
                return View(await _convenioAppService.GetById(id));

            ViewBag.Sucesso = "Convenio removidos";
            return RedirectToAction("Index");
        }

        // GET: convenio/history
        [HttpGet("convenio/history/{id:guid}")]
        public async Task<JsonResult> History(Guid id)
        {
            var historyData = await _convenioAppService.GetAllHistory(id);
            return Json(historyData);
        }
    }
}
