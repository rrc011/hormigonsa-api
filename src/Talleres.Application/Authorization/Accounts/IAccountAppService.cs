using System.Threading.Tasks;
using Abp.Application.Services;
using Talleres.Authorization.Accounts.Dto;

namespace Talleres.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
