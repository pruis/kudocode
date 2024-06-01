using KudoCode.Contracts;
using System;
using KudoCode.Abstract.Web.Blazor;

namespace KudoCode.LogicLayer.Dtos.Comanys.Outbound
{
    public class GetAddressResponse
    {
        public GetAddressResponse()
        {
            UpLoad = new VxUpload();
        }
        //var callback = EventCallback.Factory.Create<UploadCompleteEventArgs>(this, arg =>
        //{
        //    // do something
        //});


        public string Address { get; set; }
        public DateTime Date { get; set; }
        //[VxUploadCallBack(Callback = EventCallback.Factory.Create<UploadCompleteEventArgs>(new object(), arg =>
        //{
        //    // do something
        //}))]
        public VxUpload UpLoad { get; set; }
    }

    public class GetCompanyResponse
    {
        public GetCompanyResponse()
        {
            GetAddressResponse = new GetAddressResponse();
        }
        private VxDbLookup dbLookup;

        [VxIgnore]
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        [VxFormGroup(Label = "test")]
        public GetAddressResponse GetAddressResponse { get; set; }
        //public VxUpload UpLoad { get; set; }
        [VxFormElementLayout()]
        public cc ddd { get; set; }

        [VxFormDbLookup(Type = "Occupation", CacheOnFirstLoad = false)]
        public VxDbLookup DbLookup { get => dbLookup; set { dbLookup = value; } }

        //public VxLookupList Leads { get; set; } = new VxLookupList() ;

        public VxTextArea MyProperty { get; set; } = new VxTextArea() { Value = "test this"};

        public DateTimeOffset DateTime { get; set; }

    }

    public enum cc
    { test, testtt, testee, eee }
}
