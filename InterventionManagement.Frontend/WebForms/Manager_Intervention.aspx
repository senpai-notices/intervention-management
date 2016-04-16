<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manager_Intervention.aspx.cs" Inherits="au.edu.uts.ASDF.ENETCare.InterventionManagement.Web.WebForms.Manager_Intervention" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <div>
        <div align="center">

                     <table border="0">
                        <tr>
                            <td align="right"><b>Intervention Type:</b></td>
                            <td><asp:Label ID="lbl_InterventionType" runat="server" Text="Label"/></td>
                        </tr>
                        <tr>
                            <td align="right"><b>Client:</b></td>
                            <td><asp:Label ID="lbl_ClientName" runat="server" Text="Label"/></td>
                        </tr>
                        <tr>
                            <td align="right"><b>Labour:</b></td>
                            <td><asp:Label ID="lbl_Labour" runat="server" Text="Label"/></td>
                        </tr>
                        <tr>
                            <td align="right"><b>Cost:</b></td>
                            <td><asp:Label ID="lbl_Cost" runat="server" Text="Label"/></td>
                        </tr>
                        <tr>
                            <td align="right"><b>Engineer:</b></td>
                            <td><asp:Label ID="lbl_EngineerName" runat="server" Text="Label"/></td>
                        </tr>
                        <tr>
                            <td align="right"><b>Proposed Date:</b></td>
                            <td><asp:Label ID="lbl_Date" runat="server" Text="Label"/></td>
                        </tr>
                    </table>
    </div>
  
    <div align="center">
    
       <asp:ListBox ID="ListBox1" runat="server"></asp:ListBox>
  
        <br />
        <asp:Button ID="Button1" runat="server" Text="View Intervention" OnClick="ViewIntervention_Click" />
    
    </div>

</asp:Content>
