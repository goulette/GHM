<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditUsefulSite.aspx.cs" Inherits="GHM.EditUsefulSite" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
         <table align="center">
            <tr style="height: 50px">
                <td>
                    <asp:Label ID="EditUsefulSiteLabel" runat="server" Text="GHM Intranet Administration - Edit Useful Site" CssClass="myHeaderLabel"></asp:Label>
                </td>
            </tr>
        </table>
         <table align="center">
            <tr style="height: 40px">
                <td colspan="2">
                </td>
            </tr>
            <tr style="height: 20px">
                <td align="right">
                    <asp:Label ID="DescriptionLabel" CSSClass="myTextBoxLabel" runat="server" Text="Description: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="DescriptionTextBox" runat="server" Width="400px"></asp:TextBox><br />
                </td>
            </tr>
            <tr style="height: 20px">
                <td align="right">
                    <asp:Label ID="UsefulSiteLabel" CSSClass="myTextBoxLabel" runat="server" Text="Useful Site URL: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="UsefulSiteTextBox" runat="server" Width="400px"></asp:TextBox><br />
                </td>
            </tr>
            <tr style="height: 40px">
                <td> </td>
                <td align="left">
                    <asp:CheckBox ID="UsefulSiteCredentialsCheckBox" runat="server" OnCheckedChanged="UsefulSiteCredentialsCheckBox_CheckedChanged" AutoPostBack="true" Text="&nbsp;Use Credentials" />
                </td>
            </tr>
            <tr style="height: 20px">
                <td align="right">
                    <asp:Label ID="UsefulSiteUsernameLabel" CSSClass="myTextBoxLabel" runat="server" Text="Username: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="UsefulSiteUsernameTextBox" runat="server" Width="400px" Enabled="False"></asp:TextBox><br />
                </td>
            </tr>
            <tr style="height: 20px">
                <td align="right">
                    <asp:Label ID="UsefulSitePasswordLabel" CSSClass="myTextBoxLabel" runat="server" Text="Password: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="UsefulSitePasswordTextBox" runat="server" Width="400px" Enabled="False"></asp:TextBox><br />
                </td>
            </tr>
            <tr style="height: 60px">
                <td align="center" colspan="2">
                    <asp:Button ID="SaveButton" runat="server" CssClass="myButton" Text="Save" OnClick="SaveButton_Click"/>
                    <asp:Button ID="CancelButton" runat="server" CssClass="myButton" PostBackUrl="~/Admin.aspx" Text="Cancel" />
                </td>
            </tr>
        </table>
</asp:Content>
