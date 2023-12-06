using System;
using System.Collections.Generic;

namespace ColumnCreateFromDWG.Wrappers
{
    public class LayerWrapperEqualityComparer : IEqualityComparer<LayerWrapper>
    {
        public bool Equals(LayerWrapper x, LayerWrapper y)
        {
            if (ReferenceEquals(x, y))
                return true;

            if (x is null || y is null)
                return false;

            return x.ToString().Equals(y.ToString(), StringComparison.OrdinalIgnoreCase);
        }

        public int GetHashCode(LayerWrapper obj)
        {
            return obj?.ToString()?.GetHashCode() ?? 0;
        }
    }
}
