using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeDartsSimple
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Game game = new Game("Player1", "Player2"); //calls the game method of the game class to assign player names
            string result = game.Play(); //plays an instance of the game

            gameLabel.Text = result; //prints game results

        }
    }
}