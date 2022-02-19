using KudoCode.LogicLayer.Dtos.Companys;
using FluentValidation;
using KudoCode.LogicLayer.Dtos.Companys.Outbound;

namespace KudoCode.LogicLayer.Domain.Logic.Companys.Handlers.Delete
{
	public class DeleteCompanyValidationHandler : AbstractValidator<DeleteCompanyRequest>
	{
		public DeleteCompanyValidationHandler()
		{
			RuleFor(x => x).NotEmpty().NotNull();
		}
	}
}


