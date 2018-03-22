using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeWarCardGame
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            //18:26 part 1
            
        }

        protected void warButton_Click(object sender, EventArgs e)
        {
            Game game = new Game("player1", "player2");
            resultLabel.Text = game.Play();
        }
    }
}