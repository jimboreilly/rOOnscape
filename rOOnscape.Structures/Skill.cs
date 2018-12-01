using System;

namespace rOOnscape.Structures {
  public class Skill {
    private readonly int rank;
    private readonly int level;
    private readonly int exp;

    public Skill(int Rank, int Level, int Experience) {
      this.rank = Rank;
      this.level = Level;
      this.exp = Experience;
    }

    public int Rank => this.rank;
    public int Level => this.level;
    public int Experience => this.exp;

    public bool IsMax => this.level == 99;

  }

}