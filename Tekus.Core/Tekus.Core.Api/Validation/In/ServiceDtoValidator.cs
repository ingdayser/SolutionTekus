using FluentValidation;
using Tekus.Core.Application.DTO.In;

namespace Tekus.Core.Api.Validation.In
{
    public  class ServiceDtoValidator : AbstractValidator<ServiceDto>
    {
        public ServiceDtoValidator()
        {
            RuleFor(x => x.NameServiceDto).NotEmpty().WithMessage("El campo NameServiceDto es requerido");
            RuleFor(x => x.HourValueDto).NotEmpty().WithMessage("El campo HourValueDto es requerido");
        }
    }
}
