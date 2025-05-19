using FluentValidation;
using Api.Application.DTO.Request;

namespace Api.Application.Validators
{
    public class CreateMotoRequestValidator : AbstractValidator<CreateMotoRequest>
    {
        public CreateMotoRequestValidator()
        {
            RuleFor(x => x.placa)
                .NotEmpty()
                .MaximumLength(10);

            RuleFor(x => x.chassi)
                .NotEmpty()
                .MaximumLength(20);

            RuleFor(x => x.tagDaMoto)
                .MaximumLength(50);

            RuleFor(x => x.observacao)
                .MaximumLength(255);

            RuleFor(x => x.fotoDaMoto)
                .MaximumLength(255);

            RuleFor(x => x.quilometragem)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.anoDeFabricacao)
                .GreaterThan(1900);

            RuleFor(x => x.anoDeLancamento)
                .LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.Today));

            RuleFor(x => x.userId)
                .GreaterThan(0);

            RuleFor(x => x.combustivel)
                .IsInEnum()
                .WithMessage("Combustível inválido.");

            RuleFor(x => x.typeMotos)
                .IsInEnum()
                .WithMessage("Tipo de moto inválida.");

            RuleFor(x => x.patioAtual)
                .MaximumLength(100);

            RuleFor(x => x.planoAssociado)
                .MaximumLength(100);

            RuleFor(x => x.multas)
                .MaximumLength(255);

            RuleFor(x => x.historicoDeReparos)
                .MaximumLength(255);

            RuleFor(x => x.historicoDeChecks)
                .MaximumLength(255);
        }
    }
}