using Swashbuckle.AspNetCore.Annotations;
using System.Text.Json.Serialization;

namespace PersonsAPI.Models
{
    public class Person
    {
        public Guid Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required int Age { get; set; }
        public required DateOnly DateOfBirth { get; set; }
        public required string Email { get; set; }
    }

    public class PostPersonRequest
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required int Age { get; set; }
        public required DateOnly DateOfBirth { get; set; }
        public required string Email { get; set; }
        public Person ToPerson() => new()
        {
            Id = Guid.NewGuid(),
            FirstName = FirstName,
            LastName = LastName,
            Age = Age,
            DateOfBirth = DateOfBirth,
            Email = Email
        };
    }

    public class PersonDTO
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? Age { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public string? Email { get; set; }
    }
}
