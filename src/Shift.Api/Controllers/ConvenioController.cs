using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shift.Application.EventSourcedNormalizers;
using Shift.Application.Services.Interfaces;
using Shift.Application.ViewModels;

namespace Shift.Api.Controllers
{
    public class ConvenioController : ApiController
    {
        private readonly IConvenioAppService _convenioAppService;

        public ConvenioController(IConvenioAppService convenioAppService)
        {
            _convenioAppService = convenioAppService;
        }

        // GET /convenio
        [HttpGet("convenio")]
        public async Task<IEnumerable<ConvenioViewModel>> Get()
        {
            return await _convenioAppService.GetAll();
        }

        // GET convenio/5
        [HttpGet("convenio/{id:guid}")]
        public async Task<ConvenioViewModel> Get(Guid id)
        {
            return await _convenioAppService.GetById(id);
        }

        // POST convenio
        [HttpPost("convenio")]
        public async Task<IActionResult> Post([FromBody]ConvenioViewModel viewModel)
        {
            return !ModelState.IsValid ?
                CustomResponse(ModelState) :
                CustomResponse(await _convenioAppService.Add(viewModel));
        }

        // PUT convenio/5
        [HttpPut("convenio")]
        public async Task<IActionResult> Put([FromBody] ConvenioViewModel viewModel)
        {
            return !ModelState.IsValid ?
                CustomResponse(ModelState) :
                CustomResponse(await _convenioAppService.Update(viewModel));
        }

        // DELETE convenio/5
        [HttpDelete("convenio/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return CustomResponse(await _convenioAppService.Remove(id));
        }

        // GET convenio/history/5
        [HttpGet("convenio/history/{id:guid}")]
        public async Task<IList<ConvenioHistoryData>> History(Guid id)
        {
            return await _convenioAppService.GetAllHistory(id);
        }
    }
}
