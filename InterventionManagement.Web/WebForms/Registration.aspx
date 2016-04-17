<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="au.edu.uts.ASDF.ENETCare.InterventionManagement.Web.WebForms.Registration" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <div style="margin-top: 5%;" align="center">
        <asp:Label ID="Label1" runat="server" Text="Register" Font-Bold="True" Font-Size="X-Large"></asp:Label>        
    </div>
    <div style="margin-top: 5%;" align="center">
        <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
    </div>
    <div style="margin-top: 5%;" align="center">
            
        <asp:Label ID="Label2" runat="server" Text="Username: "></asp:Label>
        <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
        <br /><br />
        <asp:Label ID="Label3" runat="server" Text="Password: "></asp:Label>
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
        <br /><br />
        <asp:Label ID="Label4" runat="server" Text="Confirm Password: "></asp:Label>
        <asp:TextBox ID="txtConfirm" runat="server" TextMode="Password"></asp:TextBox>
        <br /><br />
         <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" />
     </div>



</asp:Content>
