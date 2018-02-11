using Xunit;

namespace MaybeMongo.Tests.MongoDbIntegrationTests
{
    using FluentAssertions;
    using static CustomerTestValues;
    using static MaybeMongo.Domain.Id;

    public sealed class CustomerIntegrationTests : IntegrationTestsBase
    {
        [Fact]
        public void customer_id_set_to_some_value()
        {
            var repository = GetCustomerRepository();

            repository.Save(Milenko);

            Milenko.Id.Should().NotBe(None);
        }
    }
}