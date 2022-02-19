using Autofac;
using AutoMapper;
using FluentValidation;
using KudoCode.Contracts;
using KudoCode.Contracts.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KudoCode.LogicLayer.Domain
{

	public class TableAInterceptDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public DateTime DOB { get; set; }
		public VxLookup Gender { get; set; }
	}

	public class SaveTableConfigValidationHandler : AbstractValidator<TableAInterceptDto>
	{
		public SaveTableConfigValidationHandler()
		{
			RuleFor(x => x.Name).NotEmpty().NotNull();
		}
	}
	public class GetTableAInterceptor : DynamicInterceptBase<TableAInterceptDto, GetDynamicResponse>
	{
		public GetTableAInterceptor(ILifetimeScope scope, IExecutionPipelineContext<GetDynamicResponse> executionPipelineContext)
			: base(scope, executionPipelineContext)
		{

		}
		public override void Handle(TableAInterceptDto data)
		{
		}
	}
	public class SaveTableAInterceptor : DynamicInterceptBase<TableAInterceptDto, SaveDynamicResponse>
	{
		private IExecutionPipelineContext<SaveDynamicResponse> _context;

		public SaveTableAInterceptor(ILifetimeScope scope, IExecutionPipelineContext<SaveDynamicResponse> context)
			: base(scope, context)
		{
			_context = context;
		}
		public override void Handle(TableAInterceptDto data)
		{
		}
	}
	public class ListTableAInterceptor : DynamicInterceptBase<List<string>, ListDynamicResponse>
	{
		private IExecutionPipelineContext<ListDynamicResponse> _context;

		public ListTableAInterceptor(ILifetimeScope scope, IExecutionPipelineContext<ListDynamicResponse> context)
			: base(scope, context)
		{
			_context = context;
		}
		public override void Handle(List<string> data)
		{
		}
	}
}
