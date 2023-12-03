using Abp.AutoMapper;
using Abp.Domain.Repositories;

namespace Talleres
{
    [AutoMapFrom(typeof(Brand))]
    public class BrandDto : CustomEntityDto
    {
        public class BrandDtoValidator : CustomDtoValidator<Brand, BrandDto, int>
        {
            public BrandDtoValidator(IRepository<Brand> repository) : base(repository) { }
        }
    }
}
