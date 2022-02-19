using System;
using KudoCode.LogicLayer.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace KudoCode.Test.Unit.InMemoryDataBase
{
    public class InMemoryDataContextUnitTest : DataContext
    {
        [ThreadStatic] private static string _dbName;

        public InMemoryDataContextUnitTest()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (string.IsNullOrEmpty(_dbName))
                _dbName = Guid.NewGuid().ToString().Replace("-", string.Empty);
            optionsBuilder.UseSqlServer(
                $@"Server=(localdb)\mssqllocaldb;Database={_dbName};Trusted_Connection=True;ConnectRetryCount=0");
        }
    }
}