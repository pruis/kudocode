﻿using KudoCode.Contracts;
using KudoCode.Contracts.Web;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace KudoCode.Abstract.Web.Blazor
{
    /// <summary>
    /// Helper interface for rendering values in components, needs to be non-generic for the form generator
    /// </summary>
    public interface IRenderChildren
    {

        /// <summary>
        /// Function that will render the children for <see cref="TypeToRender"/>
        /// </summary>
        /// <typeparam name="TElement">The element type of the <see cref="TypeToRender"/></typeparam>
        /// <param name="builder">The builder for rendering a tree</param>
        /// <param name="index">The index of the element</param>
        /// <param name="dataContext">The model for the form</param>
        /// <param name="propInfoValue">The property that is filled by the <see cref="FormElement"/></param>
        public static async Task RenderChildren(IGetLookupResponse GetLookupResponse, ApiPostController apiPostController, TableConfig tableConfig, RenderTreeBuilder builder, int index, object dataContext,
            string fieldIdentifier) => throw new NotImplementedException();

    }
    public interface IRenderChildrenLookup
    {

        /// <summary>
        /// Function that will render the children for <see cref="TypeToRender"/>
        /// </summary>
        /// <typeparam name="TElement">The element type of the <see cref="TypeToRender"/></typeparam>
        /// <param name="builder">The builder for rendering a tree</param>
        /// <param name="index">The index of the element</param>
        /// <param name="dataContext">The model for the form</param>
        /// <param name="propInfoValue">The property that is filled by the <see cref="FormElement"/></param>
        public static async Task RenderChildren(IGetLookupResponse GetLookupResponse, ApiPostController apiPostController, TableConfig tableConfig, RenderTreeBuilder builder, int index, object dataContext,
            string fieldIdentifier) => throw new NotImplementedException();

    }
    public interface IRenderChildrenDbLookup
    {
        public static async Task RenderChildren(IStorage storage, IApplicationUserContext applicationUserContext, RenderTreeBuilder builder, int index, object dataContext,
                    string fieldIdentifier) => throw new NotImplementedException();

    }
    public interface IRenderUpload
    {

        /// <summary>
        /// Function that will render the children for <see cref="TypeToRender"/>
        /// </summary>
        /// <typeparam name="TElement">The element type of the <see cref="TypeToRender"/></typeparam>
        /// <param name="builder">The builder for rendering a tree</param>
        /// <param name="index">The index of the element</param>
        /// <param name="dataContext">The model for the form</param>
        /// <param name="propInfoValue">The property that is filled by the <see cref="FormElement"/></param>
        public static async Task RenderChildren(IToastService toastService, ApiPostController apiPostController, TableConfig tableConfig, RenderTreeBuilder builder, int index, object dataContext,
            string fieldIdentifier) => throw new NotImplementedException();

    }
    /// <summary>
    /// Helper interface for that allows a derived component set the component that needs to render. 
    /// Useful for components that render children and should allow a different styling without changing logic
    /// </summary>
    public interface IRenderChildrenSwapable : IRenderChildren
    {

        /// <summary>
        /// Function that will render the children for <see cref="TypeToRender"/>
        /// </summary>
        /// <typeparam name="TElement">The element type of the <see cref="TypeToRender"/></typeparam>
        /// <param name="builder">The builder for rendering a tree</param>
        /// <param name="index">The index of the element</param>
        /// <param name="dataContext">The model for the form</param>
        /// <param name="propInfoValue">The property that is filled by the <see cref="FormElement"/></param>
        /// <param name="typeOfChildToRender">The type of the child that should be rendered</param>
        public static void RenderChildren(RenderTreeBuilder builder, int index, object dataContext,
            string fieldIdentifier,
            Type typeOfChildToRender) => throw new NotImplementedException();

    }
}