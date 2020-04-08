using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PeopleManager.Data
{
    [Table("departments")]
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        [Required, Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }
        public List<Person> Persons { get; set; }
    }
}
