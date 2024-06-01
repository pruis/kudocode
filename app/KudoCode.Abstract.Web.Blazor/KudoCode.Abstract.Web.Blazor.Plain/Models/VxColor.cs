using System.ComponentModel;

namespace KudoCode.Abstract.Web.Blazor
{
    [TypeConverter(typeof(StringToVxColorConverter))]
    public class VxColor
    {

        // will contain standard 32bit sRGB (ARGB)
        //
        public string Value { get; private set; }

        public VxColor(string value)
        {
            this.Value = value;
        }
    }
}
