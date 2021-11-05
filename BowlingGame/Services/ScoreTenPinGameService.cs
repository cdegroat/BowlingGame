using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGame.Services
{
    public class ScoreTenPinGameService : IScoreGameService
    {
        private const int TotalNumberPinsForFrame = 10;
        public const int NumberFrames = 10;

        public int ScoreGame(Game game)
        {
            int[] rolls = game.rolls;
            int score = 0;
            int i = 0;

            for (int frame = 0; frame < NumberFrames; frame++)
            {
                if (IsStrike(rolls[i]))
                {
                    score = CalculateStrike(score, rolls, i);
                    i++;
                }
                else
                {
                    score = CalculateSpare(score, rolls, i);
                    i = i + 2;
                }
            }

            return score;
        }

        private bool IsStrike(int rollValue)
        {
            return rollValue == TotalNumberPinsForFrame;
        }

        private int CalculateStrike(int score, int[] rolls, int i)
        {
            score += TotalNumberPinsForFrame + rolls[i + 1] + rolls[i + 2];
            return score;
        }

        private int CalculateSpare(int score, int[] rolls, int i)
        {
            if (rolls[i] + rolls[i + 1] == TotalNumberPinsForFrame)
            {
                score += TotalNumberPinsForFrame + rolls[i + 2];
            }
            else
            {
                score += rolls[i] + rolls[i + 1];
            }
            return score;
        }
    }
}
