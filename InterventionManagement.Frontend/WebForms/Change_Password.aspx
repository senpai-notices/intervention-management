<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Change_Password.aspx.cs" Inherits="InterventionManagement.Frontend.WebForms.Change_Password" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label_NewPasswordExplanation" runat="server" Text="Enter your new password:"></asp:Label>
        <asp:TextBox ID="TextBox_NewPassword1" runat="server"></asp:TextBox>
    
    </div>
        <asp:Label ID="Label_ConfirmPasswordExplanation" runat="server" Text="Confirm your new password:"></asp:Label>
        <asp:TextBox ID="TextBox_NewPassword2" runat="server"></asp:TextBox>
        <p>
            <asp:Label ID="Label_ExistingPassword" runat="server" Text="Type your existing password to verify this change:"></asp:Label>
            <asp:TextBox ID="TextBox_ExistingPassword" runat="server"></asp:TextBox>
        </p>
    </form>
</body>
</html>
