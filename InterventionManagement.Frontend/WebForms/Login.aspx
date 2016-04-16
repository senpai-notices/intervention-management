<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="au.edu.uts.ASDF.ENETCare.InterventionManagement.Web.WebForms.Login" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div style="margin-top: 5%;" align="center">
        <asp:Label ID="Label3" runat="server" Text="ENET Care" Font-Bold="True" Font-Size="X-Large"></asp:Label>
    </div>
    <div style="margin-top: 5%;" align="center">
        <asp:Label ID="Label1" runat="server" Text="Login ID: "></asp:Label>
        <asp:TextBox ID="txt_loginID" runat="server" OnTextChanged="txt_loginID_TextChanged"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Password: "></asp:Label>
        <asp:TextBox ID="txt_loginPW" runat="server" TextMode="Password" OnTextChanged="txt_loginPW_TextChanged"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btn_Cancel" />
        <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btn_Login" />
    </div>
</asp:Content>
