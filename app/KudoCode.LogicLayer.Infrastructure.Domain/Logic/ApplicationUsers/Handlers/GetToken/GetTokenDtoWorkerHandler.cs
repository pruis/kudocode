using System.Text;
using Autofac;
using AutoMapper;
using KudoCode.LogicLayer.Infrastructure.Domain.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Domain.Logic.ApplicationUsers.Entities;
using KudoCode.LogicLayer.Infrastructure.Domain.Logic.ApplicationUsers.Handlers.RegisterApplicationUser;
using KudoCode.LogicLayer.Infrastructure.Dtos;
using KudoCode.LogicLayer.Infrastructure.Dtos.ApplicationUsers;
using KudoCode.LogicLayer.Infrastructure.Dtos.ApplicationUsers.Interface;
using KudoCode.LogicLayer.Infrastructure.Dtos.Tokens;
using KudoCode.LogicLayer.Infrastructure.Execution.Context.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Execution.Interfaces;
using KudoCode.LogicLayer.Infrastructure.Handlers;
using KudoCode.LogicLayer.Infrastructure.Token;
using Microsoft.Extensions.Configuration;

namespace KudoCode.LogicLayer.Infrastructure.Domain.Logic.ApplicationUsers.Handlers.GetToken
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
                Context.AddMessage("E3");
                return;
            }

            var proposedPassword =
                RegisterApplicationUserDtoWorkerHandler.GenerateSaltedHash(Encoding.ASCII.GetBytes(Request.Password));
            if (!proposedPassword.Equals(Entity.Password))
                Context.AddMessage("E3");
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