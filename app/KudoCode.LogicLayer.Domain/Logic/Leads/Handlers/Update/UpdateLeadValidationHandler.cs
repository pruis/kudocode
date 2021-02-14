using KudoCode.LogicLayer.Dtos.Leads;
using FluentValidation;

namespace KudoCode.LogicLayer.Domain.Logic.Leads.Handlers.Update
{
	public class UpdateLeadValidationHandler : AbstractValidator<UpdateLeadRequest>
	{
		public UpdateLeadValidationHandler()
		{
			RuleFor(x => x.LeadPersonalInformation).NotEmpty();
			RuleFor(x => x.LeadPersonalInformation.FirstName).NotEmpty();
			RuleFor(x => x.LeadPersonalInformation.Surname).NotEmpty();
			RuleFor(x => x.LeadPersonalInformation.Email).NotEmpty();
			RuleFor(x => x.LeadPersonalInformation.GenderId).GreaterThan(0);
			RuleFor(x => x.LeadPersonalInformation.CurrentAdvisorId).GreaterThan(0);
		}
	}
}