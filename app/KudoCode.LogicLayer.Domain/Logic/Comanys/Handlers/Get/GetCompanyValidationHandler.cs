using KudoCode.LogicLayer.Dtos.Comanys;
using FluentValidation;
using KudoCode.LogicLayer.Dtos.Comanys.Outbound;

namespace KudoCode.LogicLayer.Domain.Logic.Companys.Handlers.Get
{
	public class GetCompanyValidationHandler : AbstractValidator<GetCompanyRequest>
	{
		public GetCompanyValidationHandler()
		{
			RuleFor(x => x).NotEmpty().NotNull();
		}
	}
}


