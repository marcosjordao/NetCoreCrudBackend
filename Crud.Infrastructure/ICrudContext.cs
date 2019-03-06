using Crud.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Crud.Infrastructure
{
    public interface ICrudContext
    {
        DbSet<Person> Persons { get; set; }
    }
}