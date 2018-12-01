using System.Linq;
using System.Collections.Generic;
using rOOnscape.Structures.Types;
using rOOnscape.Core.Extensions;
using System;

namespace rOOnscape.Structures {

  public class Player {

    private readonly Dictionary<SkillName, Skill> skills = new Dictionary<SkillName, Skill>();
    private readonly Dictionary<MinigameName, Minigame> minigames = new Dictionary<MinigameName, Minigame>();

    public Player(IEnumerable<string[]> skillData, IEnumerable<string[]> miniGameData) {
      this.skills = 0.To(TotalSkills - 1)
        .ToDictionary(index => getEnumTypeFromIndex<SkillName>(index),
                      index => buildFromStringArray<Skill>(buildSkill, skillData.ElementAt(index)));

      this.minigames = 0.To(TotalMinigames - 1)
        .ToDictionary(index => getEnumTypeFromIndex<MinigameName>(index),
                      index => buildFromStringArray<Minigame>(buildMinigame, miniGameData.ElementAt(index)));
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

    public static readonly int TotalSkills = Enum.GetNames(typeof(SkillName)).Length;
    public static readonly int TotalMinigames = Enum.GetNames(typeof(MinigameName)).Length;

    public int GetGlobalRankOfSkill(SkillName s) => skills[s].Rank;
    public int GetLevelOfSkill(SkillName s) => skills[s].Level;
    public int GetExperienceOfSkill(SkillName s) => skills[s].Experience;
    public int TotalLevel() => skills.Sum(x => x.Value.Level);

    public bool IsMaxSkill(SkillName s) => skills[s].IsMax;
    public List<string> GetMaxSkills() => skills.Where(skill => skill.Value.IsMax).Select(x => Enum.GetName(typeof(SkillName), (int)x.Key)).ToList();
    public Dictionary<SkillName, Skill> GetSkills => skills;

  }
}