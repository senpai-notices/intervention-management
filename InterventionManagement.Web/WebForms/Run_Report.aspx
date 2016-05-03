<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Run_Report.aspx.cs" Inherits="au.edu.uts.ASDF.ENETCare.InterventionManagement.Web.WebForms.Run_Report" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div align="center">
        <asp:Label ID="lblTitle" runat="server" Text="My report" Font-Bold="True" Font-Size="XX-Large"></asp:Label>
    </div>


    <div style="margin-left: 20%; margin-top: 5%">
        <asp:Label ID="lblReportType" runat="server" Text="Report type: "></asp:Label>
        <asp:DropDownList ID="TypeDropDownList" runat="server">
            <asp:ListItem>Engineer</asp:ListItem>
            <asp:ListItem>District</asp:ListItem>
        </asp:DropDownList>

        <asp:Label ID="lblName" runat="server" Text="Select Name "></asp:Label>
        <asp:DropDownList ID="NameDropDownList" runat="server">
            <asp:ListItem>Sample district or engineer name</asp:ListItem>
            <asp:ListItem>Sample district or engineer name</asp:ListItem>
        </asp:DropDownList>

        <br />
        <br />
            <asp:Table ID="ReportTable" runat="server" GridLines="Both" Width="80%">
                <asp:TableRow runat="server" Font-Bold="True" Height="50px">
                    <asp:TableCell runat="server" BorderColor="Black" BorderStyle="Solid" Width="30%">Name</asp:TableCell>
                    <asp:TableCell runat="server" BorderColor="Black" BorderStyle="Solid" Width="20%">Average cost</asp:TableCell>
                    <asp:TableCell runat="server" BorderColor="Black" BorderStyle="Solid" Width="30%">Total cost</asp:TableCell>

                </asp:TableRow>
            </asp:Table>

        </div>
</asp:Content>
