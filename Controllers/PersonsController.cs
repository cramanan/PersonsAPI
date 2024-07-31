﻿using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<List<Person>>> GetPersons() => _dbContext == null ? NotFound() : await _dbContext.Persons.ToListAsync();


        private async Task<Person?> GetPersonByIdInternal(Guid id)
        {
            if (_dbContext == null) return null;
            return await _dbContext.Persons.FindAsync(id);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPersonById(Guid id)
        {
            Person? person = await GetPersonByIdInternal(id);
            if (person == null) return NotFound();
            return person;
        }

        [HttpDelete]
        public async Task<ActionResult<Person>> DeletePerson(Guid id)
        {
            Person? person = await GetPersonByIdInternal(id);
            if (person == null) return NotFound();
            _dbContext.Persons.Remove(person);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
