<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Image ID="imageReel1" runat="server" Height="150px" Width="150px" ImageUrl="~/Images/Strawberry.png" />
            <asp:Image ID="imageReel2" runat="server" Height="150px" Width="150px" ImageUrl="~/Images/Diamond.png" />
            <asp:Image ID="imageReel3" runat="server" Height="150px" Width="150px" ImageUrl="~/Images/Clover.png" />
            <br />
            <br />
            Your Bet: <asp:TextBox ID="userBetTextBox" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="leverButton" runat="server" OnClick="leverButton_Click" Text="Pull the Lever!" />
            <br />
            <br />
            <asp:Label ID="resultLabel" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Label ID="moneyLabel" runat="server"></asp:Label>
            <br />
            <br />
            1 Cherry - 2x Your Bet<br />
            2 Cherry - 3x Your Bet<br />
            3 Cherry - 4x Your Bet<br />
            3 7&#39;s - Jackpot! - 100x Your Bet<br />
            However... if there&#39;s even one BAR you win nothing</div>
    </form>
</body>
</html>
