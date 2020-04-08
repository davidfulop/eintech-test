using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PeopleManager.Data;

namespace PeopleManager.Web.Data
{
    public interface IPeopleRepository
    {
        IEnumerable<Person> GetPeopleWithNameContaining(string nameFragment);
        Person AddPerson(Person p);
    }

    public class PeopleRepository : IPeopleRepository
    {
        private readonly ManagementContext _context;

        public PeopleRepository(ManagementContext context)
        {
            _context = context;
        }
        
        public IEnumerable<Person> GetPeopleWithNameContaining(string nameFragment)
        {
            return _context.Persons
                .Where(p => p.Name.ToUpper().Contains(nameFragment.ToUpper()))
                .Include(p => p.Department);
        }

        public Person AddPerson(Person p)
        {
            p.AddedAt = DateTime.UtcNow;
            var entityEntry = _context.Persons.Add(p);
            _context.SaveChanges();
            return entityEntry.Entity;
        }
    }
}
