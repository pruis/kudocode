using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KudoCode.LogicLayer.Infrastructure.Dtos.Messages;
using KudoCode.Web.Infrastructure.Blazor.Infrastructure.Interfaces;
using KudoCode.Web.Infrastructure.Domain;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using Microsoft.JSInterop;
using ServiceStack;

namespace KudoCode.Web.Infrastructure.Blazor.Infrastructure
{
	public abstract class KudoCodePageComponent : KudoCodeComponent, IKudoCodePageComponent
	{
		public static List<NavObj> _renderFragments = new List<NavObj>();

		public RenderFragment RenderFragment;

		protected KudoCodePageComponent()
		{
			Messages = new List<MessageDto>();
		}

		[Inject] public IKudoCodeNavigation Navigation { get; set; }
		[Inject] public IConfiguration Configuration { get; set; }
		[Inject] public IJSRuntime JsRuntime { get; set; }

		protected List<MessageDto> Messages { get; set; }


		protected override Task OnAfterRenderAsync(bool firstRender)
		{
			return RenderMessages();
		}

		protected Task RenderMessages()
		{
			return Task.Run(() =>
			{
				if (Messages != null)
					ToastMessage(Messages.ToArray());
				Messages = new List<MessageDto>();
			});
		}


		public void ToastMessage(params MessageDto[] messages)
		{
			foreach (var x in messages.Where(a => a.Type == MessageDtoType.Error))
				JsRuntime.InvokeAsync<string>($"Toast.error", $"{x.Message}", $"{x.Key}: error");

			foreach (var x in messages.Where(a => a.Type == MessageDtoType.Success))
				JsRuntime.InvokeAsync<string>($"Toast.success", $"{x.Message}", $"{x.Key}: success");

			foreach (var x in messages.Where(a => a.Type == MessageDtoType.Warning))
				JsRuntime.InvokeAsync<string>($"Toast.warning", $"{x.Message}", $"{x.Key}: warning");

			foreach (var x in messages.Where(a => a.Type == MessageDtoType.Information))
				JsRuntime.InvokeAsync<string>($"Toast.information", $"{x.Message}", $"{x.Key}: information");
		}

		public void GoTo(Type type, params (string, object)[] parameters)
		{
			_renderFragments.Add(new NavObj() {Type = type, Params = parameters});
			LoadComponent(ref RenderFragment, type, parameters);
		}

		public void Back()
		{
			if (_renderFragments.Count > 1)
				_renderFragments.Remove(_renderFragments.Last());
			LoadComponent(ref RenderFragment, _renderFragments.Last().Type, _renderFragments.Last().Params);
		}
	}

	public class NavObj
	{
		public Type Type { get; set; }
		public (string, object)[] Params { get; set; }
	}
}