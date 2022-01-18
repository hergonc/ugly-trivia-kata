using System;
using System.Collections.Generic;
using System.Text;

namespace Trivia
{
    public class Player
    {
        public string Name { get; set; }
        public int Places { get; set; }
        public int Points { get; set; }
        public bool InPenaltyBox { get; set; }

        public Player(string name)
        {
            this.Name = name;
            this.Places = 0;
            this.Points = 0;
            this.InPenaltyBox = false;
        }
    }
}
