using Autofac;
using KudoCode.LogicLayer.Infrastructure.Dtos.Tokens;
using KudoCode.Web.Infrastructure.Domain.Execution;

namespace KudoCode.Web.Infrastructure.Domain.HttpConnector.AutofacModule
{
    public class KudoCodeLocalStorageModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<KudoCodeLocalStorage>().As<IStorage>().SingleInstance();
            builder.RegisterType<CsrfLocalTokenCache>().As<ITokenCache>().SingleInstance();
        }
    }
}