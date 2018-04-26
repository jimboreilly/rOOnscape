using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System;
using rOOnscape.Structures.Types;
using rOOnscape.Structures;

namespace rOOnscape.Specs {
  public class SkillSpec {
    [Test]
    public void CanConstructASkill() {
      var skill = new Skill(Rank: 1, Level: 1, Experience: 1);
      Assert.AreEqual(1, skill.GetRank);
      Assert.AreEqual(1, skill.GetLevel);
      Assert.AreEqual(1, skill.GetExperience);

      skill = new Skill(Rank: 2000, Level: 78, Experience: 100000);
      Assert.AreEqual(2000, skill.GetRank);
      Assert.AreEqual(78, skill.GetLevel);
      Assert.AreEqual(100000, skill.GetExperience);
    }

  }
}
