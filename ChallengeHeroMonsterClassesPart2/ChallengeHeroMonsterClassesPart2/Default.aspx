<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ChallengeHeroMonsterClassesPart2.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="battleLabel" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Label ID="resultLabel" runat="server"></asp:Label>
        </div>
        <p>
            <asp:Button ID="battleButton" runat="server" OnClick="battleButton_Click" Text="BATTLE!" />
        </p>
    </form>
</body>
</html>
