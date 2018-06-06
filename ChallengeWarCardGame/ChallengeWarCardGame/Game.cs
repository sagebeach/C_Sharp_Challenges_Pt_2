using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChallengeWarCardGame
{
    public class Game
    {

        private Player _player1;
        private Player _player2;
        

        public Game(string player1Name, string player2Name)
        {
            _player1 = new Player() { Name = player1Name };
            _player2 = new Player() { Name = player2Name };

            
        }

        public string Play()
        {
            Deck deck = new Deck(); //instantiates the deck

            string result = "<h3>Dealing cards ...</h3>";
            result += deck.Deal(_player1, _player2);

            result += "<h3>Begin battle ...</h3>";
            int round = 0; //creates round total to tell when the deck is run through. needs to be redone if program is refactored to accomodate different win conditions.
            while (_player1.Hand.Count != 0 && _player2.Hand.Count != 0) //checks if there are cards left in a player's hand.
            {
                Battle battle = new Battle(); 
                result += battle.performBattle(_player1, _player2);

                round++;
                if (round > 26) // 52 card deck / 2 = 26 cards per hand(rounds)
                    break;
            }
            //determine the winner
            result += determineWinner();
            return result;
        }
       

       

        private string determineWinner() //formatted to display differently for endgame scoring
        {
            string result = "";
            if (_player1.Hand.Count > _player2.Hand.Count)
                result += "<br/><span style='color:red;font-weight:bolder;'>Player1 wins</span>";
            else
                result += "<br/><span style='color:blue;font-weight:bolder;'>Player2 wins</span>";

            result += "<br/><span style='color:red;font-weight:bolder;'>Player 1:" + _player1.Hand.Count + "</span> <br/><span style='color:red;font-weight:bolder;'> Player 2:" + _player2.Hand.Count + "</span>";
            return result;
        }
    }
}