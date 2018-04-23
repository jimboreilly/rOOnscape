using System;

namespace rOOnscape {
  public class Minigame {
    private readonly int rank;
    private readonly int score;

    public Minigame(string[] values) {
      this.rank = Int32.Parse(values[0]);
      this.score = Int32.Parse(values[1]);
    }

    public int GetRank => this.rank;
    public int GetScore => this.score;
  }

}