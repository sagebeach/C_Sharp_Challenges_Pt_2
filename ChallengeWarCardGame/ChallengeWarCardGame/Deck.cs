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
            _deck = new List<Card>();
            /*
            _deck = new List<Card>()
            {
               new Card {Suit="Clubs", Rank="2"}, //... dont hard code that ish
            };
            */

            _deck = new List<Card>();
            _random = new Random();
            _sb = new StringBuilder();

            string[] suits = new string[] { "Clubs", "Diamonds", "Hearts", "Spades" };
            String[] ranks = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace"};

            foreach (var suit in suits)
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

        private void dealCard(Player player)
        {
            Card card = _deck.ElementAt(_random.Next(_deck.Count));
            player.Cards.Add(card);
            _deck.Remove(card);

            _sb.Append("<br/>");
            _sb.Append(player.Name);
            _sb.Append(" is dealt the ");
            _sb.Append(card.Rank);
            _sb.Append(" of ");
            _sb.Append(card.Suit);

        }
    }
}