<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Add_new_Intervention.aspx.cs" Inherits="au.edu.uts.ASDF.ENETCare.InterventionManagement.Web.WebForms.Add_new_Intervention" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div>
        <!--Page heading -->
        <div align="center">
            <asp:Label ID="Label1" runat="server" Text="Add new Intervention" Font-Bold="True" Font-Size="XX-Large"></asp:Label>
        </div>
        <!--End page heading -->

        <!--Start client details -->
        <div style="margin-left: 30%; margin-top: 5%">
            <table style="width: 60%; line-height: 150%;">
                <colgroup>
                    <col style="width: 15%" />
                    <col style="width: 85%" />
                </colgroup>

                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Type: " Font-Bold="True"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownListType" runat="server"></asp:DropDownList>
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="Cost: " Font-Bold="True"></asp:Label>
                    </td>
                    <td class="auto-style1">
                        <asp:TextBox ID="txtCost" runat="server"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="Status: " Font-Bold="True"></asp:Label>
                    </td>
                    <td>
                       <asp:DropDownList ID="DropDownListStatus" runat="server"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Client: " Font-Bold="True"></asp:Label>
                    </td>
                    <td class="auto-style1">
                       <asp:DropDownList ID="DropDownListClient" runat="server"></asp:DropDownList>
                    </td>
                </tr>
            </table>
            <br />
            <br />
            <asp:Button ID="btnAdd" runat="server" Text="Add Intervention" />
        </div>
        <!-- End client details -->

    








    </div>




</asp:content>
