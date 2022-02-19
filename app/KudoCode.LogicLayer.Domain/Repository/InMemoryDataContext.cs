using System;
using Microsoft.EntityFrameworkCore;

namespace KudoCode.LogicLayer.Domain.Repository
{
    public class InMemoryDataContext : DataContext
    {
        public static string DbName;

        public InMemoryDataContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (string.IsNullOrEmpty(DbName))
                DbName = Guid.NewGuid().ToString().Replace("-", string.Empty);
            optionsBuilder.UseSqlServer(
                $@"Server=(localdb)\mssqllocaldb;Database={DbName};Trusted_Connection=True;ConnectRetryCount=0");
        }
    }
}