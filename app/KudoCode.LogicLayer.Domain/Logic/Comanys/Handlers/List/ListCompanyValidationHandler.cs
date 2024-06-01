using KudoCode.LogicLayer.Dtos.Comanys;
using FluentValidation;
using KudoCode.LogicLayer.Dtos.Comanys.Outbound;

namespace KudoCode.LogicLayer.Domain.Logic.Companys.Handlers.List
{
	public class ListCompanyValidationHandler : AbstractValidator<ListCompanyRequest>
	{
		public ListCompanyValidationHandler()
		{
			RuleFor(x => x).NotEmpty().NotNull();
		}
	}
}


