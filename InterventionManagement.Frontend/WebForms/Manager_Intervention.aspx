<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Manager_Intervention.aspx.cs" Inherits="InterventionManagement.Frontend.WebForms.Manager_Intervention" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

    
    <div align="center">
    
       <asp:ListBox ID="ListBox1" runat="server"></asp:ListBox>
  
        <br />
        <asp:Button ID="Button1" runat="server" Text="View Intervention" OnClick="ViewIntervention_Click" />
    
    </div>
    </form>
</body>
</html>
