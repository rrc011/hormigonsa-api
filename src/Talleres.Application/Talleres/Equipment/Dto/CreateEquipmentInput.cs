using Abp.Domain.Repositories;
using FluentValidation;
using static Talleres.Constants;

namespace Talleres
{
    public class CreateEquipmentInput
    {
        public int? Id { get; set; }
        public string Serial { get; set; }
        public string Chassis { get; set; }
        public string Plate { get; set; }
        public string Tab { get; set; }
        public int Year { get; set; }
        public int? BrandId { get; set; }
        public int? ModelId { get; set; }
        public string Color { get; set; }
        public EquipmentType Type { get; set; }
        public ReferenceType ReferenceAssigned { get; set; }
        public CombustionType Combustion { get; set; }
        public float? Capacity { get; set; }
        public string Comment { get; set; }
        public float? Horometer { get; set; }   

        public class CreateEquipmentInputValidator : AbstractValidator<CreateEquipmentInput>
        {
            public CreateEquipmentInputValidator(IRepository<Equipment> repository)
            {
                RuleFor(m => m.Serial)
                .Must((equipment, serial) =>
                    repository.Count(me => me.Serial.Equals(serial)) == 0)
                .When(m => !string.IsNullOrEmpty(m.Serial))
                .WithMessage(m => $"Ya existe un equipo registrado con el serial {m.Serial}");

                RuleFor(m => m.Tab)
                    .Must((equipo, tab) =>
                        repository.Count(me => me.Tab.Equals(tab)) == 0)
                    .When(m => !string.IsNullOrEmpty(m.Tab))
                    .WithMessage(m => $"Ya existe un equipo registrado con la ficha {m.Tab}");

                RuleFor(m => m.Tab)
                    .Matches(@"^\w+$")
                    .WithMessage("La ficha no puede contener caracteres especiales");

                RuleFor(m => m.Serial)
                    .Matches(@"^\w+$")
                    .WithMessage("El serial no puede contener caracteres especiales");

                RuleFor(m => m.Capacity).NotEmpty();
            }
        }
    }
}
