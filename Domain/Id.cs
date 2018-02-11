using CSharpFunctionalExtensions;

namespace MaybeMongo.Domain
{
    public sealed class Id : ValueObject<Id>
	{
		public string StringId {get; }

		private Id(string id)
		{
			StringId = id;
		}

		public static Id None => new Id("None");

		public static Id IdFrom(string id) => string.IsNullOrEmpty(id) ? None : new Id(id);

		public override string ToString() => StringId;

        protected override bool EqualsCore(Id other)
            => StringId.Equals(other.StringId);

        protected override int GetHashCodeCore()
            => StringId.GetHashCode();
    }
}