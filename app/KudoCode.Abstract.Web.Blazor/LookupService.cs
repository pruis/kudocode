using KudoCode.Contracts;
using KudoCode.Contracts.Web;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using KudoCode.Abstract.Web.Blazor;

namespace KudoCode.Abstract.Web.Blazor
{

    public class LookupService : ILookupService
    {
        private IStorage _storage;
        private ApiPostController _apiPostController;
        private IApplicationUserContext _applicationUserContext;

        public LookupService(IStorage storage, ApiPostController apiPostController, IApplicationUserContext applicationUserContext)
        {
            _storage = storage;
            _apiPostController = apiPostController;
            _applicationUserContext = applicationUserContext;
        }

        public async Task Fetch(object viewModal)
        {
            var properties = viewModal.GetType().GetProperties();

            foreach (var prop in properties)
            {
                await Fetch(viewModal, prop);
            }
        }

        public async Task Fetch(object viewModal, PropertyInfo prop)
        {
            var layoutAttr = prop.GetCustomAttribute<VxFormDbLookupAttribute>();
            var list = new List<VxDbLookup>();
            //var items = new List<LookupResponse>();

            if (layoutAttr == null)
                return;


            var UserPropLookups = _storage
                .GetOrCreate<GetLookupResponse>($"{_applicationUserContext.Email}_IGetLookupResponse_{prop.Name}");

            var selectedLookups = UserPropLookups
                .Lookups
                .Where(a => a.Type == layoutAttr.Type && (a.OranizationId == 0 || a.OranizationId == _applicationUserContext.ActiveEntityOrganizationId))
                .ToList();

            // clear if already loaded and not set as cached
            if (selectedLookups.Any() && layoutAttr.CacheOnFirstLoad == false)
            {
                var range = selectedLookups;
                foreach (var item in range)
                    UserPropLookups.Lookups.Remove(item);
            }

            // load if not set as cached
            if (layoutAttr.CacheOnFirstLoad == false)
            {
                var filter = layoutAttr.Filter;

                var filterItems = layoutAttr.Filter.Split('<');
                foreach (var filterItem in filterItems)
                {
                    if (!filterItem.Contains(">"))
                        continue;
                    var propName = filterItem.Split('>')[0];
                    var propValue = viewModal.GetType().GetProperty(propName).GetValue(viewModal).ToString();
                    filter = filter.Replace($"<{propName}>", propValue);
                }

                var result = await _apiPostController.Create<GetLookupRequest, GetLookupResponse>()
                    .Post(new GetLookupRequest(new[] {
                        new LookupRequest() { Type = layoutAttr.Type, Filter = filter, Key = layoutAttr.Key, Value = layoutAttr.Value } }), layoutAttr.Service);

                if (result?.Result?.Lookups != null)
                {
                    foreach (var item in result.Result.Lookups)
                        UserPropLookups.Lookups.Add(item);

                    _storage.Remove($"{_applicationUserContext.Email}_IGetLookupResponse_{prop.Name}");
                    _storage.Set($"{_applicationUserContext.Email}_IGetLookupResponse_{prop.Name}", UserPropLookups);
                }
            }
        }
    }
}
