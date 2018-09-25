using System;

namespace FinanceDomain
{
    public abstract class Entity
    {
        public virtual Guid Id { get; set; }
        //protected virtual object Actual => this;

        //public override bool Equals(object obj)
        //{
        //    var other = obj as Entity;

        //    if (other is null)
        //        return false;

        //    if (ReferenceEquals(this, other))
        //        return true;

        //    if (Actual.GetType() != other.Actual.GetType())
        //        return false;

        //    return Id == other.Id;
        //}

        //public static bool operator ==(Entity a, Entity b)
        //{
        //    if (a is null && b is null)
        //        return true;

        //    if (a is null || b is null)
        //        return false;

        //    return a.Equals(b);
        //}

        //public static bool operator !=(Entity a, Entity b)
        //{
        //    return !(a == b);
        //}

        //public override int GetHashCode()
        //{
        //    return (Actual.GetType().ToString() + Id).GetHashCode();
        //}
    }
}