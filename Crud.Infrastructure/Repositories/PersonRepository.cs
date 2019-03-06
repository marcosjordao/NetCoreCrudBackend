using Crud.Domain.Entities;
using Crud.Domain.Repositories;
using Crud.Infrastructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crud.Infrastructure.Repositories
{
    public class PersonRepository: BaseRepository<Person>, IPersonRepository
    {
        public PersonRepository(CrudContext context) : base(context)
        {
        }
    }
}
