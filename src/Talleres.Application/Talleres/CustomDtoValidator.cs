using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using FluentValidation;

namespace Talleres
{
    public abstract class CustomDtoValidator<TEntity, TEntityDto, TPrimaryKey> : AbstractValidator<TEntityDto>
        where TEntity : CustomEntity, IEntity<TPrimaryKey>
        where TEntityDto : CustomEntityDto
    {
        public CustomDtoValidator(IRepository<TEntity> repository)
        {
            RuleFor(m => m.Name)
                .NotEmpty()
                .Must((family, name) => repository.Count(me => me.Name.Equals(name) && me.Id != family.Id) == 0)
                .WithMessage(m => $"Ya existe un registro con el nombre: {m.Name}");
        }
    }
}
