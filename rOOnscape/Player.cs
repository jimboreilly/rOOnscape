using System.Linq;
using System.Collections.Generic;
using rOOnscape.Types;
using System;

namespace rOOnscape {

  public class Player {

    public static readonly int TotalSkills = Enum.GetNames(typeof(SkillName)).Length;
    public static readonly int TotalMinigames = Enum.GetNames(typeof(MinigameName)).Length;

    private Dictionary<SkillName, Skill> skills = new Dictionary<SkillName, Skill>();
    private Dictionary<MinigameName, Minigame> minigames = new Dictionary<MinigameName, Minigame>();

    public Player(IEnumerable<string[]> skillData, IEnumerable<string[]> miniGameData) {
      skills.Add(SkillName.Attack, new Skill(skillData.ElementAt((int)SkillName.Attack)));
      skills.Add(SkillName.Defense, new Skill(skillData.ElementAt((int)SkillName.Defense)));
      skills.Add(SkillName.Strength, new Skill(skillData.ElementAt((int)SkillName.Strength)));
      skills.Add(SkillName.Hitpoints, new Skill(skillData.ElementAt((int)SkillName.Hitpoints)));
      skills.Add(SkillName.Ranged, new Skill(skillData.ElementAt((int)SkillName.Ranged)));
      skills.Add(SkillName.Prayer, new Skill(skillData.ElementAt((int)SkillName.Prayer)));
      skills.Add(SkillName.Magic, new Skill(skillData.ElementAt((int)SkillName.Magic)));
      skills.Add(SkillName.Cooking, new Skill(skillData.ElementAt((int)SkillName.Cooking)));
      skills.Add(SkillName.Woodcutting, new Skill(skillData.ElementAt((int)SkillName.Woodcutting)));
      skills.Add(SkillName.Fletching, new Skill(skillData.ElementAt((int)SkillName.Fletching)));
      skills.Add(SkillName.Fishing, new Skill(skillData.ElementAt((int)SkillName.Fishing)));
      skills.Add(SkillName.Firemaking, new Skill(skillData.ElementAt((int)SkillName.Firemaking)));
      skills.Add(SkillName.Crafting, new Skill(skillData.ElementAt((int)SkillName.Crafting)));
      skills.Add(SkillName.Smithing, new Skill(skillData.ElementAt((int)SkillName.Smithing)));
      skills.Add(SkillName.Mining, new Skill(skillData.ElementAt((int)SkillName.Mining)));
      skills.Add(SkillName.Herblore, new Skill(skillData.ElementAt((int)SkillName.Herblore)));
      skills.Add(SkillName.Agility, new Skill(skillData.ElementAt((int)SkillName.Agility)));
      skills.Add(SkillName.Theiving, new Skill(skillData.ElementAt((int)SkillName.Theiving)));
      skills.Add(SkillName.Slayer, new Skill(skillData.ElementAt((int)SkillName.Slayer)));
      skills.Add(SkillName.Farming, new Skill(skillData.ElementAt((int)SkillName.Farming)));
      skills.Add(SkillName.Runecrafting, new Skill(skillData.ElementAt((int)SkillName.Runecrafting)));
      skills.Add(SkillName.Hunter, new Skill(skillData.ElementAt((int)SkillName.Hunter)));
      skills.Add(SkillName.Contstruction, new Skill(skillData.ElementAt((int)SkillName.Contstruction)));

      minigames.Add(MinigameName.ClueScrollEasy, new Minigame(miniGameData.ElementAt((int)MinigameName.ClueScrollEasy)));
      minigames.Add(MinigameName.ClueScrollMedium, new Minigame(miniGameData.ElementAt((int)MinigameName.ClueScrollMedium)));
      minigames.Add(MinigameName.ClueScrollAll, new Minigame(miniGameData.ElementAt((int)MinigameName.ClueScrollAll)));
      minigames.Add(MinigameName.BountyHunterRogue, new Minigame(miniGameData.ElementAt((int)MinigameName.BountyHunterRogue)));
      minigames.Add(MinigameName.BountyHunter, new Minigame(miniGameData.ElementAt((int)MinigameName.BountyHunter)));
      minigames.Add(MinigameName.ClueScrollHard, new Minigame(miniGameData.ElementAt((int)MinigameName.ClueScrollHard)));
      minigames.Add(MinigameName.LastManStanding, new Minigame(miniGameData.ElementAt((int)MinigameName.LastManStanding)));
      minigames.Add(MinigameName.ClueScrollElite, new Minigame(miniGameData.ElementAt((int)MinigameName.ClueScrollElite)));
      minigames.Add(MinigameName.ClueScrollMaster, new Minigame(miniGameData.ElementAt((int)MinigameName.ClueScrollMaster)));
    }

    public int GetGlobalRankOfSkill(SkillName s) => skills[s].GetRank;
    public int GetLevelOfSkill(SkillName s) => skills[s].GetLevel;
    public int GetExperienceOfSkill(SkillName s) => skills[s].GetExperience;

    public bool IsMaxSkill(SkillName s) => skills[s].IsMax;
    public Dictionary<SkillName, Skill> GetSkills => skills;

  }
}