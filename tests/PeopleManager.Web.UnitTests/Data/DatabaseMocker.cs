using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using PeopleManager.Data;

namespace PeopleManager.Web.UnitTests.Data
{
    class DatabaseMocker
    {
        internal static ManagementContext CreateInMemoryContext([CallerMemberName]string dbName = null)
        {
            var options = new DbContextOptionsBuilder<ManagementContext>()
                .UseInMemoryDatabase(databaseName: dbName).Options;
            return new ManagementContext(options);
        }
    }
}
