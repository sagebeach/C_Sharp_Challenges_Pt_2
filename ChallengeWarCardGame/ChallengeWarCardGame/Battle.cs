using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace ChallengeWarCardGame
{
    public class Battle
    {

        private List<Card> _bounty; //used to store the cards used for each battle round.
        private StringBuilder _sb;

        public Battle()
        {
            _bounty = new List<Card>();
            _sb = new StringBuilder(); //could refactor with output class to handle results output for each method call rather than one string built in memory
        }

        public string performBattle(Player player1, Player player2) //called by Game: Play() calls internal method evaluating the cards drawn.
        {
            Card player1Card = getCard(player1);
            Card player2Card = getCard(player2);

            performEvaluation(player1, player2, player1Card, player2Card);
            return _sb.ToString();
        }
        private Card getCard(Player player)
        {
            Card card = player.Hand.ElementAt(0);
            player.Hand.Remove(card);
            _bounty.Add(card);
            return card;
        }

        private void performEvaluation(Player player1, Player player2, Card card1, Card card2) //determines which card wins or, in the case of a draw, calls the war scenario.
        {
            displayBattleCards(card1, card2);
            if (card1.CardValue() == card2.CardValue())
                war(player1, player2);
            if (card1.CardValue() > card2.CardValue())
                awardWinner(player1);
            else
                awardWinner(player2);
        }

        private void awardWinner(Player player) //called by performEvaluation() to ouput the result of the battle round to the sb for display.
        {
            if (_bounty.Count == 0) return;
            displayBountyCards();
            player.Hand.AddRange(_bounty);
            _bounty.Clear();

            _sb.Append("<br/><strong>");
            _sb.Append(player.Name);
            _sb.Append(" wins!</strong><br/>");
        }

        private void war(Player player1, Player player2) //handles battle logic for war condition.
        {
            _sb.Append("<br/>*****************WAR*****************");
            getCard(player1);
            Card warCard1 = getCard(player1);

            getCard(player2);
            Card warCard2 = getCard(player2);

            performEvaluation(player1, player2, warCard1, warCard2);
        }

        private void displayBattleCards(Card card1, Card card2)
        {
            _sb.Append("<br/>Battle Cards: ");
            _sb.Append(card1.Rank);
            _sb.Append(" of ");
            _sb.Append(card1.Suit);
            _sb.Append(" vs. ");
            _sb.Append(card2.Rank);
            _sb.Append(" of ");
            _sb.Append(card2.Suit);
        }

        private void displayBountyCards()
        {
            _sb.Append("<br/>Bounty ...");

            foreach (var card in _bounty)
            {
            _sb.Append("<br/>&nbsp;&nbsp;&nbsp;&nbsp;");
            _sb.Append(card.Rank);
            _sb.Append(" of ");
            _sb.Append(card.Suit);
            }

            
 
        }

    }
}