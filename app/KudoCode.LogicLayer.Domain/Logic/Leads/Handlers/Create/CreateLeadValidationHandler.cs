using KudoCode.LogicLayer.Dtos.Leads;
using FluentValidation;
using KudoCode.LogicLayer.Infrastructure;
using KudoCode.LogicLayer.Infrastructure.Domain;

namespace KudoCode.LogicLayer.Domain.Logic.Leads.Handlers.Create
{
	public class CreateLeadValidationHandler : AbstractValidator<CreateLeadRequest>
	{
		public CreateLeadValidationHandler()
		{
			RuleFor(x => x.LeadPersonalInformation).NotEmpty();
			RuleFor(x => x.LeadPersonalInformation.FirstName).NotEmpty();
			RuleFor(x => x.LeadPersonalInformation.Surname).NotEmpty();
			RuleFor(x => x.LeadPersonalInformation.Email).IsEmailAddress();
			RuleFor(x => x.LeadPersonalInformation.GenderId).GreaterThan(0);
			RuleFor(x => x.LeadPersonalInformation.CurrentAdvisorId).GreaterThan(0);
		}
	}
}