<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Engineer_Clients.aspx.cs" Inherits="au.edu.uts.ASDF.ENETCare.InterventionManagement.Web.WebForms.Engineer_Clients" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <!--Page heading -->
        <div align="center">
            <asp:Label ID="lblTitle" runat="server" Text="My Clients" Font-Bold="True" Font-Size="XX-Large"></asp:Label>
        </div>
        <!--End page heading -->
        
         <div style="margin-left: 30%; margin-top: 5%">
            <asp:DropDownList ID="DistrictDropDownList" runat="server" DataTextField="DistrictName" DataValueField="DistrictName" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
        
        <div class="centerblock" style="width: 40%; margin-top: 0px;">
            <asp:ListBox ID="list_Clients" runat="server" Width="100%" DataSourceID="ClientList" DataTextField="Name" DataValueField="Name"></asp:ListBox>
            <asp:SqlDataSource ID="ClientList" runat="server" ConnectionString="Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\R\Source\Repos\InterventionManagement\InterventionManagement.Data\Database.mdf;Integrated Security=True" ProviderName="System.Data.SqlClient" SelectCommand="SELECT [Name] FROM [Client] WHERE ([DistrictId] = @DistrictId)">
                <SelectParameters>
                    <asp:ControlParameter ControlID="DistrictDropDownList" Name="DistrictId" PropertyName="SelectedValue" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
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
