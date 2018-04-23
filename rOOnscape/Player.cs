using System.Linq;
using System.Collections.Generic;

namespace rOOnscape {
  
  public class Player {

    private Dictionary<string, Skill> skills = new Dictionary<string, Skill>();
    private Dictionary<string, Minigame> minigames = new Dictionary<string, Minigame>();

    public Player(IEnumerable<string[]> skillData, IEnumerable<string[]> miniGameData) {
      // var overallOffset = 1; //first row is overall meta data
      // var scrollsOffset = 10; //last rows are clue scroll meta data
      // var totalskills = playerDataString.Count(); //size of input for Take

      // var justSkillLevels = playerDataString.Take(totalskills - scrollsOffset).Skip(overallOffset);

      skills.Add("attack", new Skill(skillData.ElementAt(0)));
      skills.Add("defense", new Skill(skillData.ElementAt(1)));
      skills.Add("strength", new Skill(skillData.ElementAt(2)));
      skills.Add("hitpoints", new Skill(skillData.ElementAt(3)));
      skills.Add("ranged", new Skill(skillData.ElementAt(4)));
      skills.Add("prayer", new Skill(skillData.ElementAt(5)));
      skills.Add("magic", new Skill(skillData.ElementAt(6)));
      skills.Add("cooking", new Skill(skillData.ElementAt(7)));
      skills.Add("woodcutting", new Skill(skillData.ElementAt(8)));
      skills.Add("fletching", new Skill(skillData.ElementAt(9)));
      skills.Add("fishing", new Skill(skillData.ElementAt(10)));
      skills.Add("firemaking", new Skill(skillData.ElementAt(11)));
      skills.Add("crafting", new Skill(skillData.ElementAt(12)));
      skills.Add("smithing", new Skill(skillData.ElementAt(13)));
      skills.Add("mining", new Skill(skillData.ElementAt(14)));
      skills.Add("herblore", new Skill(skillData.ElementAt(15)));
      skills.Add("agility", new Skill(skillData.ElementAt(16)));
      skills.Add("theiving", new Skill(skillData.ElementAt(17)));
      skills.Add("slayer", new Skill(skillData.ElementAt(18)));
      skills.Add("farming", new Skill(skillData.ElementAt(19)));
      skills.Add("runecraft", new Skill(skillData.ElementAt(20)));
      skills.Add("hunter", new Skill(skillData.ElementAt(21)));
      skills.Add("construction", new Skill(skillData.ElementAt(22)));

      minigames.Add("cluescrollseasy", new Minigame(miniGameData.ElementAt(0)));
      minigames.Add("cluescrollsmedium", new Minigame(miniGameData.ElementAt(1)));
      minigames.Add("cluescrollsall", new Minigame(miniGameData.ElementAt(2)));
      minigames.Add("bountyhunterrogue", new Minigame(miniGameData.ElementAt(3)));
      minigames.Add("bountyhunter", new Minigame(miniGameData.ElementAt(4)));
      minigames.Add("cluescrollshard", new Minigame(miniGameData.ElementAt(5)));
      minigames.Add("lastmanstandingrank", new Minigame(miniGameData.ElementAt(6)));
      minigames.Add("cluescrollselite", new Minigame(miniGameData.ElementAt(7)));
      minigames.Add("cluescrollsmaster", new Minigame(miniGameData.ElementAt(8)));
      
    }

    public int GetGlobalRankOfSkill(string skillName) { return skills[skillName].GetRank; }
    public int GetLevelOfSkill(string skillName) { return skills[skillName].GetLevel; }
    public int GetExperienceOfSkill(string skillName) { return skills[skillName].GetExperience; }

  }
}