using FluentValidation;
using Shift.Domain.Commands.OrdemServicoExame;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Shift.Domain.Validators.OrdemServicoExame
{
    public abstract class OrdemServicoExameValidator<T>: AbstractValidator<T> where T : OrdemServicoExameCommand
    {
        protected void ValidateExame() => RuleFor(c => c.ExameId)
            .NotEmpty().WithMessage("Por favor informe o exame");

        protected void ValidateOrdem() => RuleFor(c => c.OrdemServicoId)
            .NotEmpty().WithMessage("Por favor informe a ordem de serviço");

        protected void ValidateValor() => RuleFor(c => c.Valor)
            .GreaterThan(0).WithMessage("Informe um valor válido");

        protected void ValidateId() => RuleFor(c => c.Id)
            .NotEqual(Guid.Empty);
    }
}
