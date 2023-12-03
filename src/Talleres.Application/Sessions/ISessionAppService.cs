using System.Threading.Tasks;
using Abp.Application.Services;
using Talleres.Sessions.Dto;

namespace Talleres.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
