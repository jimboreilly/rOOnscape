using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System;
using rOOnscape.Core.Extensions;

namespace rOOnscape.Core.Extensions.Specs {
  public class IntExtensionSpec {

    [Test]
    public void BuildAListOf1Through10() {
      CollectionAssert.AreEqual(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }.AsEnumerable(), 1.To(10));
    }

    [Test]
    public void BuildAListOf2Through6() {
      CollectionAssert.AreEqual(new int[] { 2, 3, 4, 5, 6 }.AsEnumerable(), 2.To(6));
    }

    [Test]
    public void BuildAListThatStartsAt0() {
      var test = 0.To(3);

      foreach (var x in test) {
        Console.WriteLine(x);
      }
      CollectionAssert.AreEqual(new int[] { 0, 1, 2, 3 }.AsEnumerable(), 0.To(3));
    }

  }
}