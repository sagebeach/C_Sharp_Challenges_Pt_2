<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ChallengeDartsSimple.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="gameLabel" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Button ID="playButton" runat="server" BorderStyle="None" OnClick="Button1_Click" Text="Play" />
        </div>
    </form>
</body>
</html>
