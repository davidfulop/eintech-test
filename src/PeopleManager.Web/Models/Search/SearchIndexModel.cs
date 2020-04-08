using System.Collections.Generic;
using System.Linq;
using PeopleManager.Data;

namespace PeopleManager.Web.Models.Search
{
    public class SearchIndexModel
    {
        public IEnumerable<Person> People { get; set; }
        public IEnumerable<Department> Departments { get; set; }
    }
}
