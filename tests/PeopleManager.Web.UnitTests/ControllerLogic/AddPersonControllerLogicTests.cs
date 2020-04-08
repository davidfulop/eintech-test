using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using PeopleManager.Data;
using PeopleManager.Web.ControllerLogic;
using PeopleManager.Web.Controllers;
using PeopleManager.Web.Data;
using PeopleManager.Web.Models.AddPerson;

namespace PeopleManager.Web.UnitTests.ControllerLogic
{
    public class AddPersonControllerLogicTests
    {
        private AddPersonControllerLogic _subject;
        private List<Department> _departments;
        private IPeopleRepository _mockPeopleRepo;

        [SetUp]
        public void Before_Each()
        {
            _departments = new List<Department> {new Department(), new Department()};
            var fakeDepartmentsRepo = Substitute.For<IDepartmentRepository>();
            fakeDepartmentsRepo.GetDepartments().Returns(_departments);

            _mockPeopleRepo = Substitute.For<IPeopleRepository>();
            _mockPeopleRepo.AddPerson(Arg.Any<Person>())
                .Returns(new Person { Name = "Test Person"});

            _subject = new AddPersonControllerLogic(fakeDepartmentsRepo, _mockPeopleRepo);
        }

        [Test]
        public void GetIndexModel_returns_departments_in_model()
        {
            var result = _subject.GetIndexModel();
            
            Assert.That(result.Departments, Is.EquivalentTo(_departments));
        }
                
        [Test]
        public void AddPerson_passes_down_NewPerson_to_repository()
        {
            var newPerson = new Person { Name = "Someone" };
            var input = new AddPersonIndexModel { NewPerson = newPerson };
            _subject.AddPerson(input);

            _mockPeopleRepo.Received(1).AddPerson(newPerson);
        }
        
        [Test]
        public void AddPerson_returns_Person_in_model()
        {
            var input = new AddPersonIndexModel();
            var result = _subject.AddPerson(input);
            
            Assert.That(result.AddedPerson.Name, Is.EqualTo("Test Person"));
        }
    }
}
