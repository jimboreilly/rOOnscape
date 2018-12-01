using System;

namespace rOOnscape.Structures {
  public class Minigame {
    private readonly int rank;
    private readonly int score;

    public Minigame(int Rank, int Score) {
      this.rank = Rank;
      this.score = Score;
    }

    public int Rank => this.rank;
    public int Score => this.score;
  }

}