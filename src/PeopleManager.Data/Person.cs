using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PeopleManager.Data
{
    [Table("people")]
    public class Person
    {
        [Key]
        public int PersonId { get; set; }
        [Required, Column(TypeName = "nvarchar(100)")]
        [StringLength(60, MinimumLength = 5, ErrorMessage = "Name should be at least 5 characters.")]
        public string Name { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime AddedAt { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
