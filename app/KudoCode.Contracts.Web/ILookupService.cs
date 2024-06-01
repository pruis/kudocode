using System.Reflection;
using System.Threading.Tasks;

namespace KudoCode.Contracts.Web
{
    public interface ILookupService
    {
        Task Fetch(object viewModal);
        Task Fetch(object viewModal, PropertyInfo prop);
    }
}