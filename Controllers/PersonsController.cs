using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonsAPI.Models;

namespace PersonsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController(PersonsAPIContext ctx) : ControllerBase
    {
        public readonly PersonsAPIContext _dbContext = ctx;


        [HttpPost]
        public async Task<ActionResult<Person>> PostPerson(Person person) {
            if (_dbContext == null) return NotFound();
            
            
            _dbContext.Persons.Add(person);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(PostPerson), person);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetPersons() => _dbContext == null ? NotFound() : await _dbContext.Persons.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPersonById(Guid id)
        {
            if (_dbContext == null) return NotFound();

            Person? person = await _dbContext.Persons.FindAsync(id);
            if (person == null) return NotFound();
            
            return person;
        }
    }
}
