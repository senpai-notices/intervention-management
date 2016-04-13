<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add_New_Client.aspx.cs" Inherits="InterventionManagement.Web.WebForms.Add_New_Client" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <b>Name:</b> <asp:TextBox ID="txt_Name" runat="server"></asp:TextBox>
        <br />
        <b>District:</b>  <asp:DropDownList ID="dropList_District" runat="server"></asp:DropDownList>
        <br />
        <b>Location Description:</b> 
        <br />
        <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Height="150px" Width="500px"></asp:TextBox>
    </div>
        <div align="center">

            <asp:Button ID="btn_CreateClient" runat="server" Text="Create Client" OnClick="btn_CreateClient_Click" />
            <asp:Button ID="btn_Cancel" runat="server" Text="Cancel and Go Back" OnClick="btn_Cancel_Click"/>
        
        </div>
    </form>
</body>
</html>
