using AutoMapper;
using KudoCode.LogicLayer.Dtos.Leads;
using KudoCode.LogicLayer.Dtos.LeadScheduledActivities;
using KudoCode.Web.Application.Models;
using KudoCode.Web.Application.Models.Leads;
using KudoCode.Web.Application.Models.Lead;
using KudoCode.Web.Application.Models.LeadScheduledActivity;

namespace KudoCode.Web.Application.AutoMapper
{
	public class LeadsWebMap : Profile
	{
		public LeadsWebMap()
		{

			CreateMap<GetLeadResponse, LeadViewModel>()
				.ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
				.ForMember(d => d.Age, o => o.MapFrom(s => s.LeadPersonalInformation.Age))
				.ForMember(d => d.Cellphone, o => o.MapFrom(s => s.LeadPersonalInformation.Cellphone))
				.ForMember(d => d.CurrentAdvisorId, o => o.MapFrom(s => s.LeadPersonalInformation.CurrentAdvisorId))
				.ForMember(d => d.Email, o => o.MapFrom(s => s.LeadPersonalInformation.Email))
				.ForMember(d => d.FirstName, o => o.MapFrom(s => s.LeadPersonalInformation.FirstName))
				.ForMember(d => d.FreeWill, o => o.MapFrom(s => s.LeadPersonalInformation.FreeWill))
				.ForMember(d => d.Landline, o => o.MapFrom(s => s.LeadPersonalInformation.Landline))
				.ForMember(d => d.OccupationId, o => o.MapFrom(s => s.LeadPersonalInformation.OccupationId))
				.ForMember(d => d.Surname, o => o.MapFrom(s => s.LeadPersonalInformation.Surname))
				.ForMember(d => d.GenderId, o => o.MapFrom(s => s.LeadPersonalInformation.GenderId)).ReverseMap();
				;

			CreateMap<CreateLeadRequest, LeadViewModel>()
				.ForMember(d => d.Id, o => o.MapFrom(s => 0))
				.ForMember(d => d.Age, o => o.MapFrom(s => s.LeadPersonalInformation.Age))
				.ForMember(d => d.Cellphone, o => o.MapFrom(s => s.LeadPersonalInformation.Cellphone))
				.ForMember(d => d.CurrentAdvisorId, o => o.MapFrom(s => s.LeadPersonalInformation.CurrentAdvisorId))
				.ForMember(d => d.Email, o => o.MapFrom(s => s.LeadPersonalInformation.Email))
				.ForMember(d => d.FirstName, o => o.MapFrom(s => s.LeadPersonalInformation.FirstName))
				.ForMember(d => d.FreeWill, o => o.MapFrom(s => s.LeadPersonalInformation.FreeWill))
				.ForMember(d => d.Landline, o => o.MapFrom(s => s.LeadPersonalInformation.Landline))
				.ForMember(d => d.OccupationId, o => o.MapFrom(s => s.LeadPersonalInformation.OccupationId))
				.ForMember(d => d.Surname, o => o.MapFrom(s => s.LeadPersonalInformation.Surname))
				.ForMember(d => d.GenderId, o => o.MapFrom(s => s.LeadPersonalInformation.GenderId)).ReverseMap();
				;
			CreateMap<UpdateLeadRequest, LeadViewModel>()
				.ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
				.ForMember(d => d.Age, o => o.MapFrom(s => s.LeadPersonalInformation.Age))
				.ForMember(d => d.Cellphone, o => o.MapFrom(s => s.LeadPersonalInformation.Cellphone))
				.ForMember(d => d.CurrentAdvisorId, o => o.MapFrom(s => s.LeadPersonalInformation.CurrentAdvisorId))
				.ForMember(d => d.Email, o => o.MapFrom(s => s.LeadPersonalInformation.Email))
				.ForMember(d => d.FirstName, o => o.MapFrom(s => s.LeadPersonalInformation.FirstName))
				.ForMember(d => d.FreeWill, o => o.MapFrom(s => s.LeadPersonalInformation.FreeWill))
				.ForMember(d => d.Landline, o => o.MapFrom(s => s.LeadPersonalInformation.Landline))
				.ForMember(d => d.OccupationId, o => o.MapFrom(s => s.LeadPersonalInformation.OccupationId))
				.ForMember(d => d.Surname, o => o.MapFrom(s => s.LeadPersonalInformation.Surname))
				.ForMember(d => d.GenderId, o => o.MapFrom(s => s.LeadPersonalInformation.GenderId)).ReverseMap();
				;

			//Get
			CreateMap<GetLeadScheduledActivityResponse, LeadScheduledActivityViewModel>().ReverseMap();
			//Post
			CreateMap<LeadScheduledActivityViewModel, CreateGetLeadScheduledActivityRequest>();
			CreateMap<LeadScheduledActivityViewModel,UpdateGetLeadScheduledActivityRequest>();
		}
	}
}