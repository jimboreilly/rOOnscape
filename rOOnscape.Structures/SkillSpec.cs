using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System;
using rOOnscape.Structures.Types;
using rOOnscape.Structures;

namespace rOOnscape.Structures.Specs {
  public class SkillSpec {
    [Test]
    public void CanConstructASkill() {
      var skill = new Skill(Rank: 1, Level: 1, Experience: 1);
      Assert.AreEqual(1, skill.Rank);
      Assert.AreEqual(1, skill.Level);
      Assert.AreEqual(1, skill.Experience);

      skill = new Skill(Rank: 2000, Level: 78, Experience: 100000);
      Assert.AreEqual(2000, skill.Rank);
      Assert.AreEqual(78, skill.Level);
      Assert.AreEqual(100000, skill.Experience);
    }


    [Test]
    public void IsMaxReturnsTrueForLevel99Skill() {
      var skill = new Skill(Rank: 1, Level: 99, Experience: 9000000);

      Assert.IsTrue(skill.IsMax);
    }

    [Test]
    public void IsMaxReturnsFalseForNonLevel99Skill() {
      var skill = new Skill(Rank: 1, Level: 20, Experience: 9000);

      Assert.IsFalse(skill.IsMax);
    }
  }
}
