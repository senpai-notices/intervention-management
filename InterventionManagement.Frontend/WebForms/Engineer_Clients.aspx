<%@ Page Language="C#" MasterPageFile="~/Site.Master"AutoEventWireup="true" CodeBehind="Engineer_Clients.aspx.cs" Inherits="au.edu.uts.ASDF.ENETCare.InterventionManagement.Web.WebForms.Engineer_Clients" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div>
    <div align="center">
        <asp:Label ID="Label1" runat="server" Text="List of clients" Font-Bold="True" Font-Size="XX-Large"></asp:Label>
    </div>
            <div class="centerblock" style ="width:40%;">
                            <asp:ListBox ID="list_Clients" runat="server" Width="100%"></asp:ListBox>
                </div>
       <div class ="centerblock">

        <asp:Button ID="btn_ViewClient" runat="server" Text="View Client" OnClick="btn_ViewClient_Click" />
    
             <asp:Button ID="btn_NewClient" runat="server" Text="New Client" OnClick="btn_NewClient_Click"/>
    
    </div>

    </div>
</asp:Content>
