using Autofac;
using AutoMapper;
using KudoCode.Contracts.Api;
using KudoCode.Contracts;
using System.Security.Cryptography;
using System.Text;
using KudoCode.Helpers;
using System;

namespace KudoCode.Abstract.Application
{
    public class SaveApplicationUserWorkerHandler : CommandHandler<SaveApplicationUserRequest, ApplicationUser,
            SaveApplicationUserResponse>
    {
        public SaveApplicationUserWorkerHandler(IMapper mapper, IRepository repository, ILifetimeScope scope,
            IWorkerContext<SaveApplicationUserResponse> context) : base(mapper, repository, scope, context)
        {
        }

        private EntityOrganization _entityOrganiztion;

        protected override void GetEntity()
        {
            Entity = Request.Id > 0
                ? Repository.GetOne<ApplicationUser>(a => a.Id == Request.Id)
                : new ApplicationUser();

            _entityOrganiztion = Repository.GetOne<EntityOrganization>(a => a.Id == Request.ActiveEntityOrganizationId);
        }

        protected override void ValidateEntity()
        {
            if (_entityOrganiztion == null)
                Context.AddMessage("E4", "Organiztion not found");

            if (Request.Id == 0 || (Request.Id != Entity.Id))
            {
                var exsists = Repository.GetExists<ApplicationUser>(a => a.Email.ToLower().Equals(Request.Email.ToLower()));
                if (exsists)
                    Context.AddMessage("E6", "Email already registered");
            }

        }
        protected override void Execute()
        {
            Context.Result = new SaveApplicationUserResponse();

            if ((!string.IsNullOrWhiteSpace(Request.Password) || !string.IsNullOrWhiteSpace(Request.Repassword) && (Request.Repassword.Equals(Request.Password))))
            {
                Entity.Secret = CryptoService.GetRandomAlphanumericString(new Random().Next(10, 20));
                Entity.Password = GenerateSaltedHash(Encoding.ASCII.GetBytes(Request.Password), "3856163601" + Entity.Secret);
            }

            Entity.AddEntityOrganization(_entityOrganiztion);

            Mapper.Map(Request, Entity);
            Repository.Save(Entity).SaveChanges();
            Context.Result.Id = Entity.Id;
        }
        public static string GenerateSaltedHash(byte[] plainTextPassword, string saltKey)
        {
            var salt = Encoding.ASCII.GetBytes(saltKey);

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

    }
}