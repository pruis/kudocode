using KudoCode.LogicLayer.Domain.Logic.Leads.Entities;
using KudoCode.LogicLayer.Domain.Logic.Lookups.Entities;
using KudoCode.LogicLayer.Domain.Logic.PortfolioTransactionsTypes.Entities;
using KudoCode.Contracts.Api;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
//using Microsoft.EntityFrameworkCore.Relational;

//https://dev.mysql.com/doc/connector-net/en/connector-net-entityframework60.html
//https://dev.mysql.com/doc/connector-net/en/connector-net-entityframework-core.html
//		//CREATE TABLE `__EFMigrationsHistory` ( `MigrationId` nvarchar(150) NOT NULL, `ProductVersion` nvarchar(32) NOT NULL, PRIMARY KEY (`MigrationId`) );

namespace KudoCode.LogicLayer.Domain.Repository
{

    public class DataContext : DbContext, IDataContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var scanforEntity = typeof(IEntity);
            var scanforMapEntity = typeof(IMapEntity);
            var scanforLookup = typeof(ILookup);
            var types = AppDomain.CurrentDomain.GetAssemblies().ToList()
                .Where(a=>a.FullName.Contains("Domain") || a.FullName.Contains("Application"))
                .SelectMany(a => a.GetTypes())
                .Where(t => scanforEntity.IsAssignableFrom(t) || scanforLookup.IsAssignableFrom(t) ||
                            scanforMapEntity.IsAssignableFrom(t));
            foreach (var type in types)
            {
                if (modelBuilder.Model.FindEntityType(type) != null)
                    continue;
                if (type.IsAbstract)
                    continue;

                modelBuilder.Model.AddEntityType(type);
            }


            //ONE TO ONE RELATIONSHIP
            modelBuilder.Entity<Lead>()
                .HasOne(a => a.LeadPersonalInformation).WithOne(b => b.Lead)
                .HasForeignKey<LeadPersonalInformation>(e => e.LeadId);

            modelBuilder.Entity<LeadPersonalInformation>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<LeadPersonalInformation>(entity => { entity.HasIndex(e => e.Email).IsUnique(); });

            modelBuilder.Entity<AuthorizationRole>().Property(t => t.Id).ValueGeneratedNever();
            modelBuilder.Entity<AuthorizationGroup>().Property(t => t.Id).ValueGeneratedNever();
            modelBuilder.Entity<Gender>().Property(t => t.Id).ValueGeneratedNever();
            modelBuilder.Entity<Gender>().Property(t => t.Id).ValueGeneratedNever();
            modelBuilder.Entity<Occupation>().Property(t => t.Id).ValueGeneratedNever();

            modelBuilder.Entity<PortfolioTransactionType>().Property(t => t.Id).ValueGeneratedNever();

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.Restrict;

            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetProperties())
                .Where(p => p.ClrType == typeof(decimal)))
            {
                //property.Relational().ColumnType = "decimal(18, 9)";
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           // if (Environment.MachineName.Equals("DESKTOP-ARBABNG", StringComparison.InvariantCultureIgnoreCase))
           //     optionsBuilder.UseSqlServer(
           //         "data source=(local);Initial Catalog=mycontextX;Integrated Security=SSPI;",
           //         builder => { builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(120), null); });
            //else if (Environment.MachineName.Equals("", StringComparison.InvariantCultureIgnoreCase))
                optionsBuilder.UseSqlServer(
                    "data source=(local);Initial Catalog=mycontextX;Integrated Security=SSPI;");
        }
    }
}