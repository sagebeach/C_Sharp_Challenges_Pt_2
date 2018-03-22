using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //display the reel values
            string[] imageReel = new string[] { randomizeImageResults(), randomizeImageResults(), randomizeImageResults() };
            setRandomizedImages(imageReel);
            ViewState.Add("PlayersMoney", 100);
            displayPlayersMoney();
        }
    }

    private void displayPlayersMoney()
    {
        moneyLabel.Text = String.Format("Player's MoneyL {0:C}", ViewState["PlayersMoney"]);
    }

    //apply random image to the reels on button click/
    //randomize one wheel
    //randomize all wheels
    //evaluate image result for the value result
    //value of cherries, bar, and jackpot
    // apply value result to money total
    //caluclate win/loss
    //make sure results persist to viewstate


    protected void leverButton_Click(object sender, EventArgs e)
    {
        int bet = 0;
        if (!int.TryParse(userBetTextBox.Text, out bet)) return;

        int winnings = pullEvent(bet);
        displayResult(bet, winnings);
        adjustPlayersMoney(bet, winnings);
        displayPlayersMoney();
    }

    private void adjustPlayersMoney(int bet, int winnings)
    {
        int playersMoney = int.Parse(ViewState["PlayersMoney"].ToString());
        playersMoney -= bet;
        playersMoney += winnings;
        ViewState["PlayersMoney"] = playersMoney;
    }

    private void displayResult(int bet, int winnings)
    {
        if (winnings > 0)
            resultLabel.Text = String.Format("You bet {0:C} and won {1:C}!", bet, winnings);
        else
            resultLabel.Text = String.Format("Sorry, you lost {0:C}. Better luck next time", bet);
    }

    private int pullEvent(int bet)
        {
            //string slotImage = randomizeImageResults();
            string[] imageReel = new string[] { randomizeImageResults(), randomizeImageResults(), randomizeImageResults() };
            setRandomizedImages(imageReel);

            int betMultiplier = evaluateSpin(imageReel);
            return bet * betMultiplier;
        }

            private int evaluateSpin(string[] imageReel)
            {
                if (isBar(imageReel)) return 0;
                if (isJackpot(imageReel)) return 100;
                int multiplier = 0;
                if (isWinner(imageReel, out multiplier)) return multiplier;
                return 0;
            }

                private bool isWinner(string[] imageReel, out int multiplier)
                {
                    multiplier = getMultiplier(imageReel);
                    if (multiplier > 0) return true;
                    return false;
                }

                    private int getMultiplier(string[] imageReel)
                    {
                        int cherryCount = getCherryCount(imageReel);
                        if (cherryCount == 1) return 2;
                        if (cherryCount == 2) return 3;
                        if (cherryCount == 3) return 4;
                        return 0;
                    }

                    private int getCherryCount(string[] imageReel)
                    {
                        int cherryCount = 0;
                        if (imageReel[0] == "Cherry") cherryCount++;
                        if (imageReel[1] == "Cherry") cherryCount++;
                        if (imageReel[2] == "Cherry") cherryCount++;
                        return cherryCount;
                    }

                private bool isJackpot(string[] imageReel)
                {
        if (imageReel[0] == "Seven" && imageReel[1] == "Seven" && imageReel[2] == "Seven")
                        return true; //Jackpot!
                    else return false; //No luck
                }

                private bool isBar(string[] imageReel)
                {
                    if (imageReel[0] == "Bar" || imageReel[1] == "Bar" || imageReel[2] == "Bar")
                        return true;
                    else return false;

                }

    private void setRandomizedImages(string[] imageReel)
    {
       
        imageReel1.ImageUrl = "/Images/" + imageReel[0] + ".png";
        imageReel2.ImageUrl = "/Images/" + imageReel[1] + ".png";
        imageReel3.ImageUrl = "/Images/" + imageReel[2] + ".png";
    }

        Random random = new Random();
    private string randomizeImageResults()
    {
        string[] slotImages = new string[] { "Bar", "Bell", "Cherry", "Clover", "Diamond", "Horseshoe", "Lemon", "Orange", "Plum", "Seven", "Strawberry", "Watermellon" };
        return slotImages[random.Next(11)];
    }
/*
   private string setReelImage()
    {
       imageReel1.ImageUrl = "/images/" + randomizeImageResults() + ".png";
    } */
}