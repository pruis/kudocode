using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using KudoCode.Abstract.Web.Blazor;

namespace KudoCode.Abstract.Web.Blazor
{
    public class InputCheckboxMultipleComponent<T> : VxInputBase<T>
    {
        /// <summary>
        /// Gets or sets the child content to be rendering inside the select element.
        /// </summary>
        [Parameter] public RenderFragment ChildContent { get; set; }

        List<VxInputCheckbox> Checkboxes = new List<VxInputCheckbox>();

        /// <inheritdoc />
        protected override bool TryParseValueFromString(string value, out T result, out string validationErrorMessage)
            => throw new NotImplementedException($"This component does not parse string inputs. Bind to the '{nameof(CurrentValue)}' property, not '{nameof(CurrentValueAsString)}'.");

        internal void RegisterCheckbox(VxInputCheckbox checkbox)
        {
            Checkboxes.Add(checkbox);


            StateHasChanged();
        }
    }
}
