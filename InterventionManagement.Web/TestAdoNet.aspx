<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestAdoNet.aspx.cs" Inherits="au.edu.uts.ASDF.ENETCare.InterventionManagement.Web.TestAdoNet" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="Employee Id:"></asp:Label>
    
        <asp:TextBox ID="TextboxUserId" runat="server"></asp:TextBox>
    
        <asp:LinkButton ID="LinkButtonGetUser" runat="server" OnClick="LinkButtonGetUser_Click">Go</asp:LinkButton>
        <br />
        <table class="auto-style1">
            <tr>
                <td>Username:</td>
                <td>
                    <asp:TextBox ID="TextboxUsername" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Password:</td>
                <td>
                    <asp:TextBox ID="TextBoxPassword" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Name:</td>
                <td>
                    <asp:TextBox ID="TextBoxName" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
