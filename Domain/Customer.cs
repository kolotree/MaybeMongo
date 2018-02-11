namespace MaybeMongo.Domain
{
    public sealed class Customer : Entity
    {
        public string Name { get; }
        public int Age { get; }
        
        public Customer(Id id, string name, int age)
        {
            this.Age = age;
            this.Name = name;
            Id = id;
        }
    }
}