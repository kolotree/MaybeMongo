using CSharpFunctionalExtensions;
using MaybeMongo.Domain;
using Xunit;

namespace MaybeMongo.Tests.MongoDbIntegrationTests
{
    using FluentAssertions;
    using static MaybeMongo.Domain.Id;
    using static MaybeMongo.Domain.Customer;
    using System.Linq;

    public sealed class CustomerIntegrationTests : IntegrationTestsBase
    {
        [Fact]
        public void customer_id_set_to_some_value()
        {
            var newCustomer = NewCustomerFrom("John Doe", 45, Maybe<Address>.None);

            var repository = GetCustomerRepository();
            repository.Save(newCustomer);

            var actualCustomer = repository.GetAll().First();
            actualCustomer.Id.Should().NotBe(null, "Id has to be set to some value.");
            actualCustomer.Id.Should().NotBe(None, "Id has to be set to some value.");
        }

        [Fact]
        public void customer_values_persisted_to_db()
        {
            var newCustomer = NewCustomerFrom("John Doe", 45, Maybe<Address>.None);

            var repository = GetCustomerRepository();
            repository.Save(newCustomer);

            var actualCustomer = repository.GetAll().First();
            actualCustomer.Name.Should().Be(newCustomer.Name);
            actualCustomer.Age.Should().Be(newCustomer.Age);
            actualCustomer.MaybeBillingAddress.Should().Be(newCustomer.MaybeBillingAddress);
        }
    }
}