using AutoMapper;
using KudoCode.Abstract.Application;
using KudoCode.Contracts;

namespace KudoCode.Abstract.Application
{
	public class PropertyConfigAutoMap : Profile
	{
		public PropertyConfigAutoMap()
		{
			CreateMap<Contracts.PropertyConfig, GetPropertyConfigRequest>();
			CreateMap<PropertyConfig, GetPropertyConfigResponse>();

			CreateMap<PropertyConfig, SavePropertyConfigResponse>();
			CreateMap<SavePropertyConfigRequest, PropertyConfig>();
			CreateMap<PropertyConfig, SavePropertyConfigResponse>();

			CreateMap<Contracts.PropertyConfig, PropertyConfig>().ReverseMap();
			CreateMap<Contracts.PropertyConfig, PropertyConfig>().ReverseMap();
		}
	}
}