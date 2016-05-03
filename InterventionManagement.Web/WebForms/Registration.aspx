<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="au.edu.uts.ASDF.ENETCare.InterventionManagement.Web.WebForms.Registration" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <div style="margin-top: 5%;" align="center">
        <asp:Label ID="lblTitle" runat="server" Text="Register" Font-Bold="True" Font-Size="X-Large"></asp:Label>        
    </div>
    <div style="margin-top: 5%;" align="center">
        <asp:Label ID="lblError" runat="server" Text="Label"></asp:Label>
        
    </div>
    <div style="margin-top: 5%;" align="center">
        <asp:Label ID="lblName" runat="server" Text="Name: "></asp:Label>
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        <br />
        <br />    
        <asp:Label ID="lblUsername" runat="server" Text="Username: "></asp:Label>
        <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
        <br /><br />
        <asp:Label ID="lblPassword" runat="server" Text="Password: "></asp:Label>
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
        <br /><br />
        <asp:Label ID="lblConfirmPassword" runat="server" Text="Confirm Password: "></asp:Label>
        <asp:TextBox ID="txtConfirm" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RegistrationDropDownBoxRolesConnection %>" SelectCommand="SELECT [Name] FROM [Roles]"></asp:SqlDataSource>
        <div>
        </div>
        <asp:Label ID="LabelRole" runat="server" Text="Role:"></asp:Label>
        <asp:DropDownList ID="DropDownList_Roles" runat="server" DataSourceID="SqlDataSource1" DataTextField="Name" DataValueField="Name">
        </asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="lblHours" runat="server" Text="Hour approval "></asp:Label>
        <asp:TextBox ID="txtHours" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblCost" runat="server" Text="Cost approval "></asp:Label>
        <asp:TextBox ID="txtCost" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblDistrict" runat="server" Text="District: "></asp:Label>
        <asp:DropDownList ID="DistrictDropDownList" runat="server"></asp:DropDownList>
        <br />
        <br />
         <div>
        </div>
         <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" />
     </div>



</asp:Content>
