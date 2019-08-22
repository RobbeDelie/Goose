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
        private ApplicationDbContext _Context;

        public PersonRepository(ApplicationDbContext applicationDbContext)
        {
            _Context = applicationDbContext;
        }

        public List<Person> GetAll()
        {
            var persons = _Context.Persons.ToList();
            return persons;
        }

        public Person GetById(Guid id)
        {
            var person = _Context.Persons.Where(x => x.Id == id).FirstOrDefault();
            return person;
        }
    }
}
