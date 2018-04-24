using System.Linq;
using System.Collections.Generic;
using rOOnscape.Types;

namespace rOOnscape {

  public class Player {

    private Dictionary<Skills, Skill> skills = new Dictionary<Skills, Skill>();
    private Dictionary<Minigames, Minigame> minigames = new Dictionary<Minigames, Minigame>();

    public Player(IEnumerable<string[]> skillData, IEnumerable<string[]> miniGameData) {
      // var overallOffset = 1; //first row is overall meta data
      // var scrollsOffset = 10; //last rows are clue scroll meta data
      // var totalskills = playerDataString.Count(); //size of input for Take

      // var justSkillLevels = playerDataString.Take(totalskills - scrollsOffset).Skip(overallOffset);

      skills.Add(Skills.Attack, new Skill(skillData.ElementAt((int)Skills.Attack)));
      skills.Add(Skills.Defense, new Skill(skillData.ElementAt((int)Skills.Defense)));
      skills.Add(Skills.Strength, new Skill(skillData.ElementAt((int)Skills.Strength)));
      skills.Add(Skills.Hitpoints, new Skill(skillData.ElementAt((int)Skills.Hitpoints)));
      skills.Add(Skills.Ranged, new Skill(skillData.ElementAt((int)Skills.Ranged)));
      skills.Add(Skills.Prayer, new Skill(skillData.ElementAt((int)Skills.Prayer)));
      skills.Add(Skills.Magic, new Skill(skillData.ElementAt((int)Skills.Magic)));
      skills.Add(Skills.Cooking, new Skill(skillData.ElementAt((int)Skills.Cooking)));
      skills.Add(Skills.Woodcutting, new Skill(skillData.ElementAt((int)Skills.Woodcutting)));
      skills.Add(Skills.Fletching, new Skill(skillData.ElementAt((int)Skills.Fletching)));
      skills.Add(Skills.Fishing, new Skill(skillData.ElementAt((int)Skills.Fishing)));
      skills.Add(Skills.Firemaking, new Skill(skillData.ElementAt((int)Skills.Firemaking)));
      skills.Add(Skills.Crafting, new Skill(skillData.ElementAt((int)Skills.Crafting)));
      skills.Add(Skills.Smithing, new Skill(skillData.ElementAt((int)Skills.Smithing)));
      skills.Add(Skills.Mining, new Skill(skillData.ElementAt((int)Skills.Mining)));
      skills.Add(Skills.Herblore, new Skill(skillData.ElementAt((int)Skills.Herblore)));
      skills.Add(Skills.Agility, new Skill(skillData.ElementAt((int)Skills.Agility)));
      skills.Add(Skills.Theiving, new Skill(skillData.ElementAt((int)Skills.Theiving)));
      skills.Add(Skills.Slayer, new Skill(skillData.ElementAt((int)Skills.Slayer)));
      skills.Add(Skills.Farming, new Skill(skillData.ElementAt((int)Skills.Farming)));
      skills.Add(Skills.Runecrafting, new Skill(skillData.ElementAt((int)Skills.Runecrafting)));
      skills.Add(Skills.Hunter, new Skill(skillData.ElementAt((int)Skills.Hunter)));
      skills.Add(Skills.Contstruction, new Skill(skillData.ElementAt((int)Skills.Contstruction)));

      minigames.Add(Minigames.ClueScrollEasy, new Minigame(miniGameData.ElementAt((int)Minigames.ClueScrollEasy)));
      minigames.Add(Minigames.ClueScrollMedium, new Minigame(miniGameData.ElementAt((int)Minigames.ClueScrollMedium)));
      minigames.Add(Minigames.ClueScrollAll, new Minigame(miniGameData.ElementAt((int)Minigames.ClueScrollAll)));
      minigames.Add(Minigames.BountyHunterRogue, new Minigame(miniGameData.ElementAt((int)Minigames.BountyHunterRogue)));
      minigames.Add(Minigames.BountyHunter, new Minigame(miniGameData.ElementAt((int)Minigames.BountyHunter)));
      minigames.Add(Minigames.ClueScrollHard, new Minigame(miniGameData.ElementAt((int)Minigames.ClueScrollHard)));
      minigames.Add(Minigames.LastManStanding, new Minigame(miniGameData.ElementAt((int)Minigames.LastManStanding)));
      minigames.Add(Minigames.ClueScrollElite, new Minigame(miniGameData.ElementAt((int)Minigames.ClueScrollElite)));
      minigames.Add(Minigames.ClueScrollMaster, new Minigame(miniGameData.ElementAt((int)Minigames.ClueScrollMaster)));

    }

    public int GetGlobalRankOfSkill(Skills skillIndex) { return skills[skillIndex].GetRank; }
    public int GetLevelOfSkill(Skills skillIndex) { return skills[skillIndex].GetLevel; }
    public int GetExperienceOfSkill(Skills skillIndex) { return skills[skillIndex].GetExperience; }

  }
}