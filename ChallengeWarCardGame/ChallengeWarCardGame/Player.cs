using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChallengeWarCardGame
{
    public class Player //Acts as a container to store the hands of cards that are used in the battle class and to represent users
    {
        
        public string Name { get; set; }
        public List<Card> Hand { get; set; }

        public Player()
        {
            Hand = new List<Card>();
        }
    }
}