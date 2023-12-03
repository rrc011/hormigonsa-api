using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace Talleres.Authorization
{
    public class TalleresAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Users_Activation, L("UsersActivation"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);

            var brands = context.CreatePermission(PermissionNames.Brands, L("Brands"));
            brands.CreateChildPermission(PermissionNames.Brands_Create, L("Crear marcas"));
            brands.CreateChildPermission(PermissionNames.Brands_Update, L("Actualizar marcas"));
            brands.CreateChildPermission(PermissionNames.Brands_Delete, L("Borrar marcas"));
            brands.CreateChildPermission(PermissionNames.Brands_Get, L("Buscar marcas"));

            var models = context.CreatePermission(PermissionNames.Models, L("Models"));
            models.CreateChildPermission(PermissionNames.Models_Create, L("Crear modelos"));
            models.CreateChildPermission(PermissionNames.Models_Update, L("Actualizar modelos"));
            models.CreateChildPermission(PermissionNames.Models_Delete, L("Borrar modelos"));
            models.CreateChildPermission(PermissionNames.Models_Get, L("Buscar modelos"));

            var equipments = context.CreatePermission(PermissionNames.Equipments, L("Equipments"));
            equipments.CreateChildPermission(PermissionNames.Equipments_Create, L("Crear equipos"));
            equipments.CreateChildPermission(PermissionNames.Equipments_Update, L("Actualizar equipos"));
            equipments.CreateChildPermission(PermissionNames.Equipments_Delete, L("Borrar equipos"));
            equipments.CreateChildPermission(PermissionNames.Equipments_Get, L("Buscar equipos"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, TalleresConsts.LocalizationSourceName);
        }
    }
}
