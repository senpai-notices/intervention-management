<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manager_Intervention.aspx.cs" Inherits="au.edu.uts.ASDF.ENETCare.InterventionManagement.Web.WebForms.Manager_Intervention" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div align="center">
        <asp:Label ID="lblTitle" runat="server" Text="Current Interventions" Font-Bold="True" Font-Size="XX-Large"></asp:Label>
    </div>

    <div style="margin-left: 20%; margin-top: 5%">
            <asp:Table ID="InterventionTable" runat="server" GridLines="Both" Width="80%">
                <asp:TableRow runat="server" Font-Bold="True" Height="50px">
                    <asp:TableCell runat="server" BorderColor="Black" BorderStyle="Solid" Width="30%">Interventions</asp:TableCell>
                    <asp:TableCell runat="server" BorderColor="Black" BorderStyle="Solid" Width="40%">Intervention Details</asp:TableCell>
                    <asp:TableCell runat="server" BorderColor="Black" BorderStyle="Solid" Width="30%">Update Intervention</asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <br />

     </div>






</asp:Content>
