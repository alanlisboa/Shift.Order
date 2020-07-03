using FluentValidation.Results;
using Shift.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shift.Application.Services.Interfaces
{
    public interface IOrdemServicoExameAppService : IDisposable
    {
        Task<IEnumerable<OrdemServicoExameViewModel>> GetAll(Guid ordemServicoId);
        Task<OrdemServicoExameViewModel> GetById(Guid id);

        Task<ValidationResult> Add(OrdemServicoExameViewModel ordemServicoExameViewModel);
        Task<ValidationResult> Update(OrdemServicoExameViewModel ordemServicoExameViewModel);
        Task<ValidationResult> Remove(Guid id);
    }
}
