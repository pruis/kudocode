using System;
using KudoCode.Web.Infrastructure.Blazor.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Components;

namespace KudoCode.Web.Infrastructure.Blazor.Infrastructure
{
    public abstract class KudoCodeComponent : ComponentBase, IKudoCodeComponent
    {
        public void LoadComponent(ref RenderFragment fragment, Type type, params (string, object)[] parameters)
        {
            fragment = builder =>
            {
                var seq = 0;
                builder.OpenComponent(seq, type);

                foreach (var (key, value) in parameters)
                    builder.AddAttribute(++seq, key, value);
    
                //builder.AddAttribute(7, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, IncrementCount));
                
                builder.CloseComponent();
                
            };
        }
    };
}