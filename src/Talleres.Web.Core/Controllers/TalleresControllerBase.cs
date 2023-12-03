using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace Talleres.Controllers
{
    public abstract class TalleresControllerBase: AbpController
    {
        protected TalleresControllerBase()
        {
            LocalizationSourceName = TalleresConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
