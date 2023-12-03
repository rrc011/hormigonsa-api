using System.Threading.Tasks;
using Talleres.Configuration.Dto;

namespace Talleres.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
