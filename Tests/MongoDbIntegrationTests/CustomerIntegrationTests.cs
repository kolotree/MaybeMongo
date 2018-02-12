using CSharpFunctionalExtensions;
using FluentAssertions;
using System.Linq;
using Xunit;

namespace MaybeMongo.Tests.MongoDbIntegrationTests
{
	using Domain.CustomerAggregate;
	using static MaybeMongo.Domain.CustomerAggregate.Customer;
	using static MaybeMongo.Domain.Id;

	public sealed class CustomerIntegrationTests : IntegrationTestsBase
	{
		[Fact]
		public void customer_from_database_has_id_set_to_some_value()
		{
			var newCustomer = NewCustomerFrom("John Doe", 45, Maybe<Address>.None);

			var repository = GetCustomerRepository();
			repository.Save(newCustomer);

			var actualCustomer = repository.GetAll().First();
			actualCustomer.Id.Should().NotBe(null, "Id has to be set to some value.");
			actualCustomer.Id.Should().NotBe(None, "Id has to be set to some value.");
		}

		[Fact]
		public void after_saving_both_new_customer_and_the_same_customer_from_db_have_equal_ids()
		{
			var newCustomer = NewCustomerFrom("John Doe", 45, Maybe<Address>.None);

			var repository = GetCustomerRepository();
			repository.Save(newCustomer);

			var actualCustomer = repository.GetAll().First();
			actualCustomer.Should().Be(newCustomer);
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