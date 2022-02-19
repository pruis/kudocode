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
                Context.AddMessage("E3","user not found");
                return;
            }

            var proposedPassword =
                RegisterApplicationUserDtoWorkerHandler.GenerateSaltedHash(Encoding.ASCII.GetBytes(Request.Password));
            if (!proposedPassword.Equals(Entity.Password))
                Context.AddMessage("E3", "Password mismatch");
        }

        protected override void Execute()
        {
            var token = JwtToken(Request.Email);
            _applicationUserContext.Token = Mapper.Map<TokenDto>(token);
            _applicationUserContext.Email = Request.Email;

            var applicationUserDtoResponse = _executionPlan.Execute<GetApplicationUserDto, ApplicationUserDto>(
                new GetApplicationUserDto(Request.Email));

            Mapper.Map(applicationUserDtoResponse.Result, _applicationUserContext);
            Context.Result = _applicationUserContext as ApplicationUserContext;
        }
        private JwtToken JwtToken(string email)
        {
            var token = new JwtTokenBuilder()
                .AddSecurityKey(JwtSecurityKey.Create("fiver-secret-key"))
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