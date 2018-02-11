namespace MaybeMongo.Tests
{
    using Domain;

    using static MaybeMongo.Domain.Id;

    public static class CustomerTestValues
    {
        public static Id StankoId => IdFrom("Stanko's Id");
        public static Id MilenkoId => IdFrom("Milenko's Id");

        public static Customer Milenko => new Customer(MilenkoId, "Milenko Jovanovic", 30);
        public static Customer Stanko => new Customer(StankoId, "Stanko Culaja", 30);

        public static Customer OlderMilenko => new Customer(MilenkoId, "Milenko Jovanovic", 50);
    }
}