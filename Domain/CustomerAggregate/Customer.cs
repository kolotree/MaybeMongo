using CSharpFunctionalExtensions;

namespace MaybeMongo.Domain.CustomerAggregate
{
	using static Id;

	public sealed class Customer : AggregateRoot
	{
		public string Name { get; }
		public int Age { get; }
		public Maybe<Address> MaybeBillingAddress { get; private set;}

		public Customer(Id id, string name, int age, Maybe<Address> maybeBillingAddress)
		{
			Id = id;
			Name = name;
			Age = age;
			MaybeBillingAddress = maybeBillingAddress;
		}

		public static Customer NewCustomerFrom(string name, int age, Maybe<Address> maybeAddress)
			=> new Customer(None, name, age, maybeAddress);

		public Customer SetBillingAddress(Address address)
		{
			MaybeBillingAddress = address;
			return this;
		}
	}
}