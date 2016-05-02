<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Accountant.aspx.cs" Inherits="au.edu.uts.ASDF.ENETCare.InterventionManagement.Web.WebForms.Accountant" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div align="center">
        <asp:Label ID="Label1" runat="server" Text="Accountant Dashboard" Font-Bold="True" Font-Size="XX-Large"></asp:Label>
    </div>


    <div style="margin-left: 20%; margin-top: 5%">
            <asp:Table ID="Table1" runat="server" GridLines="Both" Width="80%">
                <asp:TableRow runat="server" Font-Bold="True" Height="50px">
                    <asp:TableCell runat="server" BorderColor="Black" BorderStyle="Solid" Width="30%">Username</asp:TableCell>
                    <asp:TableCell runat="server" BorderColor="Black" BorderStyle="Solid" Width="20%">Type</asp:TableCell>
                    <asp:TableCell runat="server" BorderColor="Black" BorderStyle="Solid" Width="30%">District</asp:TableCell>
                    <asp:TableCell runat="server" BorderColor="Black" BorderStyle="Solid" Width="20%">Change</asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <br />
            <asp:Button ID="btnRunReport" runat="server" Text="Run report" />
            <asp:Button ID="btnSaveChange" runat="server" Text="Save change" />
        </div>
</asp:Content>
