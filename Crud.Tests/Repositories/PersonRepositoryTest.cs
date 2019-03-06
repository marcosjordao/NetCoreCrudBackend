using Crud.Domain.Entities;
using Crud.Domain.Repositories;
using Crud.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Crud.Tests.Repositories
{
    public class PersonRepositoryTest
    {
        private IPersonRepository _personRepository;

        public PersonRepositoryTest(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

    }
}
