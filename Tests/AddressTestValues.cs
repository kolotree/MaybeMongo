namespace MaybeMongo.Tests
{
	using Domain.CustomerAggregate;

	public static class AddressTestValues
	{
		public static Address MilenkoAddress => new Address("Milenko's address", "19", "Novi Sad");
		public static Address StankoAddress => new Address("Stanko's address", "66", "Novi Sad");
	}
}