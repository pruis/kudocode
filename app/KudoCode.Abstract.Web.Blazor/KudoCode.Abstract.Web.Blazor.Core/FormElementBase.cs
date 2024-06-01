﻿using KudoCode.Abstract.Web.Blazor;
using KudoCode.Contracts;
using KudoCode.Contracts.Web;
using KudoCode.Helpers;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using KudoCode.Abstract.Web.Blazor;
using KudoCode.Abstract.Web.Blazor.Repository;

namespace KudoCode.Abstract.Web.Blazor
{
    public class FormElementBase<TFormElement> : OwningComponentBase
    {

        [Inject]
        protected IFormGeneratorComponentsRepository Repo { get; set; }
        [Inject]
        protected IConvertToObjectDictionary _typeDict { get; set; }
        [Inject]
        public ApiPostController apiPostController { get; set; }
        [Inject]
        public IToastService ToastService { get; set; }
        [Inject]
        public IStorage storage { get; set; }
        [Inject]
        public IApplicationUserContext applicationUserContext { get; set; }
        /// <summary>
        /// Bindable property to set the class
        /// </summary>
        public string CssClass { get => string.Join(" ", CssClasses?.ToArray()); }
        /// <summary>
        /// Setter for the classes of the form container
        /// </summary>
        [Parameter] public List<string> CssClasses { get; set; }

        /// <summary>
        /// Will set the 'class' of the all the controls. Useful when a framework needs to implement a class for all form elements
        /// </summary>
        [Parameter] public List<string> DefaultFieldClasses { get; set; }
        /// <summary>
        /// The identifier for the <see cref="FormElement"/>"/> used by the label element
        /// </summary>
        [Parameter] public string Id { get; set; }
        /// <summary>
        /// Updates the property with the new value
        /// </summary>
        [Parameter] public EventCallback<TFormElement> ValueChanged { get; set; }
        /// <summary>
        /// Get the property that is bound
        /// </summary>
        [Parameter] public Expression<Func<TFormElement>> ValueExpression { get; set; }
        /// <summary>
        /// The current Value of the <see cref="FormElementBase{TFormElement}"/>
        /// </summary>
        [Parameter] public TFormElement Value { get; set; }
        [Parameter] public VxFormElementDefinition FormColumnDefinition { get; set; }

        /// <summary>
        /// Get the <see cref="EditForm.EditContext"/> instance. This instance will be used to fill out the values inputted by the user
        /// </summary>
        [CascadingParameter] EditContext CascadedEditContext { get; set; }

        [CascadingParameter] public VxFormLayoutOptions FormLayoutOptions { get; set; }

        protected override void OnInitialized()
        {

        }

        /// <summary>
        /// A method that renders the form control based on the <see cref="FormElement.FieldIdentifier"/>
        /// </summary>
        /// <param name="propInfoValue"></param>
        /// <returns></returns>
        public RenderFragment CreateComponent() => builder =>
        {
            // Get the mapped control based on the property type
            Type componentType;
            if (FormColumnDefinition.TableConfig != null)
            {
                var propConfig = FormColumnDefinition.TableConfig.Properties.FirstOrDefault(a => a.Name.Equals(FormColumnDefinition.Name));
                componentType = Repo.GetComponent(_typeDict.GetType(propConfig.Type));
            }
            else
            {
                componentType = Repo.GetComponent(typeof(TFormElement));
            }

            // TODO: add the dynamic version for getting a component

            if (componentType == null)
                return;
            //  throw new Exception($"No component found for: {propInfoValue.PropertyType.ToString()}");

            // Set the found component
            var elementType = componentType;

            // When the elementType that is rendered is a generic Set the propertyType as the generic type
            if (elementType.IsGenericTypeDefinition)
            {
                Type[] typeArgs = { typeof(TFormElement) };
                elementType = elementType.MakeGenericType(typeArgs);
            }

            /*   // Activate the the Type so that the methods can be called
               var instance = Activator.CreateInstance(elementType);*/
            this.CreateFormComponent(this, FormColumnDefinition.TableConfig, FormColumnDefinition.Model, FormColumnDefinition.Name, builder, elementType);
        };

