namespace WebApplication1.Model
{
    public class Person
    {
        public string Id { get; set; } //Int for the sake of int
        public string Name { get; set; }
        public string Address { get; set; }

    }

    public class PersonCollection
    {
        public List<Person> Persons { get; set;}

        public List<Person> GetPersons()
        {
            return new List<Person>()
            {
                new Person()
                {
                    Id = "1",
                    Name = "Timmy",
                    Address = "123 abc"
                },
                new Person()
                {
                    Id = "2",
                    Name = "Jimmy",
                    Address = "123 cba"
                },
            };
        }
    }
}
