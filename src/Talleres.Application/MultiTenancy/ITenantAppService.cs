using Abp.Application.Services;
using Talleres.MultiTenancy.Dto;

namespace Talleres.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

