<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Engineer_Clients.aspx.cs" Inherits="au.edu.uts.ASDF.ENETCare.InterventionManagement.Web.WebForms.Engineer_Clients" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <!--Page heading -->
        <div align="center">
            <asp:Label ID="lblTitle" runat="server" Text="My Clients" Font-Bold="True" Font-Size="XX-Large"></asp:Label>
        </div>
        <!--End page heading -->
        
         <div style="margin-left: 30%; margin-top: 5%">
             <asp:Label ID="Label_DistrictPrompt" runat="server" Text="District: "></asp:Label>
             <asp:Label ID="Label_District" runat="server" Text="null"></asp:Label>
            <br />
            <br />
        
        <div class="centerblock" style="width: 40%; margin-top: 0px;">
            <br />
        </div>
        <div class="centerblock">

            <asp:Button ID="btn_ViewClient" runat="server" Text="View Client" OnClick="btn_ViewClient_Click" />

            <asp:Button ID="selectedClient" runat="server" OnClick="selectedClient_Click" Text="View selected client" Width="156px" />

            <asp:Button ID="btn_NewClient" runat="server" Text="New Client" OnClick="btn_NewClient_Click" />

        </div>

    </div>
        </div>
    </div>
</asp:Content>
