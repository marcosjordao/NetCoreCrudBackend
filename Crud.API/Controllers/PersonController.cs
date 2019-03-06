using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crud.Domain.Entities;
using Crud.Domain.Repositories;
using Crud.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Crud.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {

        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        // GET: api/Person
        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            var persons = await _personService.GetAllPersonsAsync();

            return Ok(persons);
        }


        // GET: api/Person/5
        [HttpGet("{id}", Name = "GetPerson")]
        public async Task<ActionResult> GetByIdAsync(int id)
        {

            var person = await _personService.GetPersonByIdAsync(id);

            if (person != null)
                return Ok(person);
            else
                return NotFound();
        }

        // POST: api/Person
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Person item)
        {
            if (item == null)
                return BadRequest();
            else
            {
                try
                {
                    await _personService.AddPersonAsync(item);

                    return CreatedAtRoute("GetPerson", new { id = item.Id }, item);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

        }

        // PUT: api/Person
        [HttpPut]
        public async Task<ActionResult<Person>> Update([FromBody] Person item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            try
            {
                await _personService.UpdatePersonAsync(item);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Person/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _personService.DeletePersonByIdAsync(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}