using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trivia
{
    internal class Players
    {
        private Player currentPlayer;
        private List<Player> Player { get; }

        public Players()
        {
            this.Player = new List<Player>();
        }

        public void AddPlayer(string name)
        {
            this.Player.Add(new Player(name));
            if (currentPlayer == null) NextPlayer();
        }
        
        public int Count()
        {
            return this.Player.Count;
        }

        public string CurrentPlayerName()
        {
            return currentPlayer.Name;
        }

        public void NextPlayer()
        {
            if (!DidPlayerWin())
            {
                currentPlayer = Player.IndexOf(currentPlayer) == Player.Count - 1
                    ? Player.FirstOrDefault()
                    : Player.ElementAt(Player.IndexOf(currentPlayer) + 1);
            }
        }

        public bool CurrentPlayerInPenaltyBox()
        {
            return currentPlayer.InPenaltyBox;
        }

        public void CurrentPlayerGoToPenaltyBox()
        {
            currentPlayer.InPenaltyBox = true;
        }

        public int CurrentPlayerPlace()
        {
            return currentPlayer.Places;
        }

        public void IncreaseCurrentPlayerPlace(int place)
        {
            currentPlayer.Places += place;
            if (currentPlayer.Places > 11) currentPlayer.Places -= 12;
        }

        public void CurrentPlayerAddPoint()
        {
            currentPlayer.Points++;
        }

        public int CurrentPlayerPoints()
        {
            return currentPlayer.Points;
        }

        public bool DidPlayerWin()
        {
            return currentPlayer is {Points: 6};
        }
        
    }
}
