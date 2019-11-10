using KudoCode.LogicLayer.Dtos.Leads.GetLead;
using FluentValidation;

namespace KudoCode.LogicLayer.Domain.Logic.Leads.Handlers.Get
{
	public class GetLeadValidationHandler : AbstractValidator<GetLeadRequest>
	{
		public GetLeadValidationHandler()
		{
			RuleFor(x => x.Id).NotEmpty();
		}
	}
}

