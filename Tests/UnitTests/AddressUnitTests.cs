using FluentAssertions;
using Xunit;

namespace MaybeMongo.Tests
{
	using Domain.CustomerAggregate;
	using static AddressTestValues;

	public sealed class AddressUnitTests
	{
		[Fact]
		public void two_different_addresses_are_not_equal()
		{
			MilenkoAddress.Should().NotBe(StankoAddress);
		}

		[Fact]
		public void two_same_addresses_are_equal()
		{
			new Address("Street", "Number", "City")
				.Should()
				.Be(new Address("Street", "Number", "City"));
		}
	}
}