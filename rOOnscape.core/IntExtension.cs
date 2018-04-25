using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace rOOnscape.Core.Extensions {
  public static class IntExtension {
    public static IEnumerable<int> To(this int min, int max) => Enumerable.Range(min, max);
  }
}
