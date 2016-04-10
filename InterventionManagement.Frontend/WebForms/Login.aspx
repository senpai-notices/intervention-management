<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="InterventionManagement.Frontend.WebForms.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form_Login" runat="server" defaultbutton ="btnLogin">
    
    <div align="center">

    </div>    
    <div align="center">
        <asp:Label ID="Label1" runat="server" Text="Login ID"></asp:Label>
        <asp:TextBox ID="txt_loginID" runat="server" OnTextChanged="txt_loginID_TextChanged"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
        <asp:TextBox ID="txt_loginPW" runat="server" TextMode="Password" OnTextChanged="txt_loginPW_TextChanged"></asp:TextBox>
        <br />
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btn_Cancel" />
        <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btn_Login" />
    </div>
    </form>
</body>
</html>
