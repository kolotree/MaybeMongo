using Xunit;

namespace MaybeMongo.Tests
{
    using Domain;
    using FluentAssertions;
    using static CustomerTestValues;

    public sealed class CustomerUnitTests
    {
        [Fact]
        public void two_customers_with_same_id_but_different_values_are_equal()
        {
            Milenko.Should().Be(OlderMilenko);
        }

        [Fact]
        public void two_customer_with_different_ids_are_not_equal()
        {
            Milenko.Should().NotBe(Stanko);
        }
    }
}