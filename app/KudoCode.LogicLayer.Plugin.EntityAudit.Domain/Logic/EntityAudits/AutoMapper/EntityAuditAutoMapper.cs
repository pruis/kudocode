using AutoMapper;
using KudoCode.Helpers;
using KudoCode.LogicLayer.Plugin.EntityAudit_.Dtos.Interfaces;
using KudoCode.LogicLayer.Plugin.EntityAudit_.Domain.Logic.EntityAudits.Entities;

namespace KudoCode.LogicLayer.Plugin.EntityAudit_.Domain.Logic.EntityAudits.AutoMapper
{
	public class EntityAuditAutoMapper : Profile
	{
		public EntityAuditAutoMapper()
		{
			CreateMap<ICreateEntityAuditDto, Logic.EntityAudits.Entities.EntityAudit>()
				.ForMember(dst=>dst.CreatedDate , opt=>opt.MapFrom(src=>src.CreatedDate.ToDate()));
			CreateMap<IPropertyInformationDto, PropertyInformation>();
		}
	}
}
