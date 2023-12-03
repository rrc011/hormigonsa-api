using Abp.Application.Services.Dto;
using FluentValidation;

namespace Talleres
{
    public class CreateEquipmentCycleInput : EntityDto
    {
        public int EquipmentId { get; set; }
        public int HorometerFrom { get; set; }
        public int HorometerTo { get; set; }
        public float Fuel { get; set; }
        public int TenantId { get; set; }
        public string Comment { get; set; }
    }

    public class CreateEquipmentInputValidator : AbstractValidator<CreateEquipmentCycleInput>
    {
        public CreateEquipmentInputValidator()
        {
            RuleFor(m => m.HorometerFrom).NotEmpty().WithMessage("El horometro inicial requerido");
            RuleFor(m => m.Fuel).NotEmpty().WithMessage("El combustible es requerido");
            RuleFor(m => m.HorometerTo)
                .GreaterThan(m => m.HorometerFrom).WithMessage("El horometro final debe ser mayor al inicial")
                .NotEmpty().WithMessage("El horometro final es requerido");

        }
    }
}
