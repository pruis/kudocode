using FluentValidation;
using KudoCode.Abstract.Application;
using KudoCode.Contracts.Api;
using KudoCode.Contracts;
using System;
using System.Linq;

namespace KudoCode.LogicLayer.Infrastructure.Domain.Logic.Lookup.Handlers.GetLookups
{
	public class GetLookupsDtoValidationHandler : AbstractValidator<GetLookupRequest>
	{
		public GetLookupsDtoValidationHandler(IGetLookupRequestContext requestContext)
		{
			RuleForEach(x => x.Lookups).SetValidator(new LookupItemValidator(requestContext));
		}
	}

	public class LookupItemValidator : AbstractValidator<LookupRequest>
	{
		public LookupItemValidator(IGetLookupRequestContext requestContext)
		{
			RuleFor(x => x.Type).NotContainSpecialCharacters();
			RuleFor(x => x.Key).NotContainSpecialCharacters();
			RuleFor(x => x.Value).NotContainSpecialCharacters();
			RuleFor(x => Replace(x))
				.NotContainSpecialCharacters();

			RuleFor(x => x.Type)
				.Must(x => requestContext.Lookups.List.Select(a => a.Name).Contains(x))
				.WithMessage(x => $"Invalid lookup {x.Type}");
		}

		private static string Replace(LookupRequest x)
		{
			return x.Filter == null ? "" : x.Filter.Replace(" = ", String.Empty);
		}
	}
}