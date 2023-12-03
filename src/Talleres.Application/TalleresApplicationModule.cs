using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Talleres.Authorization;

namespace Talleres
{
    [DependsOn(
        typeof(TalleresCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class TalleresApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<TalleresAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(TalleresApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                config =>
                {
                    config.AddMaps(thisAssembly);

                    config.CreateMap<BrandDto, Brand>().ReverseMap();
                    config.CreateMap<ModelDto, Model>().ReverseMap();
                    config.CreateMap<UpdateModelInput, Model>().ReverseMap();
                    config.CreateMap<CreateEquipmentInput, Equipment>().ForMember(e => e.Reference, options => options.MapFrom(input => input.ReferenceAssigned));
                    config.CreateMap<EquipmentDto, Equipment>().ReverseMap();
                    config.CreateMap<CreateEquipmentCycleInput, EquipmentCycle>().ReverseMap();

                    config.CreateMap<Equipment, EquipmentDto>()
                          .ForMember(u => u.BrandAssigned, options => options.MapFrom(input => input.BrandAssigned.Name))
                          .ForMember(u => u.ModelAssigned, options => options.MapFrom(input => input.ModelAssigned.Name))
                          .ForMember(u => u.ReferenceAssigned, options => options.MapFrom(input => input.Reference))
                          .ForMember(m => m.Reference, opt => opt.ConvertUsing(new EquipmentFormatter(), src => src));

                    config.CreateMap<Comment, CommentDto>()
                        .ForMember(u => u.CreatorUser, options => options.MapFrom(input => input.CreatorUser.FullName));
                }
            );
        }
    }
}
