using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengePhunWithStrings
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 1.  Reverse your name
            //string name = "Bob Tabor";
            //1.1 Array.Reverse Method
            //name = Reverse(name); //calls Array.Reverse method
            //resultLabel.Text = name;
            /*1.2 Manual Reversal //best practice uses StringBuilder to avoid excessive processing. 
            string nameReversed = "";
            for (int i = name.Length - 1; i >= 0; i--)
            {
                nameReversed += name[i];
            }
            resultLabel.Text = nameReversed; */

            /* 2.  Reverse this sequence:
            string names = "Luke,Leia,Han,Chewbacca";
            // When you're finished it should look like this:
            // Chewbacca,Han,Leia,Luke
            string[] namesArray = names.Split(',');
            string result = "";
            for (int i = namesArray.Length - 1; i >= 0; i--)
            {
                result += namesArray[i] + ",";
            }
            result = result.Remove(result.Length - 1, 1); // removes the comma at the end of the reversed array string
            resultLabel.Text = result;
            */


            /* 3. Use the sequence to create ascii art:
            // *****luke*****
            // *****leia*****
            // *****han******
            // **Chewbacca***
            string names = "Luke,Leia,Han,Chewbacca";
            string[] namesArray = names.Split(',');
            string result = "";
            for (int i = 0; i < namesArray.Length; i++)
            {
                int padLeft = (14 - namesArray[i].Length) / 2;
                string temp = namesArray[i].PadLeft(namesArray[i].Length + padLeft, '*');
                result += temp.PadRight(14, '*');
                result += "<br />";
            }
            resultLabel.Text = result;
            */



            // 4. Solve this puzzle:

            string puzzle = "NOW IS ZHEremove-me ZIME FOR ALL GOOD MEN ZO COME ZO ZHE AID OF ZHEIR COUNZRY.";

            // Once you fix it with string helper methods, it should read:
            // Now is the time for all good men to come to the aid of their country.
            string removeMe = "remove-me";
            int index = puzzle.IndexOf(removeMe);
            puzzle = puzzle.Remove(index, removeMe.Length);
            puzzle = puzzle.ToLower();
            puzzle = puzzle.First().ToString().ToUpper() + puzzle.Substring(1);
            puzzle = puzzle.Replace("z", "t");
            resultLabel.Text = puzzle;

     }
        /*1.1 Array.Reverse method
       public static string Reverse(string name)
        {
            char[] charArray = name.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        } */
        
    }
}