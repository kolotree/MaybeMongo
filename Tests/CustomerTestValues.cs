using CSharpFunctionalExtensions;

namespace MaybeMongo.Tests
{
	using Domain;
	using Domain.CustomerAggregate;
	using static Domain.Id;
	using static Domain.CustomerAggregate.Customer;

	public static class CustomerTestValues
	{
		public static Id MilenkoId => IdFrom("Milenko's Id");
		public static Customer Milenko = new Customer(MilenkoId, "Milenko Jovanovic", 30, Maybe<Address>.None);
		public static Customer OlderMilenko = new Customer(MilenkoId, "Milenko Jovanovic", 50, Maybe<Address>.None);
		public static Customer NewMilenko() => NewCustomerFrom(Milenko.Name, Milenko.Age, Milenko.MaybeBillingAddress);


		public static Id StankoId => IdFrom("Stanko's Id");
		public static Customer Stanko = new Customer(StankoId, "Stanko Culaja", 30, Maybe<Address>.None);
	}
}