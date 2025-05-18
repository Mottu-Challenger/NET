using FluentValidation;
using Api.Application.DTO.Request;

namespace Api.Application.Validators
{
    public class CreateMotoRequestValidator : AbstractValidator<CreateMotoRequest>
    {
        public CreateMotoRequestValidator()
        {
            RuleFor(x => x.Placa)
                .NotEmpty()
                .MaximumLength(10);

            RuleFor(x => x.Chassi)
                .NotEmpty()
                .MaximumLength(20);

            RuleFor(x => x.TagDaMoto)
                .MaximumLength(50);

            RuleFor(x => x.Observacao)
                .MaximumLength(255);

            RuleFor(x => x.FotoDaMoto)
                .MaximumLength(255);

            RuleFor(x => x.Quilometragem)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.AnoDeFabricacao)
                .GreaterThan(1900);

            RuleFor(x => x.AnoDelançamento)
                .LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.Today));

            RuleFor(x => x.UserId)
                .GreaterThan(0);

            RuleFor(x => x.Combustivel)
                .IsInEnum()
                .WithMessage("Combustível inválido.");

            RuleFor(x => x.TypeMotos)
                .IsInEnum()
                .WithMessage("Tipo de moto inválida.");

            RuleFor(x => x.PatioAtual)
                .MaximumLength(100);

            RuleFor(x => x.PlanoAssociado)
                .MaximumLength(100);

            RuleFor(x => x.Multas)
                .MaximumLength(255);

            RuleFor(x => x.HistoricoDeReparos)
                .MaximumLength(255);

            RuleFor(x => x.HistoricoDeChecks)
                .MaximumLength(255);
        }
    }
}