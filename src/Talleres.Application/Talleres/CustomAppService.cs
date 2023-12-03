using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Linq.Extensions;
using System.Linq;
using System.Threading.Tasks;

namespace Talleres
{
    public abstract class CustomAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput> : TalleresAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput>
        where TEntity : CustomEntity<TPrimaryKey>, IEntity<TPrimaryKey>, ISoftDelete
        where TEntityDto : IEntityDto<TPrimaryKey>
        where TGetAllInput : GetCustomAllInput
        where TCreateInput : IEntityDto<TPrimaryKey>
        where TUpdateInput : IEntityDto<TPrimaryKey>
    {
        public CustomAppService(IRepository<TEntity, TPrimaryKey> repository) : base(repository) { }

        protected override IQueryable<TEntity> CreateFilteredQuery(TGetAllInput input)
        {
            using (UnitOfWorkManager.Current.DisableFilter(AbpDataFilters.SoftDelete))
            {
                return base.CreateFilteredQuery(input)
                    .WhereIf(input.IsDeleted.HasValue, m => m.IsDeleted == input.IsDeleted.Value)
                    .WhereIf(!string.IsNullOrEmpty(input.Name), m => m.Name.Contains(input.Name));
            }

        }        
    }
}
