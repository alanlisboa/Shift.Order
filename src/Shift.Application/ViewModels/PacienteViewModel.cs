using Shift.Core.Domain;
using System;

namespace Shift.Application.ViewModels
{
    public class PacienteViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Documento { get; set; }
        public DateTime DataNascimento { get; set; }
        public PacienteSexo Sexo { get; set; }
        public EnderecoViewModel Endereco { get; set; }

        public enum PacienteSexo
        {
            Masculino = 0,
            Feminino = 1,
            Outros = 2
        }
    }
}
