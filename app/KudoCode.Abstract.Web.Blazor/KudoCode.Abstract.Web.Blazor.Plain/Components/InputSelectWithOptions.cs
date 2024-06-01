using KudoCode.Contracts;
using KudoCode.Contracts.Web;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;
using Newtonsoft.Json;
using Radzen;
using Radzen.Blazor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace KudoCode.Abstract.Web.Blazor
{

    public class StringConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is VxTextArea input)
            {
                return input.Value;
            }
            return base.ConvertFrom(context, culture, value);
        }
    }

    public class VxRadzenTextAreaX : InputBase<VxTextArea?>
    {
        [DisallowNull] public ElementReference? Element { get; protected set; }




        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "textarea");
            builder.AddMultipleAttributes(1, AdditionalAttributes);
            builder.AddAttribute(2, "class", CssClass);
            builder.AddAttribute(3, "value", BindConverter.FormatValue(CurrentValue?.Value));
            builder.AddAttribute(4, "onchange", EventCallback.Factory.CreateBinder<string?>(this, __value => CurrentValueAsString = __value, new VxTextArea() { Value = CurrentValueAsString }));
            //builder.AddAttribute(5, "rows", 4);
            //builder.AddAttribute(6, "cols", 20);

            builder.AddElementReferenceCapture(5, __inputReference => Element = __inputReference);
            builder.CloseElement();
        }

        protected override bool TryParseValueFromString(string? value, out VxTextArea? result, [NotNullWhen(false)] out string? validationErrorMessage)
        {
            result = new VxTextArea();
            result.Value = value;
            validationErrorMessage = null;
            return true;
        }

    }



    public class VxRadzenUpload : RadzenUpload, IRenderChildren, IRenderUpload
    {
        public static async Task RenderChildren(IToastService toastService, RenderTreeBuilder builder, int index, object dataContext,
            string fieldIdentifier)
        {
            var prop = dataContext.GetType().GetProperty(fieldIdentifier);
            var value = (VxUpload)dataContext.GetType().GetProperty(fieldIdentifier).GetValue(dataContext);

            if (value == null)
            {
                value = (VxUpload)Activator.CreateInstance(typeof(VxUpload));
                dataContext.GetType().GetProperty(fieldIdentifier).SetValue(value, dataContext);
            }

            var callback = EventCallback.Factory.Create<UploadCompleteEventArgs>(dataContext, arg =>
            {
                value.Url = JsonConvert.DeserializeObject<List<FileUploadResult>>(arg.RawResponse);
                foreach (var item in value.Url)
                    toastService.ToastMessage(new MessageDto("S1", $"File uploaded {item.OriginalName}", MessageDtoType.Success));
            });

            builder.AddAttribute(index + 2, "Multiple", true);
            builder.AddAttribute(index + 3, "Url", "/api/Media/Upload");
            builder.AddAttribute(index + 4, "Class", "w-100");
            builder.AddAttribute(index + 4, "Complete", callback);
        }
    }

    public class InputSelectDbLookup<TValue> : RadzenDropDown<TValue>, IRenderChildrenDbLookup
    {
        public static async Task RenderChildren(IStorage storage, IApplicationUserContext applicationUserContext, RenderTreeBuilder builder, int index, object dataContext, string fieldIdentifier)
        {
            var prop = dataContext.GetType().GetProperty(fieldIdentifier);
            var layoutAttr = prop.GetCustomAttribute<VxFormDbLookupAttribute>();
            var list = new List<VxDbLookup>();
            var items = new List<LookupResponse>();

            var UserPropLookups = storage
                .GetOrCreate<GetLookupResponse>($"{applicationUserContext.Email}_IGetLookupResponse_{prop.Name}");

            if (UserPropLookups.Lookups.Any(a => a.Type == layoutAttr.Type))
                items = UserPropLookups.Lookups.Where(a => a.Type == layoutAttr.Type && (a.OranizationId == 0 || a.OranizationId == applicationUserContext.ActiveEntityOrganizationId)).ToList();

            foreach (var item in items)
                list.Add(new VxDbLookup(item.Id, item.Description));

            var selectedValue = dataContext.GetType().GetProperty(fieldIdentifier).GetValue(dataContext);

            builder.AddAttribute(index + 2, "TextProperty", "Value");
            builder.AddAttribute(index + 3, "bind-Value", selectedValue);
            builder.AddAttribute(index + 4, "TValue", "string");
            builder.AddAttribute(index + 5, "Data", list);
        }
    }

    public class InputSelectWithOptions<TValue> : InputSelect<TValue>, IRenderChildren
    {
        public static Type TypeOfChildToRender => typeof(InputSelectOption<string>);

        public static void RenderChildren(RenderTreeBuilder builder, int index, object dataContext,
            string fieldIdentifier)
        {
            //var prop = dataContext.GetType().GetProperty(fieldIdentifier);
            //var layoutAttr = prop.GetCustomAttribute<VxFormElementLayoutAttribute>();
            //var allRowLayoutAttributes = VxHelpers.GetAllAttributes<VxFormRowLayoutAttribute>(prop.DeclaringType);
            // the builder position is between the builder.OpenComponent() and builder.CloseComponent()
            // This means that the component of InputSelect is added en stil open for changes.
            // We can create a new RenderFragment and set the ChildContent attribute of the InputSelect component
            builder.AddAttribute(index + 1, nameof(ChildContent),
                new RenderFragment(_builder =>
                {
                    // check if the type of the propery is an Enum
                    if (typeof(TValue).IsEnum)
                    {
                        // when type is a enum present them as an <option> element 
                        // by leveraging the component InputSelectOption
                        var values = typeof(TValue).GetEnumValues();


                        foreach (var val in values)
                        {
                            var value = VxSelectItem.ToSelectItem(val as Enum);

                            //  Open the InputSelectOption component
                            _builder.OpenComponent(0, TypeOfChildToRender);

                            // Set the value of the enum as a value and key parameter
                            _builder.AddAttribute(1, nameof(InputSelectOption<string>.Value), value.Label);
                            _builder.AddAttribute(2, nameof(InputSelectOption<string>.Key), value.Key);

                            // Close the component
                            _builder.CloseComponent();
                        }
                    }


                }));
        }
    }
}

