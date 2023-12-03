using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Microsoft.EntityFrameworkCore;
using Talleres.Authorization;
using static Talleres.Constants;

namespace Talleres
{
    public partial class EquipmentAppService : TalleresAppService<Equipment, EquipmentDto, int, GetAllEquipmentInput, CreateEquipmentInput, UpdateEquipmentInput>
    {        
        private readonly IRepository<Equipment> _repository;

        public EquipmentAppService(
            IRepository<Brand> brandRepository,
            IRepository<Model> modelRepository,
            IRepository<Equipment> repository
            ) : base(repository)
        {
            this._repository = repository;
            CreatePermissionName = PermissionNames.Equipments_Create;
            UpdatePermissionName = PermissionNames.Equipments_Update;
            DeletePermissionName = PermissionNames.Equipments_Delete;
            GetAllPermissionName = PermissionNames.Equipments_Get;
            GetPermissionName = PermissionNames.Equipments_Get;
        }

        [AbpAuthorize(PermissionNames.Equipments_Get)]
        public override async Task<EquipmentDto> GetAsync(EntityDto<int> input)
        {
            var equipment = await Repository.GetAllIncluding(
                m => m.ModelAssigned,
                m => m.BrandAssigned
                ).AsNoTracking().FirstOrDefaultAsync(m => m.Id == input.Id && !m.IsDeleted);

            var equipmentDto = ObjectMapper.Map<EquipmentDto>(equipment);

            return equipmentDto;
        }

        [AbpAuthorize(PermissionNames.Equipments_Get)]
        public override async Task<ListResultDto<EquipmentDto>> GetAllActive()
        {
            var entities = await _repository.GetAllIncluding(
                m => m.ModelAssigned,
                m => m.BrandAssigned
                ).Where(m => !m.IsDeleted).ToListAsync();

            var dtos = ObjectMapper.Map<List<EquipmentDto>>(entities);

            return await Task.FromResult(new ListResultDto<EquipmentDto>(dtos));
        }


        [AbpAuthorize(PermissionNames.Equipments_Update)]
        public override async Task<EquipmentDto> UpdateAsync(UpdateEquipmentInput equipmentDto)
        {
            EntityDto<int> entityDto = new EntityDto<int>
            {
                Id = equipmentDto.Id
            };
            var oldEquipment = await this.GetAsync(entityDto);

            var entity = ObjectMapper.Map<Equipment>(equipmentDto);

            entity.TenantId = AbpSession.TenantId.Value;

            var entityInserted = await _repository.UpdateAsync(entity);

            return ObjectMapper.Map<EquipmentDto>(entityInserted);
        }

        public override Task<EquipmentDto> CreateAsync(CreateEquipmentInput input)
        {
            return base.CreateAsync(input);
        }

        protected override IQueryable<Equipment> CreateFilteredQuery(GetAllEquipmentInput input)
        {
            return base.CreateFilteredQuery(input)
                .Include(m => m.ModelAssigned)
                .Include(m => m.BrandAssigned)
                .WhereIf(input.Year.HasValue, m => m.Year == input.Year)
                .WhereIf(!string.IsNullOrEmpty(input.Tab), m => m.Tab.Contains(input.Tab))
                .WhereIf(!string.IsNullOrEmpty(input.Serial), m => m.Serial.Contains(input.Serial))
                .WhereIf(!string.IsNullOrEmpty(input.Plate), m => m.Plate.Contains(input.Plate))
                .WhereIf(!string.IsNullOrEmpty(input.Chassis), m => m.Chassis.Contains(input.Chassis))
                .WhereIf(!string.IsNullOrEmpty(input.Reference), m => (m.Reference == ReferenceType.Tab && m.Tab.Contains(input.Reference)) ||
                                                                      (m.Reference == ReferenceType.Serial && m.Serial.Contains(input.Reference)) ||
                                                                      (m.Reference == ReferenceType.Plate && m.Plate.Contains(input.Reference)) ||
                                                                      (m.Reference == ReferenceType.Chassis && m.Chassis.Contains(input.Reference)));
        }
    }
}
