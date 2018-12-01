using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System;
using rOOnscape.Structures.Types;
using rOOnscape.Structures;

namespace rOOnscape.Structures.Specs {
  public class MinigameSpec {
    [Test]
    public void CanConstructAMinigame() {
      var minigame = new Minigame(Rank: 1, Score: 1);

      Assert.AreEqual(1, minigame.Rank);
      Assert.AreEqual(1, minigame.Score);

      minigame = new Minigame(Rank: 200, Score: 47);
      Assert.AreEqual(200, minigame.Rank);
      Assert.AreEqual(47, minigame.Score);
    }
  }
}
