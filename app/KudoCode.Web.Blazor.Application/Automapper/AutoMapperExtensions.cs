using AutoMapper;
using KudoCode.Contracts;
using KudoCode.LogicLayer.Dtos.Comanys.Outbound;
using KudoCode.LogicLayer.Dtos.Companys.Outbound;
using KudoCode.LogicLayer.Dtos.Portfolios.Outbound;
using KudoCode.Contracts.Web;

namespace KudoCode.Web.Blazor.Application.AutoMapper
{
	public class AutoMapperExtensions : Profile
	{
		public AutoMapperExtensions()
		{

			CreateMap<Contracts.TableConfig, TableConfigModel>()
				.ForMember(a => a.TableConfigId, o => o.MapFrom(s => s.Id))
				;

			CreateMap<TableConfigModel, ListPropertyConfigRequest>();
			CreateMap<TableConfigModel, GetPropertyConfigResponse>();
			CreateMap<TableConfigModel, SavePropertyConfigRequest>();
			CreateMap<SaveTableConfigResponse, TableConfigModel>();

			//Map selected Item to be deleted
			CreateMap<TableConfig, DeleteTableConfigRequest>();
			//Map new ID back to EditModel (Save Success)
			CreateMap<SaveTableConfigResponse, GetTableConfigResponse>();
			//Map any other new properties to the listed Item
			CreateMap<SaveTableConfigResponse, TableConfig>();
			//Map the EditModel to Save (Save Click)
			CreateMap<GetTableConfigResponse, SaveTableConfigRequest>();
			CreateMap<TableConfig, GetTableConfigRequest>();
			CreateMap<GetTableConfigResponse, TableConfig>();


			//Map selected Item to be deleted
			CreateMap<PropertyConfig, DeletePropertyConfigRequest>();
			//Map new ID back to EditModel (Save Success)
			CreateMap<SavePropertyConfigResponse, GetPropertyConfigResponse>();
			//Map any other new properties to the listed Item
			CreateMap<SavePropertyConfigResponse, PropertyConfig>();
			//Map the EditModel to Save (Save Click)
			CreateMap<GetPropertyConfigResponse, SavePropertyConfigRequest>();
			CreateMap<PropertyConfig, GetPropertyConfigRequest>();
			CreateMap<GetPropertyConfigResponse, PropertyConfig>();


			CreateMap<TableConfigModel, ListChildTableConfigRequest>();
			CreateMap<TableConfigModel, GetChildTableConfigResponse>();
			CreateMap<TableConfigModel, SaveChildTableConfigRequest>();
			//Map selected Item to be deleted
			CreateMap<ChildTableConfig, DeleteChildTableConfigRequest>();
			//Map new ID back to EditModel (Save Success)
			CreateMap<SaveChildTableConfigResponse, GetChildTableConfigResponse>();
			//Map any other new properties to the listed Item
			CreateMap<SaveChildTableConfigResponse, ChildTableConfig>();
			//Map the EditModel to Save (Save Click)
			CreateMap<GetChildTableConfigResponse, SaveChildTableConfigRequest>();
			CreateMap<ChildTableConfig, GetChildTableConfigRequest>();
			CreateMap<GetChildTableConfigResponse, ChildTableConfig>();


			//Map selected Item to be deleted
			CreateMap<CompanyResponse, DeleteCompanyRequest>();
			//Map new ID back to EditModel (Save Success)
			CreateMap<SaveCompanyResponse, GetCompanyResponse>();
			//Map any other new properties to the listed Item
			CreateMap<SaveCompanyResponse, CompanyResponse>();
			//Map the EditModel to Save (Save Click)
			CreateMap<GetCompanyResponse, SaveCompanyRequest>();
			CreateMap<CompanyResponse, GetCompanyRequest>();
			CreateMap<GetCompanyResponse, CompanyResponse>();


			CreateMap<ApplicationUserContext, ApplicationUserContext>();

			CreateMap(typeof(ApiResponseContextDto<>), typeof(WebResponseDto<>))
				.ForMember("Configuration", o => o.Ignore())
				.ForMember("Errors", o => o.Ignore())
				.ForMember("Redirect", o => o.Ignore());
			//.ReverseMap();
		}
	}
}