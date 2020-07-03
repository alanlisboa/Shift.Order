using Shift.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shift.Application.Services.Interfaces
{
    public interface IPostoColetaAppService : IDisposable
    {
        Task<IEnumerable<PostoColetaViewModel>> GetAll();
        Task<PostoColetaViewModel> GetById(Guid id);
    }
}
