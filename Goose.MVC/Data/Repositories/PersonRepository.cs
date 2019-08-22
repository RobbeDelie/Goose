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

        public async Task UpdateAsync(Person person)
        {
            var result = _context.Persons.Where(x => x.Id == person.Id).FirstOrDefault();
            if (result != null)
            {
                result.FirstName = person.FirstName;
                result.LastName = person.LastName;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            _context.Persons.Remove(_context.Persons.Where(x => x.Id == id).FirstOrDefault());
            await _context.SaveChangesAsync();
        }

        public async Task CreateAsync(Person person)
        {
            _context.Persons.Add(person);
            await _context.SaveChangesAsync();
        }
    }
}
