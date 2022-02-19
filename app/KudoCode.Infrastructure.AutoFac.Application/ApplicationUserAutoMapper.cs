using AutoMapper;
using KudoCode.Contracts.Api;
using KudoCode.Contracts;

namespace KudoCode.Infrastructure.AutoFac.Application
{
    public class ApplicationUserAutoMapper : Profile
    {
        public ApplicationUserAutoMapper()
        {
            CreateMap<ApplicationUser, ApplicationUserDto>()
                .AfterMap((src, dest) => dest.AuthorizationGroups.RemoveAll(item => item == null))
                .AfterMap((src, dest) => dest.EntityOrganizations.RemoveAll(item => item == null))
                .ReverseMap();

            CreateMap<RegisterApplicationUserDto, ApplicationUser>().ForMember(a => a.Password, e => e.Ignore());
            CreateMap<ApplicationUserDto, ApplicationUserContext>().ForMember(a => a.Token, e => e.Ignore());
            CreateMap<AuthorizationGroup, AuthorizationGroupDto>()
                .ForMember(dst => dst.Id, e => e.MapFrom(src => src.Id))
                .ReverseMap();

            CreateMap<EntityOrganization, EntityOrganizationDto>().ReverseMap();
            CreateMap<JwtToken, TokenDto>()
                //.ForMember(a => a., e => e.Ignore()),
                ;

            CreateMap<ApplicationUserAuthorizationGroupMap, AuthorizationGroupDto>()
                .ForMember(dst => dst.Id, e => e.MapFrom(src => src.AuthorizationGroupId))
                .ConstructUsing(
                    (src, context) =>
                    {
                        var dest = context.Mapper.Map<AuthorizationGroupDto>(src.AuthorizationGroup);
                        return dest;
                    });

            CreateMap<AuthorizationRole, AuthorizationRoleDto>();
            CreateMap<ApplicationUserEntityOrganizationMap, EntityOrganizationDto>()
                .ConstructUsing(
                    (src, context) =>
                    {
                        var dest = context.Mapper.Map<EntityOrganizationDto>(src.EntityOrganization);
                        return dest;
                    });

            CreateMap<ApplicationUserDtoBasic, ApplicationUser>().ReverseMap();
        }
    }

    public class ApiResponseContextDtoAutoMapper : Profile
    {
        public ApiResponseContextDtoAutoMapper()
        {

            //CreateMap<typeof(ExecutionPipelineContext<>), IAnotherClass>().As<AnotherClass>()

            CreateMap(typeof(IExecutionPipelineContext<>), typeof(ApiResponseContextDto<>));
            CreateMap(typeof(IExecutionPipelineContext<>), typeof(IApiResponseContextDto<>)).As(typeof(ApiResponseContextDto<>));
            //CreateMap(typeof(ExecutionPipelineContext<>), typeof(ApiResponseContextDto<>));

            //CreateMap<IExecutionPipelineContext<>, IApiResponseContextDto<>>();
            CreateMap<ApplicationUserDtoBasic, ApplicationUser>().ReverseMap();
            //CreateMap<IExecutionPipelineContext<>, IExecutionPipelineContext<> >().ReverseMap();
        }
    }
}