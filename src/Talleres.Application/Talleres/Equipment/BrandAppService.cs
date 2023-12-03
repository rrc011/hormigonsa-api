using Abp.Domain.Repositories;
using JetBrains.Annotations;
using System;
using System.Threading.Tasks;
using Talleres.Authorization;

namespace Talleres.Talleres.Equipment
{
    public class BrandAppService : CustomAppService<Brand, BrandDto, int, GetCustomAllInput, BrandDto, BrandDto>
    {
        public BrandAppService(IRepository<Brand> repository) : base(repository)
        {
            CreatePermissionName = PermissionNames.Brands_Create;
            UpdatePermissionName = PermissionNames.Brands_Update;
            DeletePermissionName = PermissionNames.Brands_Delete;
            GetAllPermissionName = PermissionNames.Brands_Get;
            GetPermissionName = PermissionNames.Brands_Get;
        }

        public override Task<BrandDto> CreateAsync(BrandDto input)
        {
            input.CreatorUserId = (long)AbpSession.UserId;
            return base.CreateAsync(input);
        }

        public async Task<bool> ChangeState(int brandId)
        {
            try
            {
                var brand = await Repository.GetAsync(brandId);

                brand.IsDeleted = !brand.IsDeleted;

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
