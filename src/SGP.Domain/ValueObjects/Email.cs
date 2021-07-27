using SGP.Shared.ValueObjects;
using System.Collections.Generic;

namespace SGP.Domain.ValueObjects
{
    public sealed class Email : ValueObject
    {
        public Email(string address)
        {
            Address = address?.ToLowerInvariant();
        }

        private Email() // ORM
        {
        }

        public string Address { get; private init; }

        public override string ToString()
        {
            return Address;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Address;
        }
    }
}