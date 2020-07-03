using FluentValidation.Results;
using Shift.Application.EventSourcedNormalizers;
using Shift.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shift.Application.Services.Interfaces
{
    public interface IOrdemServicoAppService : IDisposable
    {
        Task<IEnumerable<OrdemServicoViewModel>> GetAll();
        Task<OrdemServicoViewModel> GetById(Guid id);
        Task<OrdemServicoViewModel> GetByNumber(int number);
        Task<int> GetLastNumber();
        Task<ValidationResult> Add(OrdemServicoViewModel ordemServicoViewModel);
        Task<ValidationResult> Update(OrdemServicoViewModel ordemServicoViewModel);
        Task<ValidationResult> Remove(Guid id);
    }
}
