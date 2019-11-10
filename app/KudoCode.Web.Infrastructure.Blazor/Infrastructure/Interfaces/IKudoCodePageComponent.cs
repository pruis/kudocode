using KudoCode.Web.Infrastructure.Domain;

namespace KudoCode.Web.Infrastructure.Blazor.Infrastructure.Interfaces
{
    public interface IKudoCodePageComponent
    {
        IKudoCodeNavigation Navigation { get; set; }
    }
}