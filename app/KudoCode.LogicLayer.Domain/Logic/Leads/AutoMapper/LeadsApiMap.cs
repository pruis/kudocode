using AutoMapper;
using KudoCode.LogicLayer.Domain.Logic.Leads.Entities;
using KudoCode.LogicLayer.Domain.Logic.Lookups.Entities;
using KudoCode.LogicLayer.Dtos.Leads;
using KudoCode.LogicLayer.Dtos.LeadScheduledActivities;
using KudoCode.LogicLayer.Dtos.Lookups;
using Microsoft.Extensions.Configuration;
using System;
using System.Globalization;

namespace KudoCode.LogicLayer.Domain.Logic.Leads.AutoMapper
{
	public class LeadsApiMap : Profile
	{
		public LeadsApiMap(IConfiguration configuration)
		{

			CreateMap<Gender, GenderDto>();
			CreateMap<Occupation, OccupationDto>();
			CreateMap<CurrentAdvisor, CurrentAdvisorDto>();

			//Source : Destination
			CreateMap<CreateLeadRequest, Lead>()
				.ForMember(d => d.Id, o => o.Ignore())
				.ForMember(d => d.LeadScheduledActivities, o => o.Ignore())
				.ForMember(d => d.AgentId, o => o.Ignore())
				.ForMember(d => d.Name,
					o => o.MapFrom(s => $"{s.LeadPersonalInformation.FirstName} {s.LeadPersonalInformation.Surname}"))
				.ForMember(d => d.Email, o => o.MapFrom(s => s.LeadPersonalInformation.Email))
				;

			CreateMap<UpdateLeadRequest, Lead>()
				//.ForMember(d => d.Id, o => o.Ignore())
				.ForMember(d => d.LeadScheduledActivities, o => o.Ignore())
				.ForMember(d => d.AgentId, o => o.Ignore())
				.ForMember(d => d.Name,
					o => o.MapFrom(s => $"{s.LeadPersonalInformation.FirstName} {s.LeadPersonalInformation.Surname}"))
				.ForMember(d => d.Email, o => o.MapFrom(s => s.LeadPersonalInformation.Email))
				;

			CreateMap<Lead, GetLeadResponse>();
			CreateMap<LeadPersonalInformation, LeadPersonalInformationDto>();

			CreateMap<LeadScheduledActivity, GetLeadScheduledActivityResponse>()
				.ForMember(d => d.AppointmentDateTime,
					o => o.MapFrom(s => s.AppointmentDateTime.ToString(configuration["DateTimeFormat"])))
				;

			CreateMap<Address, AddressDto>()
				.ForMember(d => d.AddressTypes, o => o.Ignore())
				;

			//Update Create Inbound

			CreateMap<GetLeadResponse, Lead>()
				;

			CreateMap<LeadPersonalInformationDto, LeadPersonalInformation>()
				.ForMember(d => d.Id, o => o.Ignore())
				;
			CreateMap<AddressDto, Address>()
				.ForMember(d => d.AddressType, o => o.Ignore())
				;

			CreateMap<CreateGetLeadScheduledActivityRequest, LeadScheduledActivity>()
				.ForMember(d => d.Id, o => o.Ignore())
				.ForMember(d => d.Lead, o => o.Ignore())
				.ForMember(d => d.LeadId, o => o.MapFrom(s => s.LeadId))
				.ForMember(d => d.LeadScheduledActivityType, o => o.Ignore())
				.ForMember(d => d.AppointmentDateTime,
					o => o.MapFrom(s => DateTime.Parse(s.AppointmentDateTime, CultureInfo.InvariantCulture)))
				;

			CreateMap<UpdateGetLeadScheduledActivityRequest, LeadScheduledActivity>()
				.ForMember(d => d.Id, o => o.Ignore())
				.ForMember(d => d.Lead, o => o.Ignore())
				.ForMember(d => d.LeadId, o => o.Ignore())
				.ForMember(d => d.LeadScheduledActivityType, o => o.Ignore())
				.ForMember(d => d.AppointmentDateTime,
					o => o.MapFrom(s => DateTime.Parse(s.AppointmentDateTime, CultureInfo.InvariantCulture)))
				;

			CreateMap<LeadScheduledActivityType, LeadScheduledActivityTypeDto>();
		}
	}
}