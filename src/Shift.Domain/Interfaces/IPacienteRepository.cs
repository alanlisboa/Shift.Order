using Shift.Core.Data;
using Shift.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shift.Domain.Interfaces
{
    public interface IPacienteRepository : IRepository<Paciente>
    {
        Task<Paciente> GetById(Guid id);
        Task<IEnumerable<Paciente>> GetAll();
        //Task<Paciente> GetByDocument(string document);
        //void Add(Paciente paciente);
        //void Update(Paciente paciente);
        //void Remove(Paciente paciente);
    }
}
