using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KudoCode.Abstract.Web.Blazor;

namespace KudoCode.Abstract.Web.Blazor
{
    public class VxFormRowBase: OwningComponentBase
    {
        [Parameter] public VxFormRowLayout FormRowDefinition { get; set; }
        
    }
}

