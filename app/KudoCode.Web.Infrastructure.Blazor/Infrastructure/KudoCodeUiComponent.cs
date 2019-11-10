using System;
using System.Threading.Tasks;
using KudoCode.Web.Infrastructure.Blazor.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Components;
using ServiceStack;

namespace KudoCode.Web.Infrastructure.Blazor.Infrastructure
{
    public abstract class KudoCodeUiComponent : KudoCodeComponent, IKudoCodeUiComponent
    {
        [Parameter] public string Id { get; set; } = Guid.NewGuid().ToString();
        [Parameter] public bool ReadOnly { get; set; } = false;
        [Parameter] public virtual int[] ColSize { get; set; } = {3,6};

        public virtual string ColClass(int index)
        {
            if (index < 0)
                return "col";

            var colSize = 0;
            if (ColSize.Length > index)
                colSize = ColSize[index];

            return colSize != 0 ? $"col-{colSize}" : "col";
        }
    };
}