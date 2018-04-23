using System;

namespace rOOnscape {
  public class Skill {
    private readonly int rank;
    private readonly int level;
    private readonly int exp;

    public Skill(string[] values) {
      this.rank = Int32.Parse(values[0]);
      this.level = Int32.Parse(values[1]);
      this.exp = Int32.Parse(values[2]);
    }

    public int GetRank => this.rank;
    public int GetLevel => this.level;
    public int GetExperience => this.exp;
  }

}