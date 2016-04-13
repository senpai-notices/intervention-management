<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Engineer_Clients.aspx.cs" Inherits="au.edu.uts.ASDF.ENETCare.InterventionManagement.Web.WebForms.Engineer_Clients" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
         <div align="center">
    
       <asp:ListBox ID="list_Clients" runat="server"></asp:ListBox>
  
        <br />
        <asp:Button ID="btn_ViewClient" runat="server" Text="View Client" OnClick="btn_ViewClient_Click" />
    
             <asp:Button ID="btn_NewClient" runat="server" Text="New Client" OnClick="btn_NewClient_Click"/>
    
    </div>

    </div>
    </form>
</body>
</html>
