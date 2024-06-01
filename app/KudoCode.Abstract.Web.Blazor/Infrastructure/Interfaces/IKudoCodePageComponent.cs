using KudoCode.Contracts.Web;

namespace KudoCode.Abstract.Web.Blazor
{
    public interface IKudoCodePageComponent
    {
        IKudoCodeNavigation Navigation { get; set; }
    }
}