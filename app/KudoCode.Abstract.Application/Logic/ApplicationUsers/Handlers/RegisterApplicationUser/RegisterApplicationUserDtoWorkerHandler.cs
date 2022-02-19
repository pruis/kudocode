using Autofac;
using AutoMapper;
using KudoCode.Contracts.Api;
using KudoCode.Contracts;
using System.Security.Cryptography;
using System.Text;

namespace KudoCode.Abstract.Application
{
	public class
		RegisterApplicationUserDtoWorkerHandler : CommandHandler<RegisterApplicationUserDto, ApplicationUser,
			ApplicationUserContext>
	{
		private EntityOrganization _entityOrganiztion;

		protected override void GetEntity()
		{
			Entity = Mapper.Map<ApplicationUser>(Request);
			_entityOrganiztion = Repository.GetOne<EntityOrganization>(a => a.Id == Request.ActiveEntityOrganizationId);
		}

		protected override void Execute()
		{
			var password = GenerateSaltedHash(Encoding.ASCII.GetBytes(Request.Password));
			Entity.Password = password;
			Entity.ActiveEntityOrganizationId = Request.ActiveEntityOrganizationId;
			Entity.AddEntityOrganization(_entityOrganiztion);

			Repository.Create(Entity);
			Repository.SaveChanges();
			//var token = GetTokenDtoWorkerHandler.JwtToken(Request.Email);
			//Context.Result = Mapper.Map<ApplicationUserContext>(Entity);
			//Context.Result.Token = Mapper.Map<TokenDto>(token);
		}

		protected override void ValidateEntity()
		{
			if (_entityOrganiztion == null)
				Context.AddMessage("E4", "Organiztion not found");

			var exsists = Repository.GetExists<ApplicationUser>(a => a.Email.ToLower().Equals(Request.Email.ToLower()));
			if (exsists)
				Context.AddMessage("E6", "Email already registered");
		}

		public static string GenerateSaltedHash(byte[] plainTextPassword)
		{
			string SaltKey = "3856163601";
			var salt = Encoding.ASCII.GetBytes(SaltKey);

			HashAlgorithm algorithm = new SHA256Managed();

			byte[] plainTextWithSaltBytes =
				new byte[plainTextPassword.Length + salt.Length];

			for (int i = 0; i < plainTextPassword.Length; i++)
			{
				plainTextWithSaltBytes[i] = plainTextPassword[i];
			}

			for (int i = 0; i < salt.Length; i++)
			{
				plainTextWithSaltBytes[plainTextPassword.Length + i] = salt[i];
			}

			var token = Encoding.ASCII.GetString(algorithm.ComputeHash(plainTextWithSaltBytes));
			return token;
		}

		public RegisterApplicationUserDtoWorkerHandler(IMapper mapper, IRepository repository, ILifetimeScope scope,
			IWorkerContext<ApplicationUserContext> context) : base(mapper, repository, scope, context)
		{
		}
	}
}