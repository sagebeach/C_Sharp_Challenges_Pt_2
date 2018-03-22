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
        calculateShipping();
    }

    protected void formChange(object sender, EventArgs e)
    {
        calculateShipping();
    }


    //method for calculating price
    /* //this code is erroneous because the event handlers won't take the optional input for lengthTextBox if the box lacks input. I might go back and try to refactor using this method to see if I can get it to work.
    
    protected void nextDayRadioButton_CheckedChanged(object sender, EventArgs e)
    {
        if (lengthTextBox.Text.Trim().Length >= 0)
        {
            calculateShipping(.45, double.Parse(widthTextBox.Text), double.Parse(heightTextBox.Text), double.Parse(lengthTextBox.Text));
        }
        else calculateShipping(.45, double.Parse(widthTextBox.Text), double.Parse(heightTextBox.Text));
    }
    //the above method is how I was attempting to call the method below. kept returning errors.
    private void calculateShipping(double shippingRadioMultiplier, double packageWidth, double packageHeight, double packageLength = 0)
    {
        if (widthTextBox.Text.Trim().Length == 0) return;
        else if (heightTextBox.Text.Trim().Length == 0) return;
        //else if (lengthTextBox.Text.Trim().Length == 0) return;
    
        double packageDimension = 0.0;
        if (!Double.TryParse(widthTextBox.Text, out packageDimension)) return;
        else if (!Double.TryParse(heightTextBox.Text, out packageDimension)) return;
        else if (!Double.TryParse(lengthTextBox.Text, out packageDimension)) return;

        double shippingCost = shippingRadioMultiplier * packageWidth * packageHeight;

        if (packageLength > 0) shippingCost =  shippingCost * packageLength;

        resultLabel.Text = shippingCost.ToString();
    }
    */ //I refactored this code below.

    private void calculateShipping() //I want to use shipping modifier as a method parameter but if this method is called when the textboxes change there is no modifier to specify.
    {
        if (!checkForInput()) return; //checks to make sure required input is provided before starting calculations.

        double packageVolume = 0.0;
        if (!tryGetVolume(out packageVolume)) return; //gets packageVolume

        double shippingMultiplier = getShippingMultiplier();

        double packageCost = packageVolume * shippingMultiplier; //shipping multiplier is specified by the radio buttons.

        resultLabel.Text = String.Format("The shipping cost for your package will be {0:C}.", packageCost);
    }

    private bool checkForInput()
    {
        if (!airRadioButton.Checked && !groundRadioButton.Checked && !nextDayRadioButton.Checked) return false;

        if (widthTextBox.Text.Trim().Length == 0) return false;
        else if (heightTextBox.Text.Trim().Length == 0) return false;

        return true;
    }

    private bool tryGetVolume(out double packageVolume)
    {
        packageVolume = 0.0;
        double width = 0;
        double height = 0;
        double length = 0;

        if (!double.TryParse(widthTextBox.Text.Trim(), out width)) return false;
        if (!double.TryParse(heightTextBox.Text.Trim(), out height)) return false;
        if (!double.TryParse(lengthTextBox.Text.Trim(), out length)) length = 1;

        packageVolume = width * height * length;
        return true;
    }

    private double getShippingMultiplier()
    {
        if (groundRadioButton.Checked) return .15;
        else if (airRadioButton.Checked) return .25;
        else if (nextDayRadioButton.Checked) return .45;
        else return 0;
    }
}