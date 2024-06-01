using KudoCode.Contracts;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace KudoCode.Abstract.Web.Blazor
{
    public class VxFormDefinition : Attribute
    {
        public string Name { get; set; }

        public List<Layout.VxFormGroup> Groups { get; protected set; } = new List<Layout.VxFormGroup>();

        public static VxFormDefinition CreateFromModel(object model, VxFormLayoutOptions options, TableConfig tableConfig)
        {
            // TODO: EXPANDO SWITCH
            var allProperties = VxHelpers.GetModelProperties(model.GetType());

            var rootFormDefinition = model.GetType().GetCustomAttribute<VxFormDefinition>();

            if (rootFormDefinition == null)
                rootFormDefinition = VxFormDefinition.Create();

            var defaultGroup = Layout.VxFormGroup.Create();


            foreach (var prop in allProperties)
            {
                if (Layout.VxFormGroup.IsFormGroup(prop))
                {
                    var nestedModel = prop.GetValue(model);
                    var formGroup = Layout.VxFormGroup.CreateFromModel(nestedModel, options, tableConfig);
                    formGroup.Label = Layout.VxFormGroup.GetFormGroup(prop).Label;

                    rootFormDefinition.Groups.Add(formGroup);
                }
                else
                {
                    Layout.VxFormGroup.Add(prop.Name, defaultGroup, model, options, tableConfig);
                }

            }
            rootFormDefinition.Groups.Add(defaultGroup);

            return rootFormDefinition;
        }

        private static VxFormDefinition Create()
        {
            return new VxFormDefinition();
        }
    }
}
