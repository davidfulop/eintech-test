using Microsoft.AspNetCore.Mvc;
using PeopleManager.Web.Data;
using PeopleManager.Web.Models.AddPerson;

namespace PeopleManager.Web.ControllerLogic
{
    public interface IAddPersonControllerLogic
    {
        AddPersonIndexModel GetIndexModel();
        AddPersonModel AddPerson(AddPersonIndexModel input);
    }

    public class AddPersonControllerLogic : IAddPersonControllerLogic
    {
        private readonly IDepartmentRepository _departments;
        private readonly IPeopleRepository _people;

        public AddPersonControllerLogic(IDepartmentRepository departments, IPeopleRepository people)
        {
            _departments = departments;
            _people = people;
        }

        public AddPersonIndexModel GetIndexModel()
        {
            return new AddPersonIndexModel {
                Departments = _departments.GetDepartments()
            };
        }
        
        public AddPersonModel AddPerson(AddPersonIndexModel input)
        {
            var result = _people.AddPerson(input.NewPerson);
            return new AddPersonModel {
                AddedPerson = result
            };
        }
    }
}
