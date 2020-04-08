using System.Collections.Generic;
using PeopleManager.Data;

namespace PeopleManager.Web.Models.AddPerson
{
    public class AddPersonIndexModel
    {
        public IEnumerable<Department> Departments { get; set; }
        public Person NewPerson { get; set; }
    }
}
