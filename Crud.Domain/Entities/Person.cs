using Crud.Domain.Entities.Base;
using Crud.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crud.Domain.Entities
{
    public class Person: Entity
    {
        public Person(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }
        public Email Email { get; set; }
        public string Phone { get; set; }

    }
}
