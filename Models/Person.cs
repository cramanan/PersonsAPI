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
}
