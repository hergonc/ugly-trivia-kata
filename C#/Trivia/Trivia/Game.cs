using System;
using System.Collections.Generic;
using System.Linq;

namespace Trivia
{
    public class Game
    {
        private bool isGettingOutOfPenaltyBox;

        private readonly Questions questions;
        private readonly Categories categories;
        private readonly Players players;

        public Game()
        {
            categories = new Categories();
            questions = new Questions(categories.Names);
            players = new Players();
        }

        public void AddPlayer(string name)
        {
            players.AddPlayer(name);
            Console.WriteLine(name + " was added");
            Console.WriteLine("They are player number " + players.Count());
        }

        public void Roll(int roll)
        {
            players.NextPlayer();
            Console.WriteLine(players.CurrentPlayerName() + " is the current player");
            Console.WriteLine("They have rolled a " + roll);

            if (players.CurrentPlayerInPenaltyBox())
            {
                if (roll % 2 == 0)
                {
                    Console.WriteLine(players.CurrentPlayerName() + " is not getting out of the penalty box");
                    isGettingOutOfPenaltyBox = false;
                    return;
                }
                isGettingOutOfPenaltyBox = true;
                Console.WriteLine(players.CurrentPlayerName() + " is getting out of the penalty box");
            }
            players.IncreaseCurrentPlayerPlace(roll);
            Console.WriteLine(players.CurrentPlayerName()
                              + "'s new location is "
                              + players.CurrentPlayerPlace());
            Console.WriteLine("The category is " + categories.CurrentCategory(players.CurrentPlayerPlace()));
            questions.NextQuestion(categories.CurrentCategory(players.CurrentPlayerPlace()));
        }

        public void CorrectAnswer()
        {
            if (players.CurrentPlayerInPenaltyBox() && !isGettingOutOfPenaltyBox)
            {
                return;
            }
            Console.WriteLine("Answer was correct!!!!");
            players.CurrentPlayerAddPoint();
            Console.WriteLine(players.CurrentPlayerName()
                              + " now has "
                              + players.CurrentPlayerPoints()
                              + " Gold Coins.");
        }

        public void WrongAnswer()
        {
            Console.WriteLine("Question was incorrectly answered");
            Console.WriteLine(players.CurrentPlayerName() + " was sent to the penalty box");
            players.CurrentPlayerGoToPenaltyBox();
        }

        public bool DidPlayerWin()
        {
            return players.DidPlayerWin();
        }
    }
}
