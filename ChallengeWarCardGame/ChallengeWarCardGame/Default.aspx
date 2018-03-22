<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ChallengeWarCardGame.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="resultLabel" runat="server"></asp:Label>
        </div>
        <p>
            <asp:Button ID="warButton" runat="server" OnClick="warButton_Click" Text="War" />
        </p>
    </form>
</body>
</html>
