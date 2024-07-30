using Microsoft.EntityFrameworkCore;

namespace PersonsAPI.Models
{
    public class PersonsAPIContext(DbContextOptions<PersonsAPIContext> options) : DbContext(options)
    {
        public DbSet<Person> Persons { get; set; }
    }
}
