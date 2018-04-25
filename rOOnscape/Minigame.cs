using System;

namespace rOOnscape {
  public class Minigame {
    private readonly int rank;
    private readonly int score;

    public Minigame(int Rank, int Score) {
      this.rank = Rank;
      this.score = Score;
    }

    public int GetRank => this.rank;
    public int GetScore => this.score;
  }

}