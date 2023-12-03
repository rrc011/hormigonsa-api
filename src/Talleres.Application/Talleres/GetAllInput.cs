using Abp.Application.Services.Dto;
using Abp.Runtime.Validation;

namespace Talleres
{
    [DisableValidation]
    public class GetAllInput : PagedAndSortedResultRequestDto
    {
        public bool? IsDeleted { get; set; }
    }
}
