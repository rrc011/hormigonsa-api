using Abp.Application.Services;
using Abp.Domain.Repositories;
using System.Linq;
using System.Threading.Tasks;
using Talleres.Talleres.Equipment.Dto;
using Abp.Linq.Extensions;
using Abp.Application.Services.Dto;
using Talleres.Authorization.Users;

namespace Talleres
{
    public class EquipmentCycleAppService : AsyncCrudAppService<EquipmentCycle, EquipmentCycleDto, int, GetAllEquipmentCycleInput, CreateEquipmentCycleInput>
    {
        private readonly IRepository<Comment> commentRepository;
        private readonly UserManager userManager;
        private readonly IRepository<Equipment> equipmentRepository;

        public EquipmentCycleAppService(IRepository<EquipmentCycle, int> repository, 
            IRepository<Comment> commentRepository, UserManager userManager, 
            IRepository<Equipment> equipmentRepository) : base(repository)
        {
            this.commentRepository = commentRepository;
            this.userManager = userManager;
            this.equipmentRepository = equipmentRepository;
        }

        public override async Task<EquipmentCycleDto> CreateAsync(CreateEquipmentCycleInput input)
        {
            var result = await base.CreateAsync(input);

            var equipment = await equipmentRepository.GetAsync(input.EquipmentId);

            var horometer = result.HorometerTo - result.HorometerFrom;

            equipment.Horometer += horometer;

            await commentRepository.InsertAsync(new Comment
            {
                Description = input.Comment,
                OriginId = result.GuidReg,
            });

            return result;
        }

        protected override IQueryable<EquipmentCycle> CreateFilteredQuery(GetAllEquipmentCycleInput input)
        {
            return base.CreateFilteredQuery(input).Where(x => x.EquipmentId == input.EquipmentId)
                .WhereIf(input.To.HasValue, m => m.CreationTime.Date <= input.To.Value.Date)
                .WhereIf(input.From.HasValue, m => m.CreationTime.Date >= input.From.Value.Date);
        }

        public override async Task<PagedResultDto<EquipmentCycleDto>> GetAllAsync(GetAllEquipmentCycleInput input)
        {
            var result =  await base.GetAllAsync(input);

            foreach (var item in result.Items)
            {
                var user = new User();
                if (item.CreatorUserId > 0) user = await userManager.GetUserByIdAsync(item.CreatorUserId);

                item.UserName = user.Id > 0 ? user.FullName : "N/A";
            }

            return result;
        }
    }
}
