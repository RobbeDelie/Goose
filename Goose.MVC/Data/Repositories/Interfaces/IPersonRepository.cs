using Goose.MVC.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Goose.MVC.Data.Repositories.Interfaces
{
    public interface IPersonRepository
    {
        List<Person> GetAll();
        Person GetById(Guid id);
        Task UpdateAsync(Person newPerson);
        Task DeleteAsync(Guid id);
        Task CreateAsync(Person person);
    }
}
