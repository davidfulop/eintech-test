using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using PeopleManager.Data;
using PeopleManager.Web.Data;

namespace PeopleManager.Web.UnitTests.Data
{
    public class DepartmentRepositoryTests
    {
        [Test]
        public async Task Should_return_all_departments()
        {
            using (var context = DatabaseMocker.CreateInMemoryContext())
            {
                await context.Departments.AddRangeAsync(
                    new Department { Name = "Dept 1"}, new Department { Name = "Dept 2"});
                await context.SaveChangesAsync();
            }

            using (var context = DatabaseMocker.CreateInMemoryContext())
            {
                var repository = new DepartmentRepository(context);
                var result = repository.GetDepartments();
                
                Assert.That(result.Count(), Is.EqualTo(2));
            }
        }
        
        [Test]
        public async Task Should_return_filtered_departments_only()
        {
            var dept1A = new Department { Name = "Dept 1A"};
            var dept2A = new Department { Name = "Dept 2A"};
            var dept2B = new Department { Name = "Dept 2B"};

            using (var context = DatabaseMocker.CreateInMemoryContext())
            {
                await context.Departments.AddRangeAsync(dept1A, dept2A, dept2B);
                await context.SaveChangesAsync();
            }

            using (var context = DatabaseMocker.CreateInMemoryContext())
            {
                var repository = new DepartmentRepository(context);
                var result = repository.GetDepartmentsWithNameContaining("2").ToList();

                Assert.That(result.Count, Is.EqualTo(2));
                Assert.That(result.ElementAt(0).Name, Is.EqualTo(dept2A.Name));
                Assert.That(result.ElementAt(1).Name, Is.EqualTo(dept2B.Name));
            }
        }
    }
}
