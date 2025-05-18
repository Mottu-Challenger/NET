using Api.Application.DTO.Request;
using FluentValidation;

namespace Api.Application.Validators
{
    public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserRequestValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .MaximumLength(100);

            RuleFor(x => x.CPF)
                .NotEmpty()
                .Length(11, 14)
                .WithMessage("Insira um CPF válido.");

            RuleFor(x => x.RG)
                .MaximumLength(20);

            RuleFor(x => x.DtaNasc)
                .LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.Today))
                .WithMessage("Insira uma data de nascimento válida.");

            RuleFor(x => x.NumeroDeCadastro)
                .GreaterThan(0);

            RuleFor(x => x.Nacionalidade)
                .MaximumLength(50);

            RuleFor(x => x.Carteira)
                .MaximumLength(50);

            RuleFor(x => x.Enderco)
                .MaximumLength(100);

            RuleFor(x => x.Contato)
                .MaximumLength(100);

            RuleFor(x => x.Plano)
                .MaximumLength(100);
        }
    }
}