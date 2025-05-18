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

            RuleFor(x => x.Quilometragem)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.UserId)
                .GreaterThan(0);
        }
    }
}