using Autofac;
using AutoMapper;
using KudoCode.Contracts.Api;
using KudoCode.Contracts;
using Microsoft.Extensions.Configuration;
using System.Text;

namespace KudoCode.Abstract.Application
{
    public class GetTokenDtoWorkerHandler : QueryHandler<GetTokenRequest, ApplicationUser, ApplicationUserContext>
    {
        private IApplicationUserContext _applicationUserContext;
        private readonly ISecondaryExecutionPipeline _executionPlan;
        private readonly IConfiguration _configuration;

        public GetTokenDtoWorkerHandler(IMapper mapper,
            IReadOnlyRepository repository,
            IApplicationUserContext applicationUserContext,
            IComponentContext scope,
            ISecondaryExecutionPipeline executionPlan,
            IConfiguration configuration,
            IWorkerContext<ApplicationUserContext> context) : base(mapper, repository, scope, context)
        {
            _applicationUserContext = applicationUserContext;
            _executionPlan = executionPlan;
            _configuration = configuration;
        }


        protected override void GetEntity()
        {
            Entity = Repository.GetOne<ApplicationUser>(a => a.Email.ToLower().Equals(Request.Email.ToLower()));
        }

        protected override void ValidateEntity()
        {
            if (Entity == null)
            {
                Context.AddMessage("E3", "Invalid login");
                return;
            }
            var secret = "3856163601" + Entity.Secret;
            if (Entity.Secret == "3856163601")
                secret = Entity.Secret;

            var proposedPassword =
                SaveApplicationUserWorkerHandler.GenerateSaltedHash(Encoding.ASCII.GetBytes(Request.Password), secret);
            if (!proposedPassword.Equals(Entity.Password))
                Context.AddMessage("E3", "Invalid login");
        }

        protected override void Execute()
        {
            var token = JwtToken(Request.Email);
            _applicationUserContext.Token = Mapper.Map<TokenDto>(token);
            _applicationUserContext.Email = Request.Email;

            var applicationUserDtoResponse = _executionPlan.Execute<GetApplicationUserRequest, GetApplicationUserResponse>(
                new GetApplicationUserRequest() { Email = Request.Email });

            Mapper.Map(applicationUserDtoResponse.Result, _applicationUserContext);
            Context.Result = _applicationUserContext as ApplicationUserContext;
        }
        private JwtToken JwtToken(string email)
        {
            var token = new JwtTokenBuilder()
                .AddSecurityKey(JwtSecurityKey.Create("fiver-secret-key3856163601-longer-key"))
                .AddSubject(email)
                .AddIssuer("Fiver.Security.Bearer")
                .AddAudience("Fiver.Security.Bearer")
                .AddClaim("Values", "Create,Read,Update,Delete")
                .AddExpiry(int.Parse(_configuration["TokenExpireMin"]))
                .Build();
            return token;
        }
    }
}