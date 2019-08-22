using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Goose.MVC.Models.Person
{
    public class PersonDeleteModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
