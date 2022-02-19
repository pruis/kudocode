using AutoMapper;
using KudoCode.Contracts.Api;
using KudoCode.Contracts;

namespace CodeGenerator.Service
{
	public class CodeGenAutoMapper : Profile
    {
        public CodeGenAutoMapper()
        {
        }
    }
    
    public class ApiResponseContextDtoAutoMapper : Profile
    {
        public ApiResponseContextDtoAutoMapper()
        {
            //CreateMap(typeof(IExecutionPipelineContext<>), typeof(IApiResponseContextDto<>));
            CreateMap(typeof(ExecutionPipelineContext<>), typeof(IApiResponseContextDto<>));
            //CreateMap<IExecutionPipelineContext<>, IApiResponseContextDto<>>();
            //CreateMap<ApplicationUserDtoBasic, ApplicationUser>().ReverseMap();
            //CreateMap<IExecutionPipelineContext<>, IExecutionPipelineContext<> >().ReverseMap();
        }
    }
}