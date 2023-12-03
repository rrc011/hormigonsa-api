using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using FluentValidation;

namespace Talleres
{
    public class UpdateModelInput : EntityDto
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int BrandId { get; set; }
        public class UpdateModelInputValidator : AbstractValidator<UpdateModelInput>
        {
            public UpdateModelInputValidator(IRepository<Model> repository, IRepository<Brand> brandRepository)
            {
                RuleFor(m => m.BrandId)
                    .NotNull()
                    .Must((model, brandId) => brandRepository.Count(me => me.Id.Equals(brandId) && !me.IsDeleted) > 0)
                    .WithMessage(m => $"La marca con el id: {m.BrandId} no existe o fue eliminada");

                RuleFor(m => m.Name)
                .NotEmpty()
                .Must((model, name) => repository.Count(me => me.Name.Equals(name) && me.Id != model.Id && me.BrandId == model.BrandId) == 0)
                .WithMessage(m => $"Ya existe un registro con el nombre: {m.Name}");
            }
        }
    }
}
