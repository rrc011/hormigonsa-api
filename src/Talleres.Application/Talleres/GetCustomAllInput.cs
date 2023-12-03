using Abp.Application.Services.Dto;

namespace Talleres
{
    public class GetCustomAllInput : GetAllInput
    {
        public string Name { get; set; }
    }

    public class GetWarehouseInput : PagedAndSortedResultRequestDto
    {
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
