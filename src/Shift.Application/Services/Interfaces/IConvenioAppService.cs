using FluentValidation.Results;
using Shift.Application.EventSourcedNormalizers;
using Shift.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shift.Application.Services.Interfaces
{
    public interface IConvenioAppService : IDisposable
    {
        Task<IEnumerable<ConvenioViewModel>> GetAll();
        Task<ConvenioViewModel> GetById(Guid id);

        Task<ValidationResult> Add(ConvenioViewModel convenioViewModel);
        Task<ValidationResult> Update(ConvenioViewModel convenioViewModel);
        Task<ValidationResult> Remove(Guid id);

        Task<IList<ConvenioHistoryData>> GetAllHistory(Guid id);
    }
}
