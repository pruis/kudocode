using System.Collections.Generic;
using KudoCode.Abstract.Web.Blazor;

namespace KudoCode.Abstract.Web.Blazor
{
    public class BootstrapInputCheckbox : VxInputCheckbox
    {
        public BootstrapInputCheckbox()
        {
            ContainerCss = "custom-control custom-checkbox line-height-checkbox";
            AdditionalAttributes = new Dictionary<string, object>() { { "class", "custom-control-input" } };
            LabelCss = "custom-control-label";
        }
    }

}
