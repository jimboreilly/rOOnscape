using System.Linq;
using System.Collections.Generic;
using rOOnscape.Types;
using rOOnscape.Core.Extensions;
using System;

namespace rOOnscape {

  public class Player {

    public static readonly int TotalSkills = Enum.GetNames(typeof(SkillName)).Length;
    public static readonly int TotalMinigames = Enum.GetNames(typeof(MinigameName)).Length;

    private Dictionary<SkillName, Skill> skills = new Dictionary<SkillName, Skill>();
    private Dictionary<MinigameName, Minigame> minigames = new Dictionary<MinigameName, Minigame>();

    public Player(IEnumerable<string[]> skillData, IEnumerable<string[]> miniGameData) {
      foreach (var skillCount in 0.To(TotalSkills)) {
        var skillName = getEnumTypeFromIndex<SkillName>(skillCount);
        skills.Add(skillName, buildFromStringArray<Skill>(buildSkill, skillData.ElementAt(skillCount)));
      }

      foreach (var minigameCount in 0.To(TotalMinigames)) {
        var minigameName = getEnumTypeFromIndex<MinigameName>(minigameCount);
        minigames.Add(minigameName, buildFromStringArray<Minigame>(buildMinigame, miniGameData.ElementAt(minigameCount)));
      }
    }

    private T getEnumTypeFromIndex<T>(int index) {
      var nameOfType = Enum.GetName(typeof(T), index);
      return (T)Enum.Parse(typeof(T), nameOfType);
    }

    private Skill buildSkill(int[] inputData) {
      var Rank = inputData[0];
      var Level = inputData[1];
      var Exp = inputData[2];

      return new Skill(Rank, Level, Exp);
    }

    private Minigame buildMinigame(int[] inputData) {
      var Rank = inputData[0];
      var Score = inputData[1];

      return new Minigame(Rank, Score);
    }

    private T buildFromStringArray<T>(Func<int[], T> constructor, string[] data) {
      return constructor(data.ToIntArray());
    }

    public int GetGlobalRankOfSkill(SkillName s) => skills[s].GetRank;
    public int GetLevelOfSkill(SkillName s) => skills[s].GetLevel;
    public int GetExperienceOfSkill(SkillName s) => skills[s].GetExperience;

    public bool IsMaxSkill(SkillName s) => skills[s].IsMax;
    public Dictionary<SkillName, Skill> GetSkills => skills;

  }
}