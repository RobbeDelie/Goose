﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Goose.MVC.Data;
using Goose.MVC.Data.Repositories.Interfaces;
using Goose.MVC.Models;
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
            var persons = _personRepository.GetAllAsync();
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
    }
}