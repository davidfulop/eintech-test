using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using PeopleManager.Data;

namespace PeopleManager.Web.Data
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetDepartments();
        IEnumerable<Department> GetDepartmentsWithNameContaining(string nameFragment);
    }

    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ManagementContext _context;

        public DepartmentRepository(ManagementContext context)
        {
            _context = context;
        }

        public IEnumerable<Department> GetDepartments()
        {
            return _context.Departments;
        }

        public IEnumerable<Department> GetDepartmentsWithNameContaining(string nameFragment)
        {
            return _context.Departments
                .Where(d => d.Name.ToUpper().Contains(nameFragment.ToUpper()));
        }
    }
}
