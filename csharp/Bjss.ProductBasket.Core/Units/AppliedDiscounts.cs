namespace Bjss.ProductBasket.Core.Units
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public sealed class AppliedDiscounts : IEnumerable<AppliedDiscount>
    {
        private readonly List<AppliedDiscount> _registry = new List<AppliedDiscount>();

        public void Add(AppliedDiscount appliedDiscount)
        {
            _registry.Add(appliedDiscount);
        }

        public void AddRange(IEnumerable<AppliedDiscount> appliedDiscounts)
        {
            _registry.AddRange(appliedDiscounts);
        }

        public IEnumerator<AppliedDiscount> GetEnumerator()
        {
            return _registry.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            return !_registry.Any() ? "(No offers available)" : string.Join(Environment.NewLine, _registry);
        }
    }
}
