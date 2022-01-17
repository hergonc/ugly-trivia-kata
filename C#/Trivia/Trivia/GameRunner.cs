using System;

namespace Trivia
{
    public class GameRunner
    {
        private static bool notAWinner;

        public static void Main(string[] args)
        {
            PlayGame(new Random());
        }

        public static void PlayGame(Random rand)
        {
            var aGame = new Game();

            aGame.AddPlayer("Chet");
            aGame.AddPlayer("Pat");
            aGame.AddPlayer("Sue");

            do
            {
                aGame.Roll(rand.Next(5) + 1);

                if (rand.Next(9) == 7)
                    notAWinner = aGame.WrongAnswer();
                else
                    notAWinner = aGame.WasCorrectlyAnswered();
            } while (notAWinner);
        }
    }
}