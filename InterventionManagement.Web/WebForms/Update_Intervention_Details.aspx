<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Update_Intervention_Details.aspx.cs" Inherits="au.edu.uts.ASDF.ENETCare.InterventionManagement.Web.WebForms.Update_Intervention_Details" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


     <div>
        <!--Page heading -->
        <div align="center">
            <asp:Label ID="lblTitle" runat="server" Text="Update Intervention" Font-Bold="True" Font-Size="XX-Large"></asp:Label>
        </div>
        <!--End page heading -->

         <!-- Start intervention details-->
         <div style="margin-left: 30%; margin-top: 5%">
            <table style="width: 60%; line-height: 150%;">
                <colgroup>
                    <col style="width: 15%" />
                    <col style="width: 85%" />
                </colgroup>

                <tr>
                    <td>
                        <asp:Label ID="lblInterventionType" runat="server" Text="Type: " Font-Bold="True"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblType" runat="server" Text=""></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="lblInterventionCost" runat="server" Text="Cost: " Font-Bold="True"></asp:Label>
                    </td>
                    <td class="auto-style1">
                        <asp:Label ID="lblCost" runat="server" Text=""></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="lblStatus" runat="server" Text="Status: " Font-Bold="True"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownListStatus" runat="server"></asp:DropDownList>
                    </td>
                </tr>
            </table>
             <br />
             <br />
            <asp:Button ID="btnUpdate" runat="server" Text="Update" />
        </div>
         <!-- End intervention details -->


         

     </div>








</asp:content>
