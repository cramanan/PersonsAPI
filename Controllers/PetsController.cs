using Microsoft.AspNetCore.Mvc;
using PersonsAPI.Models;

namespace PersonsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController(PersonsAPIContext context) : ControllerBase
    {
        private readonly PersonsAPIContext _dbContext = context;
        private async Task<Person?> GetPersonByIdInternal(Guid id) => _dbContext == null ? null : await _dbContext.Persons.FindAsync(id);

        [HttpPost]
        public async Task<ActionResult<Pet>> PostPet(PostPetRequest request)
        {
            if (_dbContext == null) return NotFound();
            if (request.OwnerId != null && await GetPersonByIdInternal(request.OwnerId.Value) == null)
                return BadRequest("OwnerId is unknown");
            Pet pet = request.ToPet();
            _dbContext.Pets.Add(pet);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(PostPet), pet);
        }
    }
}