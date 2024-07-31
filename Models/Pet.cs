namespace PersonsAPI.Models
{
    public class Pet
    {
        public Guid Id { get; set; }
        public required string Animal {  get; set; } 
        public Guid? OwnerId { get; set; }
        public required string Name { get; set; }
        public int Age { get; set; }
    }

    public class PostPetRequest
    {
        public required string Animal { get; set; }
        public Guid? OwnerId { get; set; }
        public required string Name { get; set; }
        public int Age { get; set; }

        public Pet ToPet() => new()
        {
            Id = Guid.NewGuid(),
            Animal = Animal,
            OwnerId = OwnerId,
            Name = Name,
            Age = Age,
        };
    }
}
