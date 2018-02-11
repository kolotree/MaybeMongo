using System;
using CSharpFunctionalExtensions;

namespace MaybeMongo.Domain
{
    using static Id;

    public sealed class Customer : AggregateRoot
    {
        public string Name { get; }
        public int Age { get; }
        public Maybe<Address> MaybeBillingAddress { get; private set;}

        public Customer(Id id, string name, int age, Maybe<Address> maybeAddress)
        {
            Age = age;
            MaybeBillingAddress = maybeAddress;
            Name = name;
            Id = id;
        }

        public static Customer NewCustomerFrom(string name, int age, Maybe<Address> maybeAddress)
            => new Customer(None, name, age, maybeAddress);

        public Customer SetAddress(Address billingAddress)
        {
            MaybeBillingAddress = billingAddress;
            return this;
        }
    }
}