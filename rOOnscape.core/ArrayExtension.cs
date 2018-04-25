using System;
using System.Linq;
using System.Collections.Generic;

namespace rOOnscape.Core.Extensions {
  public static class ArrayExtension {
    public static int[] ToIntArray(this string[] arr) => arr.Select(x => Int32.Parse(x)).ToArray();
  }
}
