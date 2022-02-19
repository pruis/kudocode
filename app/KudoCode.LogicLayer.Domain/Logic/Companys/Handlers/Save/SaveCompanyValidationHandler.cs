using KudoCode.LogicLayer.Dtos.Companys;
using FluentValidation;
using KudoCode.LogicLayer.Dtos.Companys.Outbound;

namespace KudoCode.LogicLayer.Domain.Logic.Companys.Handlers.Save
{
	public class SaveCompanyValidationHandler : AbstractValidator<SaveCompanyRequest>
	{
		public SaveCompanyValidationHandler()
		{
			RuleFor(x => x).NotEmpty().NotNull();
		}
	}
}


