using System;

namespace rOOnscape {
  public class Skill {
    private readonly int rank;
    private readonly int level;
    private readonly int exp;

    public Skill(int Rank, int Level, int Experience) {
      this.rank = Rank;
      this.level = Level;
      this.exp = Experience;
    }

    public int GetRank => this.rank;
    public int GetLevel => this.level;
    public int GetExperience => this.exp;

    public bool IsMax => this.level == 99;

  }

}