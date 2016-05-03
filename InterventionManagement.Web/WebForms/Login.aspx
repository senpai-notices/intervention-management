<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="au.edu.uts.ASDF.ENETCare.InterventionManagement.Web.WebForms.Login" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div style="margin-top: 5%;" align="center">
        <asp:Label ID="lblTitle" runat="server" Text="ENET Care" Font-Bold="True" Font-Size="X-Large"></asp:Label>
        
    </div>
    <div style="margin-top: 5%;" align="center">
        <asp:Label ID="lblError" runat="server" Text="Label" Visible="False"></asp:Label>
    </div>
    <div style="margin-top: 5%;" align="center">
        <asp:Label ID="lblUsername" runat="server" Text="Login ID: "></asp:Label>
        <asp:TextBox ID="txt_loginID" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_loginID" ErrorMessage="  Username is required"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Label ID="lblPassword" runat="server" Text="Password: "></asp:Label>
        <asp:TextBox ID="txt_loginPW" runat="server" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_loginPW" ErrorMessage="  Password is required"></asp:RequiredFieldValidator>
        <br /><br />

        <asp:CheckBox ID="RememberMe" Text="Remember me?" runat="server" />

        <br /><br />
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btn_Cancel" />
        <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btn_Login" />
    </div>
</asp:Content>
