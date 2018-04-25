using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System;
using rOOnscape;
using rOOnscape.Types;

namespace rOOnscape.tests {
  public class SkillSpec {

    [Test]
    public void CanConstructASkill() {
      var skill = new Skill(new[] { "1", "1", "1" });
      Assert.AreEqual(1, skill.GetRank);
      Assert.AreEqual(1, skill.GetLevel);
      Assert.AreEqual(1, skill.GetExperience);
    }

  }
}
