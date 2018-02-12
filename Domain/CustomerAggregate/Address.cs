using CSharpFunctionalExtensions;

namespace MaybeMongo.Domain.CustomerAggregate
{
    public sealed class Address : ValueObject<Address>
    {
        public string Street { get; }
        public string Number { get; }
        public string City { get; }
        
        public Address(string street, string number, string city)
        {
            this.Street = street;
            this.Number = number;
            this.City = city;
        }

        protected override bool EqualsCore(Address other) =>
            Street.Equals(other.Street) &&
            Number.Equals(other.Number) &&
            City.Equals(other.City);

        protected override int GetHashCodeCore() =>
            Street.GetHashCode() ^
            Number.GetHashCode() ^
            City.GetHashCode();
    }
}