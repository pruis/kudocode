using KudoCode.Contracts.Web;

namespace KudoCode.Web.Blazor.Application.ViewModels
{
    public class DashboardViewModel
    {
        public string Password { get; set; }
        public string Email { get; set; }
        public GetListPortfolioViewModel PortfoliosViewModel { get; set; }
    }
}