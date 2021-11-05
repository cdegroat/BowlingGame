namespace BowlingGame
{
    public abstract class Game
    {
        public int[] rolls { get; set; }
        private int currentRoll = 0;               

        public void Roll(int pins)
        {
            rolls[currentRoll++] = pins;
        }
    }   
}
