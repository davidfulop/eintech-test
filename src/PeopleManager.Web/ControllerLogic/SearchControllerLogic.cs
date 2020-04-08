using PeopleManager.Web.Data;
using PeopleManager.Web.Models.Search;

namespace PeopleManager.Web.ControllerLogic
{
    public interface ISearchControllerLogic
    {
        SearchIndexModel GetIndexModel(string searchTerm);
    }

    public class SearchControllerLogic : ISearchControllerLogic
    {
        private readonly IDepartmentRepository _departments;
        private readonly IPeopleRepository _people;

        public SearchControllerLogic(IDepartmentRepository departments, IPeopleRepository people)
        {
            _departments = departments;
            _people = people;
        }

        public SearchIndexModel GetIndexModel(string searchTerm)
        {
            var upperTerm = searchTerm.ToUpper();
            var peopleFiltered = _people.GetPeopleWithNameContaining(upperTerm);
            var departmentsFiltered = _departments.GetDepartmentsWithNameContaining(upperTerm);
            
            return new SearchIndexModel {
                People = peopleFiltered, Departments = departmentsFiltered
            };
        }
    }
}
