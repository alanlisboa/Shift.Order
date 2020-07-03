using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shift.Application.Services.Interfaces;
using Shift.Application.ViewModels;

namespace Shift.Api.Controllers
{
    public class OrdemServicoController : ApiController
    {
        private readonly IOrdemServicoAppService _ordemServicoAppService;

        public OrdemServicoController(IOrdemServicoAppService ordemServicoAppService)
        {
            _ordemServicoAppService = ordemServicoAppService;
        }

        // GET /ordem
        [HttpGet("ordem")]
        public async Task<IEnumerable<OrdemServicoViewModel>> Get()
        {
            return await _ordemServicoAppService.GetAll();
        }

        // GET ordem/5
        [HttpGet("ordem/{id:guid}")]
        public async Task<OrdemServicoViewModel> Get(Guid id)
        {
            return await _ordemServicoAppService.GetById(id);
        }

        // POST ordem
        [HttpPost("ordem")]
        public async Task<IActionResult> Post([FromBody]OrdemServicoViewModel viewModel)
        {
            return !ModelState.IsValid ?
                CustomResponse(ModelState) :
                CustomResponse(await _ordemServicoAppService.Add(viewModel));
        }

        // PUT ordem/5
        [HttpPut("ordem")]
        public async Task<IActionResult> Put([FromBody] OrdemServicoViewModel viewModel)
        {
            return !ModelState.IsValid ?
                CustomResponse(ModelState) :
                CustomResponse(await _ordemServicoAppService.Update(viewModel));
        }

        // DELETE ordem/5
        [HttpDelete("ordem/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return CustomResponse(await _ordemServicoAppService.Remove(id));
        }

    }
}
