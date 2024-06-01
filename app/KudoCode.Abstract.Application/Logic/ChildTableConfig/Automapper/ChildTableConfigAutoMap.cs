using AutoMapper;
using KudoCode.Abstract.Application;
using KudoCode.Contracts;

namespace KudoCode.Abstract.Application
{
	public class ChildTableConfigAutoMap : Profile
	{
		public ChildTableConfigAutoMap()
		{
			CreateMap<Contracts.ChildTableConfig, GetChildTableConfigRequest>();
			CreateMap<ChildTableConfig, GetChildTableConfigResponse>();

			CreateMap<ChildTableConfig, SaveChildTableConfigResponse>();
			CreateMap<SaveChildTableConfigRequest, ChildTableConfig>();
			CreateMap<ChildTableConfig, SaveChildTableConfigResponse>();

			CreateMap<Contracts.ChildTableConfig, ChildTableConfig>().ReverseMap();
			CreateMap<Contracts.ChildTableConfig, ChildTableConfig>().ReverseMap();
		}
	}
}