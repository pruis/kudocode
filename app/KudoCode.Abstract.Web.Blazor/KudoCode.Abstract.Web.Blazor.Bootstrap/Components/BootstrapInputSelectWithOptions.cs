using System.Collections.Generic;
using KudoCode.Abstract.Web.Blazor;

namespace KudoCode.Abstract.Web.Blazor
{
    public class BootstrapVxRadzenTextArea : VxRadzenTextAreaX
    {
        public BootstrapVxRadzenTextArea()
        {
           // this.Style = "text-align:Left";
        }
    }

    public class BootstrapVxRadzenUpload : VxRadzenUpload
    {
        public BootstrapVxRadzenUpload()
        {
           // this.Style = "text-align:Left";
        }
    }
    public class BootstrapInputSelectDbLookup<TValue> : InputSelectDbLookup<TValue>
    {
        public BootstrapInputSelectDbLookup()
        {
            this.Style = "text-align:Left";
        }
    }

    public class BootstrapInputSelectWithOptions<TValue> : InputSelectWithOptions<TValue>
    {
        public BootstrapInputSelectWithOptions()
        {
        }
    }
    public class RadzenBootstrapInputSelectWithOptions<TValue> : RadzenInputSelectWithOptions<TValue>
    {
        public RadzenBootstrapInputSelectWithOptions()
        {
            this.Style = "text-align:Left";
        }

    }
    public class RadzenDateTime<TValue> : Radzen.Blazor.RadzenDatePicker<TValue>
    {
        public RadzenDateTime()
        {
            InputClass = "RadzenDateTime";
            Style = "text-align:Left";
            HourFormat = "24";
            DateFormat = "yyyy-MM-dd HH:mm:ss";
            ShowTime = true;
            ShowSeconds = false;
            AllowInput = false;
        }
    }
    public class RadzenDate<TValue> : Radzen.Blazor.RadzenDatePicker<TValue>
    {
        public RadzenDate()
        {
            InputClass = "RadzenDateTime";
            Style = "text-align:Left";
            DateFormat = "yyyy-MM-dd";
            ShowTime = false;
            AllowInput = false;
        }
    }
}
