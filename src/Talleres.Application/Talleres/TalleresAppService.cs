using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Linq.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Talleres
{
    public abstract class TalleresAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput> : AsyncCrudAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput>
       where TEntity : Entity<TPrimaryKey>, IEntity<TPrimaryKey>, ISoftDelete
       where TEntityDto : IEntityDto<TPrimaryKey>
       where TGetAllInput : GetAllInput
       where TUpdateInput : IEntityDto<TPrimaryKey>
    {

        public TalleresAppService(IRepository<TEntity, TPrimaryKey> repository) : base(repository) { }

        protected override IQueryable<TEntity> CreateFilteredQuery(TGetAllInput input)
        {

            return base.CreateFilteredQuery(input)
                .WhereIf(input.IsDeleted.HasValue, m => m.IsDeleted == input.IsDeleted.Value);
        }

        [UnitOfWork]
        public async Task Activate(TPrimaryKey id)
        {
            var entity = await Repository.GetAsync(id);

            if (entity == null)
            {
                throw new EntityNotFoundException();
            }

            entity.IsDeleted = false;
        }

        public virtual async Task<ListResultDto<TEntityDto>> GetAllActive()
        {
            var entities = await Repository.GetAllListAsync(m => !m.IsDeleted);

            var dtos = ObjectMapper.Map<List<TEntityDto>>(entities);

            return await Task.FromResult(new ListResultDto<TEntityDto>(dtos));
        }
    }


    public abstract class TalleresAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput> : AsyncCrudAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput>
       where TEntity : Entity<TPrimaryKey>, IEntity<TPrimaryKey>, ISoftDelete
       where TEntityDto : IEntityDto<TPrimaryKey>
       where TGetAllInput : GetAllInput
    {
        public TalleresAppService(IRepository<TEntity, TPrimaryKey> repository) : base(repository) { }

        protected override IQueryable<TEntity> CreateFilteredQuery(TGetAllInput input)
        {

            return base.CreateFilteredQuery(input)
                .WhereIf(input.IsDeleted.HasValue, m => m.IsDeleted == input.IsDeleted.Value);
        }

        public virtual async Task<ListResultDto<TEntityDto>> GetAllActive()
        {
            var entities = await Repository.GetAllListAsync(m => !m.IsDeleted);

            var dtos = ObjectMapper.Map<List<TEntityDto>>(entities);

            return await Task.FromResult(new ListResultDto<TEntityDto>(dtos));
        }
    }
}
