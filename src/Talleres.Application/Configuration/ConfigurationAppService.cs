using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using Talleres.Configuration.Dto;

namespace Talleres.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : TalleresAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
