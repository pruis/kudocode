using System;
using System.ComponentModel.DataAnnotations;

namespace KudoCode.Abstract.Web.Blazor
{
    public class VxSelectItem
    {
        public VxSelectItem()
        {

        }
        public VxSelectItem(int key, string value)
        {
            this.Order = 0;
            this.Label = value;
            this.Key = key.ToString();
            this.Description = value;
        }
        public VxSelectItem(DisplayAttribute displayAttribute, Enum value)
        {
            this.Order = displayAttribute.GetOrder() ?? 0;
            this.Label = displayAttribute.GetName();
            this.Key = value.ToString();
            this.Description = displayAttribute.GetDescription();
        }


        public int Order { get; set; }

        public string Label { get; set; }

        public string Key { get; set; }

        public string Description { get; set; }

        public bool Selected { get; set; }

        // This method creates a specific call to the above method, requesting the
        // Description MetaData attribute.
        public static VxSelectItem ToSelectItem(Enum value)
        {
            var foundAttr = value.GetAttribute<DisplayAttribute>();
            if (foundAttr != null)
            {
                return new VxSelectItem(foundAttr, value);
            }
            else
            {
                return new VxSelectItem() { Label = value.ToString() };
            }
        }
        public static VxSelectItem ToSelectItem(int key, string value)
        {
            return new VxSelectItem(key, value);
        }
    }

}
