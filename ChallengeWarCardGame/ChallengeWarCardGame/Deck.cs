using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace ChallengeWarCardGame
{
    public class Deck
    {
        private List<Card> _deck;
        private Random _random;
        private StringBuilder _sb;

        public Deck()
        {            
            _deck = new List<Card>(); //instantiates the list used to store the cards after randomization
            _random = new Random();
            _sb = new StringBuilder(); //could refactor with output class to handle results output for each method call rather than one string built in memory

            string[] suits = new string[] { "Clubs", "Diamonds", "Hearts", "Spades" };
            String[] ranks = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace"};

            foreach (var suit in suits) //since we know we are working with a predetermined set of cards (52) there is no risk using this nested loop. O(1). Would need refactoring if card count was variable O(n)
            {
                foreach (var rank in ranks)
                {
                    _deck.Add(new Card() { Suit = suit, Rank = rank });
                }
            }
        }

        public string Deal(Player player1, Player player2)
        {   
            while (_deck.Count > 0)
            {
                //deal a card to each player randomly
                dealCard(player1);
                dealCard(player2);
            }
            return _sb.ToString();
        }

        private void dealCard(Player player) //randomly grabs one card from the list of cards (_deck) and assigns it to the list (Cards) of the specific player passed in.
        {
            Card card = _deck.ElementAt(_random.Next(_deck.Count));
            player.Hand.Add(card);
            _deck.Remove(card);

            _sb.Append("<br/>"); //for testing purposes, each time the method is called this adds the current dealt card to the stringbuilder for display. Inefficient because this saves all output as one string rather than outputting results each call. 
            _sb.Append(player.Name);
            _sb.Append(" is dealt the ");
            _sb.Append(card.Rank);
            _sb.Append(" of ");
            _sb.Append(card.Suit);

        }
    }
}