        /// <summary>
        /// Creates the component that is rendered in the form
        /// </summary>
        /// <typeparam name="T">The type of the property</typeparam>
        /// <typeparam name="TElement">The type of the form element, should be based on <see cref="InputBase{TValue}"/>, like a <see cref="InputText"/></typeparam>
        /// <param name="target">This <see cref="FormElement"/> </param>
        /// <param name="dataContext">The Model instance</param>
        /// <param name="propInfoValue">The property that is being rendered</param>
        /// <param name="builder">The render tree of this element</param>
        /// <param name="instance">THe control instance</param>
        public void CreateFormComponent(object target, TableConfig tableConfig,
            object dataContext,
            string fieldIdentifier, RenderTreeBuilder builder, Type elementType)
        {
            var treeIndex = 0;
            var x = builder.ToDictionary();
            // Create the component based on the mapped Element Type
            builder.OpenComponent(treeIndex, elementType);

            // Bind the value of the input base the the propery of the model instance
            builder.AddAttribute(treeIndex++, nameof(InputBase<TFormElement>.Value), Value);

            // Create the handler for ValueChanged. This wil update the model instance with the input
            builder.AddAttribute(treeIndex++, nameof(InputBase<TFormElement>.ValueChanged), ValueChanged);

            builder.AddAttribute(treeIndex++, nameof(InputBase<TFormElement>.ValueExpression), ValueExpression);

            if (FormColumnDefinition.RenderOptions.Placeholder != null)
                builder.AddAttribute(treeIndex++, "placeholder", FormColumnDefinition.RenderOptions.Placeholder);

            // Set the class for the the formelement.
            builder.AddAttribute(treeIndex++, "class", GetDefaultFieldClasses(Activator.CreateInstance(elementType) as InputBase<TFormElement>));

            CheckForInterfaceActions(this, tableConfig, FormColumnDefinition.Model, fieldIdentifier, builder, treeIndex++, elementType);

            builder.CloseComponent();

        }

        private void CheckForInterfaceActions(object target, TableConfig tableConfig,
            object dataContext,
            string fieldIdentifier, RenderTreeBuilder builder, int indexBuilder, Type elementType)
        {
            // Check if the component has the IRenderChildren and renderen them in the form control
            if (VxHelpers.TypeImplementsInterface(elementType, typeof(IRenderChildrenLookup)))
            {
                var method = elementType.GetMethod(nameof(IRenderChildren.RenderChildren), BindingFlags.Public | BindingFlags.FlattenHierarchy | BindingFlags.Static);
                method.Invoke(null, new object[] { storage, apiPostController, tableConfig, builder, indexBuilder, dataContext, fieldIdentifier });
            }
            else if (VxHelpers.TypeImplementsInterface(elementType, typeof(IRenderChildrenDbLookup)))
            {
                var method = elementType.GetMethod(nameof(IRenderChildrenDbLookup.RenderChildren), BindingFlags.Public | BindingFlags.FlattenHierarchy | BindingFlags.Static);
                method.Invoke(null, new object[] { storage, applicationUserContext, builder, indexBuilder, dataContext, fieldIdentifier });
            }
            else if (VxHelpers.TypeImplementsInterface(elementType, typeof(IRenderUpload)))
            {
                var method = elementType.GetMethod(nameof(IRenderChildren.RenderChildren), BindingFlags.Public | BindingFlags.FlattenHierarchy | BindingFlags.Static);
                method.Invoke(null, new object[] { ToastService, builder, indexBuilder, dataContext, fieldIdentifier });
            }
            else if (VxHelpers.TypeImplementsInterface(elementType, typeof(IRenderChildren)))
            {
                var method = elementType.GetMethod(nameof(IRenderChildren.RenderChildren), BindingFlags.Public | BindingFlags.FlattenHierarchy | BindingFlags.Static);
                method.Invoke(null, new object[] { builder, indexBuilder, dataContext, fieldIdentifier });
            }

        }

        /// <summary>
        /// Merges the default control classes with the <see cref="InputBase{TValue}.AdditionalAttributes"/> 'class' key
        /// </summary>
        /// <typeparam name="T">The property type of the formelement</typeparam>
        /// <param name="instance">The instance of the component representing the form control</param>
        /// <returns></returns>
        private string GetDefaultFieldClasses<T>(InputBase<T> instance)
        {
            var output = DefaultFieldClasses == null ? "" : string.Join(" ", DefaultFieldClasses);

            if (instance == null)
                return output;

            var AdditionalAttributes = instance.AdditionalAttributes;

            if (AdditionalAttributes != null &&
                  AdditionalAttributes.TryGetValue("class", out var @class) &&
                  !string.IsNullOrEmpty(Convert.ToString(@class)))
            {
                return $"{@class} {output}";
            }

            return output;
        }



    }
}