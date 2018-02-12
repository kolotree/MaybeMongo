using FluentAssertions;
using Xunit;

namespace MaybeMongo.Tests
{
	using static CustomerTestValues;
	using static AddressTestValues;

	public sealed class CustomerUnitTests
	{
		[Fact]
		public void two_customers_with_same_id_but_different_values_are_equal()
		{
			Milenko.Should().Be(OlderMilenko);
		}

		[Fact]
		public void two_customers_with_different_ids_are_not_equal()
		{
			Milenko.Should().NotBe(Stanko);
		}

		[Fact]
		public void billing_address_correctly_changed()
		{
			Milenko.SetAddress(MilenkoAddress);

			Milenko.MaybeBillingAddress.HasValue.Should().BeTrue("billing address is not set.");
			Milenko.MaybeBillingAddress.Value.Should().Be(MilenkoAddress);
		}
	}
}