using Shift.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shift.Application.Services.Interfaces
{
    public interface IPacienteAppService : IDisposable
    {
        Task<IEnumerable<PacienteViewModel>> GetAll();
        Task<PacienteViewModel> GetById(Guid id);
    }
}
