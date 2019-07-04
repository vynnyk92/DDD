using System;
using System.Collections.Generic;
using System.Text;

namespace DDDInPrcatice.Logic
{
    public abstract class BaseEntity
    {
        public long Id { get; private set; }

        public override bool Equals(object obj)
        {
            var other = obj as BaseEntity;

            if (ReferenceEquals(other, null))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (GetType() != other.GetType())
                return false;

            if (Id == 0 || other.Id == 0)
                return false;

            return this.Id == other.Id;
        }

        public static bool operator ==(BaseEntity a, BaseEntity b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(BaseEntity a, BaseEntity b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (this.GetType().ToString() + Id).GetHashCode();
        }
    }
}
