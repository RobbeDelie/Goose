using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Goose.MVC.Data;
using Goose.MVC.Data.Repositories.Interfaces;
using Goose.MVC.Models.Person;
using Microsoft.AspNetCore.Mvc;

namespace Goose.MVC.Controllers
{
    public class PersonController : Controller
    {

        private IPersonRepository _personRepository;

        public PersonController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }


        public IActionResult Index()
        {
            var persons = _personRepository.GetAll();
            var model = new List<PersonListItemModel>();
            foreach (var person in persons)
            {
                var listModel = new PersonListItemModel
                {
                    Id = person.Id,
                    Name = $"{person.FirstName}, {person.LastName}"
                };
                model.Add(listModel);
            }
            return View(model);
        }

        public IActionResult Details(Guid id)
        {
            var person = _personRepository.GetById(id);
            var model = new PersonDetailsModel
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName
            };
            return View(model);
        }
    }
}