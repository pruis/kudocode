using AutoMapper;
using KudoCode.LogicLayer.Domain.Logic.Companys.Entities;
using KudoCode.LogicLayer.Dtos.Comanys.Outbound;
using KudoCode.LogicLayer.Dtos.Companys.Outbound;
using KudoCode.LogicLayer.Dtos.Portfolios.Outbound;
using System;

namespace KudoCode.LogicLayer.Domain.Logic.Companys.AutoMapper
{
	public class CompaniesAutoMap : Profile
	{
		public CompaniesAutoMap()
		{
			CreateMap<Company, GetCompanyResponse>();
			CreateMap<Company, CompanyResponse>();
			CreateMap<SaveCompanyRequest, Company>();
		}
	}
}