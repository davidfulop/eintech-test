using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using PeopleManager.Data;
using PeopleManager.Web.Data;

namespace PeopleManager.Web.UnitTests.Data
{
    public class PeopleRepositoryTests
    {
        [Test]
        public async Task Should_return_filtered_people_only()
        {
            var pA = new Person { Name = "Some One", Department = new Department()};
            var pB = new Person { Name = "Someone Else", Department = new Department()};
            var pC = new Person { Name = "Xx Yy", Department = new Department()};

            using (var context = DatabaseMocker.CreateInMemoryContext())
            {
                await context.Persons.AddRangeAsync(pA, pB, pC);
                await context.SaveChangesAsync();
            }

            using (var context = DatabaseMocker.CreateInMemoryContext())
            {
                var repository = new PeopleRepository(context);
                var result = repository.GetPeopleWithNameContaining("o").ToList();

                Assert.That(result.Count, Is.EqualTo(2));
                Assert.That(result.ElementAt(0).Name, Is.EqualTo(pA.Name));
                Assert.That(result.ElementAt(1).Name, Is.EqualTo(pB.Name));
            }
        }
        
        [Test]
        public async Task Should_include_Departments()
        {
            var pA = new Person { Name = "Some One", Department = new Department()};
            var pB = new Person { Name = "Someone Else", Department = new Department()};
            var pC = new Person { Name = "Xx Yy", Department = new Department()};

            using (var context = DatabaseMocker.CreateInMemoryContext())
            {
                await context.Persons.AddRangeAsync(pA, pB, pC);
                await context.SaveChangesAsync();
            }

            using (var context = DatabaseMocker.CreateInMemoryContext())
            {
                var repository = new PeopleRepository(context);
                var result = repository.GetPeopleWithNameContaining("o").ToList();

                Assert.That(result.First().Department, Is.Not.Null);
            }
            //NOTE: this is a bit moot, as I needed to include departments in the people
            // because of the limitations of the in mem db. Kept it to indicate how I was
            // thinking when adding the next feature.
        }
    }
}
