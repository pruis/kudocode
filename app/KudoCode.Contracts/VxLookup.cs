using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace KudoCode.Contracts
{
    public class MessageProxyCollection : MessageCollection, IMessageCollection
    {
        public IReadOnlyCollection<MessageDto> Messages => base.Messages;
    }

    public class FileUploadResult
    {
        public int Id { get; set; }
        public string OriginalName { get; set; }
        public string CloudName { get; set; }
        public string Url { get; set; }
    }

    public class MessageCollection
    {
        public IReadOnlyCollection<MessageDto> Messages => new List<MessageDto>()
        {
            new MessageDto("E1", "{0}", MessageDtoType.Error),
            new MessageDto("E2", "Internal Error please contact support with the following reference. {0}"
                , MessageDtoType.Error),
            new MessageDto("E3", "Authorization Failed {0}", MessageDtoType.Error),
            new MessageDto("W3", "Authorization token not provided", MessageDtoType.Warning),
            new MessageDto("E4","Not found: {0}",MessageDtoType.Error),
            new MessageDto("E5","THIS IS NOT USED {0}",MessageDtoType.Error),
            new MessageDto("E6","Input validation: {0}",MessageDtoType.Error),
            new MessageDto("W6","Input validation: {0}",MessageDtoType.Warning),
        };
    }

    public interface IVxLookup
    {
        int Id { get; set; }
        string Value { get; set; }

    }

    //[TypeConverter(typeof(StringConverter))]
    public class VxTextArea

    {
        public VxTextArea()
        {
        }
        public string Value { get; set; }
        public static implicit operator string(VxTextArea d) => d.Value;
        public override string ToString() => $"{Value}";
    }

    public class VxUpload
    {
        public VxUpload()
        {
            Url = new List<FileUploadResult>();
        }
        public List<FileUploadResult> Url { get; set; }
    }
    public class VxDbLookup : IVxLookup
    {
        public VxDbLookup(int id, string value)
        {
            this.Value = value;
            this.Id = id;
        }
        public VxDbLookup()
        {
        }
        public int Id { get; set; }
        public string Value { get; set; }

        public override string ToString()
        {
            return Value;
        }
    }


    public class VxLookup : IVxLookup
    {
        public VxLookup(int id, string value)
        {
            this.Value = value;
            this.Id = id;
        }
        public VxLookup()
        {
        }
        public int Id { get; set; }
        public string Value { get; set; }

        public override string ToString()
        {
            return Value;
        }
    }

    public class VxLookupList
    {
        public List<VxLookup> List { get; set; }
        public VxLookupList()
        {
            List = new List<VxLookup>();
        }
    }

    public delegate void ViewModelHasChanged(string prop);

    public interface IViewModelHasChanged
    {
        event ViewModelHasChanged ViewModelHasChanged;
    }
}
