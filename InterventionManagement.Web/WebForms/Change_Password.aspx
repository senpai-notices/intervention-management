<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Change_Password.aspx.cs" Inherits="au.edu.uts.ASDF.ENETCare.InterventionManagement.Web.WebForms.Change_Password" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div align="center">
            <asp:Label ID="lblTitle" runat="server" Text="Manage your account" Font-Bold="True" Font-Size="XX-Large"></asp:Label>
        </div>
    <div style="margin-left: 30%; margin-top: 5%">
    <div>
        <asp:Label ID="lblMessage" runat="server" Text="" Visible="False"></asp:Label>
        
    </div>
    <br />
    <div>
        <asp:Label ID="Label_NewPasswordExplanation" runat="server" Text="Enter your new password:"></asp:Label>
        <asp:TextBox ID="TextBox_NewPassword1" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <br />

    </div>
    <asp:Label ID="Label_ConfirmPasswordExplanation" runat="server" Text="Confirm your new password:"></asp:Label>
    <asp:TextBox ID="TextBox_NewPassword2" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <br />
    <p>
        <asp:Label ID="Label_ExistingPassword" runat="server" Text="Type your existing password to verify this change:"></asp:Label>
        <asp:TextBox ID="TextBox_ExistingPassword" runat="server" TextMode="Password"></asp:TextBox>
    </p>
        <p>
            &nbsp;</p>
    <asp:Button ID="Button_Save" runat="server" Text="Save" OnClick="Button_Save_OnClick" />
    <asp:Button ID="Button_Cancel" runat="server" Text="Cancel" OnClick="Button_Cancel_OnClick" />
        </div>
</asp:Content>
