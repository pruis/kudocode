using Microsoft.AspNetCore.Components;
using Radzen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KudoCode.Abstract.Web.Blazor
{

    public class VxFormDbLookupAttribute : Attribute
    {
        public VxFormDbLookupAttribute()
        {
            Type = "";
            Key = "Id";
            Value = "Description";
            Filter = "";
            Service = "";
        }

        public bool CacheOnFirstLoad { get; set; }
        public string Type { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public string Filter { get; set; }
        public string Service { get; set; }
    }
    public class VxFormElementLayoutAttribute : Attribute
    {

        public int ColSpan { get; set; }

        public int RowId { get; set; }

        public string Label { get; set; }

        public string Placeholder { get; set; }

        public string Description { get; set; }

        public int Order { get; set; }
        public string FieldIdentifier { get; }
        public bool ShowLabel { get; internal set; } = true;
    }

    public class VxFormGroupAttribute : Attribute
    {
        public string Label { get; set; }
        public int Order { get; set; }
    }

    public class VxFormRowLayoutAttribute : Attribute
    {
        public string Label { get; set; }
        public int Order { get; set; }
        public int Id { get; set; }
    }
   }
