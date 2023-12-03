using Abp.Authorization;
using Talleres.Authorization.Roles;
using Talleres.Authorization.Users;

namespace Talleres.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
