using System.Linq;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Microsoft.EntityFrameworkCore;
using Talleres.Authorization;

namespace Talleres.Talleres.Equipment
{
    public class ModelAppService : CustomAppService<Model, ModelDto, int, GetAllModelInput, ModelDto, UpdateModelInput>
    {
        public ModelAppService(IRepository<Model> repository) : base(repository)
        {
            CreatePermissionName = PermissionNames.Models_Create;
            UpdatePermissionName = PermissionNames.Models_Update;
            DeletePermissionName = PermissionNames.Models_Delete;
            GetAllPermissionName = PermissionNames.Models_Get;
            GetPermissionName = PermissionNames.Models_Get;
        }

        protected override IQueryable<Model> CreateFilteredQuery(GetAllModelInput input)
        {
            return base.CreateFilteredQuery(input)
                .Include(x => x.BrandAssigned)
                .WhereIf(input.BrandId.HasValue, m => m.BrandId == input.BrandId);
        }
    }
}
