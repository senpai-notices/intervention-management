﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Add_New_Intervention.aspx.cs" Inherits="au.edu.uts.ASDF.ENETCare.InterventionManagement.Web.WebForms.Add_New_Intervention" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div>
        <!--Page heading -->
        <div align="center">
            <asp:Label ID="lblTitle" runat="server" Text="Add new Intervention" Font-Bold="True" Font-Size="XX-Large"></asp:Label>
        </div>
        <!--End page heading -->

        <!--Start client details -->
        <div style="margin-left: 30%; margin-top: 5%">
            <table style="width: 60%; line-height: 150%;">
                <colgroup>
                    <col style="width: 30%" />
                    <col style="width: 70%" />
                </colgroup>
                <tr>
                    <td>
                        <asp:Label ID="lblIntervention" runat="server" Text="Intervention type: " Font-Bold="True"></asp:Label>
                    </td>
                    <td>
                       <asp:DropDownList ID="DropDownListIntervention" runat="server"></asp:DropDownList>
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="lblType" runat="server" Text="Note: " Font-Bold="True"></asp:Label>
                    </td>
                    <td>
                        <!--<asp:DropDownList ID="DropDownListType" runat="server"></asp:DropDownList>-->
                        <!-- Removed the following: OnSelectedIndexChanged="DropDownListType_SelectedIndexChanged" -->
                        <asp:TextBox ID="txtNote" runat="server" Width="500px"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="lblCost" runat="server" Text="Cost: " Font-Bold="True"></asp:Label>
                    </td>
                    <td class="auto-style1">
                        <asp:TextBox ID="txtCost" runat="server"></asp:TextBox>
                    </td>

                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblHours" runat="server" Text="Hours: " Font-Bold="True"></asp:Label>
                    </td>
                    <td class="auto-style1">
                        <asp:TextBox ID="txtHours" runat="server"></asp:TextBox>
                    </td>
                </tr>

                 <tr>
                    <td>
                        <asp:Label ID="lblRemaining" runat="server" Text="Remaining Life: " Font-Bold="True"></asp:Label>
                    </td>
                    <td class="auto-style1">
                        <asp:TextBox ID="txtRemaining" runat="server">100</asp:TextBox>
                    </td>
                </tr>

                 <tr>
                    <td>
                        <asp:Label ID="lblDate" runat="server" Text="Date performed: " Font-Bold="True"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
                    </td>
                </tr>

                 <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>

                <tr>
                    <td>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="lblStatus" runat="server" Text="Status: " Font-Bold="True"></asp:Label>
                    </td>
                    <td>
                       <asp:DropDownList ID="DropDownListStatus" runat="server"></asp:DropDownList>
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="lblClient" runat="server" Text="Client: " Font-Bold="True"></asp:Label>
                    </td>
                    <td class="auto-style1">
                       <asp:DropDownList ID="DropDownListClient" runat="server"></asp:DropDownList>
                    </td>
                </tr>
            </table>
            <br />
            <br />
            <asp:Button ID="btnAdd" runat="server" Text="Add Intervention" OnClick="btnAdd_Click" />
        </div>
        <!-- End client details -->

    








    </div>




    </div>
</asp:content>