<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UsefulSite.aspx.cs" Inherits="GHM.UsefulSite" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <body>
        <table align="center">
            <tr style="height: 50px">
                <td>
                    <asp:Label ID="EditCarrierLabel" runat="server" Text="Useful Site Credentials" CssClass="myHeaderLabel" ></asp:Label>
                </td>
            </tr>
        </table>
        <table align="center">
            <tr style="height: 40px">
                <td colspan="2">
                </td>
            </tr>
            <tr>
                <td style="text-align:right">
                    <asp:Label ID="CredentialUserNameLabel" runat="server" CSSClass="myTextBoxLabel" Text="User Name:"></asp:Label>
                </td>
                <td style="text-align:left">
                    <asp:Label ID="CredentialUserNameData" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align:right">
                    <asp:Label ID="CredentialPasswordLabel" runat="server" CSSClass="myTextBoxLabel" Text="Password:"></asp:Label>
                </td>
                <td style="text-align:left">
                    <asp:Label ID="CredentialPasswordData" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr style="height: 60px">
                <td style="text-align:right">
                    <asp:Label ID="Label1" runat="server" CSSClass="myTextBoxLabel" Text="Site:"></asp:Label>
                </td>
                <td style="text-align:left">
                    <asp:HyperLink ID="UsefulSiteLink" target="_blank" runat="server"></asp:HyperLink>
                </td>
            </tr>
            <tr style="height: 60px">
                <td align="center" colspan="2">
                    <asp:Button ID="BackButton" runat="server" CssClass="myButton" PostBackUrl="~/Default.aspx" Text="Back" />
                </td>
            </tr>
        </table>
    </body>
</asp:Content>
