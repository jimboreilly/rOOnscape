using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System;
using rOOnscape.Structures;
using rOOnscape.Structures.Types;
using rOOnscape.Core.Extensions;

namespace rOOnscape.Specs {
  public class Tests {
    private IEnumerable<string[]> defaultSkills;
    private IEnumerable<string[]> defaultMinigames;

    [SetUp]
    public void Setup() {
      var defaultSkillRankLevelExp = new[] { "-1", "1", "1" };
      defaultSkills = 0.To(Player.TotalSkills).Select(x => defaultSkillRankLevelExp);

      var defaultMinigameRankScore = new[] { "-1", "1" };
      defaultMinigames = 0.To(Player.TotalMinigames).Select(x => defaultMinigameRankScore);
    }

    [Test]
    public void ConstructPlayerAPlayerWithNoExperience() {
      var osrsPlayer = new Player(defaultSkills, defaultMinigames);
      var skills = Enum.GetValues(typeof(SkillName)).Cast<SkillName>().AsEnumerable();
      Assert.IsTrue(skills.All(x => osrsPlayer.GetExperienceOfSkill(x).Equals(1)));
      Assert.IsTrue(skills.All(x => osrsPlayer.GetGlobalRankOfSkill(x).Equals(-1)));
      Assert.IsTrue(skills.All(x => osrsPlayer.GetLevelOfSkill(x).Equals(1)));
    }

    [Test]
    public void ConstructAStrengthPure() {
      var maxSkill = new[] { "1", "99", "200000000" };

      var strengthPure = constructPlayerWithReplacedSkill(SkillName.Strength, maxSkill);

      Assert.IsTrue(strengthPure.IsMaxSkill(SkillName.Strength));
      Assert.IsFalse(strengthPure.IsMaxSkill(SkillName.Defense));
      Assert.AreEqual(99, strengthPure.GetLevelOfSkill(SkillName.Strength));
    }

    [Test]
    public void TotalLevelOfNewPlayerIsEqualToTotalSkills() {
      var noob = new Player(defaultSkills, defaultMinigames);
      Assert.AreEqual(Player.TotalSkills, noob.GetTotalLevel());
    }

    [Test]
    public void APlayerAfterTheFirstStepOfTutorialIslandHasPlus1TotalLevel() {
      var level2Skill = new[] { "1", "2", "83" };
      var cookedSomeShrimpOnTutorialIsland = constructPlayerWithReplacedSkill(SkillName.Cooking, level2Skill);

      Assert.AreEqual(Player.TotalSkills + 1, cookedSomeShrimpOnTutorialIsland.GetTotalLevel());
    }

    private Player constructPlayerWithReplacedSkill(SkillName replacedSkill, string[] newInfo) {
      var allskills = defaultSkills.ToList();
      allskills.Insert((int)replacedSkill, newInfo);
      allskills.RemoveAt((int)replacedSkill + 1);

      return new Player(allskills, defaultMinigames);
    }

  }
}