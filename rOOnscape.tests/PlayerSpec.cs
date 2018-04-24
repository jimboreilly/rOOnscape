using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System;
using rOOnscape;
using rOOnscape.Types;

namespace rOOnscape.specs {
  public class Tests {
    private IEnumerable<string[]> defaultSkills;
    private IEnumerable<string[]> defaultMinigames;

    [SetUp]
    public void Setup() {
      var totalSkills = 23;
      var defaultSkillRankLevelExp = new[] { "-1", "1", "1" };
      defaultSkills = Enumerable.Range(0, totalSkills).Select(x => defaultSkillRankLevelExp);


      var totalMinigames = 9;
      var defaultMinigameRankScore = new[] { "-1", "1" };
      defaultMinigames = Enumerable.Range(0, totalMinigames).Select(x => defaultMinigameRankScore);
    }

    [Test]
    public void ConstructPlayerAPlayerWithNoExperience() {
      var osrsPlayer = new Player(defaultSkills, defaultMinigames);
      var skills = Enum.GetValues(typeof(SkillName)).Cast<SkillName>().AsEnumerable();
      Assert.IsTrue(skills.All(x => osrsPlayer.GetExperienceOfSkill(x).Equals(1)));
      Assert.IsTrue(skills.All(x => osrsPlayer.GetGlobalRankOfSkill(x).Equals(-1)));
      Assert.IsTrue(skills.All(x => osrsPlayer.GetLevelOfSkill(x).Equals(1)));
    }
  }
}