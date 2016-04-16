<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Change_Password.aspx.cs" Inherits="InterventionManagement.Web.WebForms.Change_Password" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

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
        <asp:Button ID="Button_Save" runat="server" Text="Save" OnClick="Button_Save_OnClick" />
        <asp:Button ID="Button_Cancel" runat="server" Text="Cancel" OnClick="Button_Cancel_OnClick" />
</asp:Content>