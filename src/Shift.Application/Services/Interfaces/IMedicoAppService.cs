using Shift.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shift.Application.Services.Interfaces
{
    public interface IMedicoAppService : IDisposable
    {
        Task<IEnumerable<MedicoViewModel>> GetAll();
        Task<MedicoViewModel> GetById(Guid id);
    }
}
