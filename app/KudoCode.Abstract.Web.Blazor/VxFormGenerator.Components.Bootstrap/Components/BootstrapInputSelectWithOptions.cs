using System.Collections.Generic;
using VxFormGenerator.Form.Components.Plain;

namespace VxFormGenerator.Form.Components.Bootstrap
{
    public class BootstrapInputSelectWithOptions<TValue>: InputSelectWithOptions<TValue>
    {
        public BootstrapInputSelectWithOptions()
        {
            this.Attributes = new Dictionary<string, object>() { { "class", "custom-select" } };
        }

       
    }
    public class RadzenBootstrapInputSelectWithOptions<TValue>: RadzenInputSelectWithOptions<TValue>
    {
        public RadzenBootstrapInputSelectWithOptions()
        {
            this.Attributes = new Dictionary<string, object>() { { "class", "custom-select" } };
        }

       
    }
    public class RadzenDateTime<TValue> : Radzen.Blazor.RadzenDatePicker<TValue>
    {
        public RadzenDateTime()
        {
            this.InputClass = "RadzenDateTime";
        }
    }
}
