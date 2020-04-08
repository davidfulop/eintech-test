using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using NUnit.Framework;
using PeopleManager.Data;
using PeopleManager.Web.ControllerLogic;
using PeopleManager.Web.Controllers;
using PeopleManager.Web.Data;
using PeopleManager.Web.Models.AddPerson;

namespace PeopleManager.Web.UnitTests.ControllerLogic
{
    public class SearchControllerLogicTests
    {
        private SearchControllerLogic _subject;
        private List<Department> _departments;
        private List<Person> _people;
        private IDepartmentRepository _mockDepartmentsRepo;
        private IPeopleRepository _mockPeopleRepo;

        [SetUp]
        public void Before_Each()
        {
            _departments = new List<Department> {new Department(), new Department()};
            _mockDepartmentsRepo = Substitute.For<IDepartmentRepository>();
            _mockDepartmentsRepo.GetDepartmentsWithNameContaining(Arg.Any<string>())
                .Returns(_departments);

            _mockPeopleRepo = Substitute.For<IPeopleRepository>();
            _people = new List<Person> { new Person(), new Person() };
            _mockPeopleRepo.GetPeopleWithNameContaining(Arg.Any<string>())
                .Returns(_people);
            
            _subject = new SearchControllerLogic(_mockDepartmentsRepo, _mockPeopleRepo);
        }
        
        [Test]
        public void GetIndexModel_passes_down_uppercase_search_term_to_GetPeopleWithNameContaining()
        {
            const string searchTerm = "alma";
            const string expectedInput = "ALMA";
            _subject.GetIndexModel(searchTerm);

            _mockPeopleRepo.Received(1).GetPeopleWithNameContaining(expectedInput);
        }

        [Test]
        public void GetIndexModel_passes_down_uppercase_search_term_to_GetDepartmentsWithNameContaining()
        {
            const string searchTerm = "alma";
            const string expectedInput = "ALMA";
            _subject.GetIndexModel(searchTerm);

            _mockDepartmentsRepo.Received(1).GetDepartmentsWithNameContaining(expectedInput);
        }
        
        [Test]
        public void GetIndexModel_returns_departments_in_model()
        {
            var result = _subject.GetIndexModel(string.Empty);
            
            Assert.That(result.Departments, Is.EquivalentTo(_departments));
        }
        
        [Test]
        public void GetIndexModel_returns_people_in_model()
        {
            var result = _subject.GetIndexModel(string.Empty);
            
            Assert.That(result.People, Is.EquivalentTo(_people));
        }
    }
}
