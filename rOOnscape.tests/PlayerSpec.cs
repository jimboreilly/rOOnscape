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
      var strengthOnlyMax = buildListOfSkillsToReplace(new List<SkillName>() { SkillName.Strength }, maxSkill);
      var strengthPure = constructPlayerWithReplacedSkills(strengthOnlyMax);

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
      var newSkills = new List<(SkillName skill, string[] newData)> { (SkillName.Cooking, level2Skill) };
      var cookedSomeShrimpOnTutorialIsland = constructPlayerWithReplacedSkills(newSkills);

      Assert.AreEqual(Player.TotalSkills + 1, cookedSomeShrimpOnTutorialIsland.GetTotalLevel());
    }

    [Test]
    public void FindAllMaxSkillsOfPlayer() {
      var maxSkill = new[] { "1", "99", "1" };
      var fighterOnly = buildListOfSkillsToReplace(new List<SkillName>() { SkillName.Attack, SkillName.Hitpoints, SkillName.Defense }, maxSkill);
      var fighter = constructPlayerWithReplacedSkills(fighterOnly);

      var numberOfMaxSkills = 3;
      var expectedSkills = new List<string>() { "Attack", "Hitpoints", "Defense" };
      Assert.AreEqual(numberOfMaxSkills, fighter.GetMaxSkills().Count);
      CollectionAssert.AreEquivalent(expectedSkills, fighter.GetMaxSkills());
    }

    [Test]
    public void FindsASingleMaxOnAOneTrickPony() {
      var maxSkill = new[] { "1", "99", "1" };
      var onlyRunecrafts = buildListOfSkillsToReplace(new List<SkillName>() { SkillName.Runecrafting }, maxSkill);
      var runecrafter = constructPlayerWithReplacedSkills(onlyRunecrafts);

      var numberOfMaxSkills = 1;
      var expectedSkills = new List<string>() { "Runecrafting" };
      Assert.AreEqual(numberOfMaxSkills, runecrafter.GetMaxSkills().Count);
      CollectionAssert.AreEqual(expectedSkills, runecrafter.GetMaxSkills());
    }

    private IEnumerable<(SkillName skill, string[] newData)> buildListOfSkillsToReplace(List<SkillName> skillsToReplace, string[] newData) => skillsToReplace.Select(x => (x, newData));


    private Player constructPlayerWithReplacedSkills(IEnumerable<(SkillName skill, string[] newData)> replacementInfo) {
      var newSkills = defaultSkills.ToList();
      replacementInfo.ToList().ForEach(skillToReplace => {
        newSkills.Insert((int)skillToReplace.skill, skillToReplace.newData);
        newSkills.RemoveAt((int)skillToReplace.skill + 1);
      });

      return new Player(newSkills, defaultMinigames);
    }

  }
}