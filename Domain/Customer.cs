using System;
using CSharpFunctionalExtensions;

namespace MaybeMongo.Domain
{
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

        public Customer SetAddress(Address billingAddress)
        {
            MaybeBillingAddress = billingAddress;
            return this;
        }
    }
}