namespace Bjss.ProductBasket.Core.Entities
{
    public abstract class Entity<TId>
    {
        public virtual TId Id { get; protected set; }

        protected bool IsTransient
        {
            get { return Equals(Id, default(TId)); }
        }

        public override bool Equals(object obj)
        {
            return EntitiesEquals(obj as Entity<TId>);
        }

        protected bool EntitiesEquals(Entity<TId> other)
        {
            if (other == null || !GetType().IsInstanceOfType(other))
                return false;

            if (IsTransient ^ other.IsTransient)
                return false;

            if (IsTransient && other.IsTransient)
                return ReferenceEquals(this, other);

            return Equals(Id, other.Id);
        }

        private int? _cachedHashCode;

        public override int GetHashCode()
        {
            if (_cachedHashCode.HasValue)
                return _cachedHashCode.Value;

            _cachedHashCode = IsTransient ? base.GetHashCode() : Id.GetHashCode();
            return _cachedHashCode.Value;
        }

        public static bool operator ==(Entity<TId> x, Entity<TId> y)
        {
            return Equals(x, y);
        }

        public static bool operator !=(Entity<TId> x, Entity<TId> y)
        {
            return !(x == y);
        }
    }
}
