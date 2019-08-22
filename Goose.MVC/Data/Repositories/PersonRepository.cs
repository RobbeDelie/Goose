using Goose.MVC.Data.Entities;
using Goose.MVC.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Goose.MVC.Data.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private ApplicationDbContext _context;

        public PersonRepository(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public List<Person> GetAll()
        {
            var persons = _context.Persons.ToList();
            return persons;
        }

        public Person GetById(Guid id)
        {
            var person = _context.Persons.Where(x => x.Id == id).FirstOrDefault();
            return person;
        }

        public async Task UpdateAsync(Person newPerson)
        {
            var person = _context.Persons.Where(x => x.Id == newPerson.Id).FirstOrDefault();
            if(person != null)
            {
                person.FirstName = newPerson.FirstName;
                person.LastName = newPerson.LastName;
                await _context.SaveChangesAsync();
            }
        }
    }
}
