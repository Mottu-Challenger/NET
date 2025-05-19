using Api.Application.DTO.Request;
using FluentValidation;

namespace Api.Application.Validators
{
    public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserRequestValidator()
        {
            RuleFor(x => x.nome)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.email)
                .NotEmpty()
                .EmailAddress()
                .MaximumLength(100);

            RuleFor(x => x.cpf)
                .NotEmpty()
                .Length(11, 14)
                .WithMessage("Insira um CPF válido.");

            RuleFor(x => x.rg)
                .MaximumLength(20);

            RuleFor(x => x.dtaNasc)
                .LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.Today))
                .WithMessage("Insira uma data de nascimento válida.");

            RuleFor(x => x.numeroDeCadastro)
                .GreaterThan(0);

            RuleFor(x => x.nacionalidade)
                .MaximumLength(50);

            RuleFor(x => x.carteira)
                .MaximumLength(50);

            RuleFor(x => x.enderco)
                .MaximumLength(100);

            RuleFor(x => x.contato)
                .MaximumLength(100);

            RuleFor(x => x.plano)
                .MaximumLength(100);
        }
    }
}