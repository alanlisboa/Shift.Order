using Shift.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shift.Application.Services.Interfaces
{
    public interface IExameAppService : IDisposable
    {
        Task<IEnumerable<ExameViewModel>> GetAll();
        Task<ExameViewModel> GetById(Guid id);
    }
}
