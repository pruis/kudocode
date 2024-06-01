using KudoCode.Contracts;
using KudoCode.Contracts.Web;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;
using Radzen.Blazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KudoCode.Abstract.Web.Blazor;
using KudoCode.Abstract.Web.Blazor;

namespace KudoCode.Abstract.Web.Blazor
{
    public class RadzenInputSelectWithOptions<TValue> : RadzenDropDown<TValue>, IRenderChildren, IRenderChildrenLookup
    {
        private bool isLoaded = false;
        public static Type TypeOfChildToRender => typeof(InputSelectOption<string>);
        public RadzenInputSelectWithOptions()
        {

        }
        public static async Task RenderChildren(IGetLookupResponse getLookupResponse, ApiPostController apiPostController, TableConfig tableConfig, RenderTreeBuilder builder, int index, object dataContext,
            string fieldIdentifier)
        {
            var list = new List<VxLookup>();

            if (tableConfig != null)
            {
                var items = new List<LookupResponse>();
                var propConfig = tableConfig.Properties.Single(a => a.Name == fieldIdentifier);

                if (!getLookupResponse.Lookups.Any(a => a.Type == propConfig.Source) || propConfig.CacheOnFirstLoad == false)
                {
                    var result = await apiPostController.Create<GetLookupRequest, GetLookupResponse>().Post(
                                        new GetLookupRequest(new[] { new LookupRequest() { Type = propConfig.Source } }));

                    if (result?.Result?.Lookups != null)
                    {
                        items.AddRange(result?.Result?.Lookups);

                        if (propConfig.CacheOnFirstLoad)
                            foreach (var item in result.Result.Lookups)
                                getLookupResponse.Lookups.Add(item);
                    }
                }
                else
                {
                    items = getLookupResponse.Lookups.Where(a => a.Type == propConfig.Source).ToList();
                }

                foreach (var item in items)
                    list.Add(new VxLookup(item.Id, item.Description));
            }
            var selectedValue = dataContext.GetType().GetProperty(fieldIdentifier).GetValue(dataContext);

            builder.AddAttribute(index + 2, "TextProperty", "Value");
            builder.AddAttribute(index + 3, "bind-Value", selectedValue);
            builder.AddAttribute(index + 4, "TValue", "string");
            builder.AddAttribute(index + 5, "Data", list);
        }

    }
}

