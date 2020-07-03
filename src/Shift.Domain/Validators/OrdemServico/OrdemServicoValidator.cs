using FluentValidation;
using Shift.Domain.Commands.OrdemServico;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Shift.Domain.Validators.OrdemServico
{
    public abstract class OrdemServicoValidator<T>: AbstractValidator<T> where T : OrdemServicoCommand
    {
        protected void ValidateMedico() => RuleFor(c => c.MedicoId)
            .NotEmpty().WithMessage("Por favor informe o médico");

        protected void ValidatePostoColeta() => RuleFor(c => c.PostoColetaId)
            .NotEmpty().WithMessage("Por favor informe o posto de coleta");

        protected void ValidateDataOrdem() => RuleFor(c => c.DataOrdem)
            .NotEmpty().WithMessage("Por favor informe a data da ordem de serviços");

        protected void ValidateConvenio() => RuleFor(c => c.ConvenioId)
            .NotEmpty().WithMessage("Por favor informe o convênio");

        protected void ValidateId() => RuleFor(c => c.Id)
            .NotEqual(Guid.Empty);
    }
}
