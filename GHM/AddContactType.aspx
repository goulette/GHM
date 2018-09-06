<%@ Page Title="Add Contact Type" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddContactType.aspx.cs" Inherits="GHM.AddContactType" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <body>
        <table align="center">
            <tr style="height: 50px">
                <td>
                    <asp:Label ID="AddContactTypeLabel" runat="server" Text="GHM Intranet Administration - Add Contact Type" CssClass="myHeaderLabel"></asp:Label>
                </td>
            </tr>
        </table>
         <table align="center">
            <tr style="height: 40px">
                <td colspan="2">
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="ContactType" runat="server" CSSClass="myTextBoxLabel" Text="Contact Type:"></asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox ID="ContactTypeTextBox" runat="server" Width="400"></asp:TextBox>
                </td>
            </tr>
            <tr style="height: 20px">
                <td align="center" colspan="3">
                    <asp:Label ID="ErrorMsg" runat="server" CssClass="myErrorMsg"></asp:Label>
                </td>
            </tr>
           <tr style="height: 100px">
                <td align="center" colspan="2">
                    <asp:Button ID="AddButton" runat="server" CssClass="myButton" Text="Save" OnClick="AddButton_Click"/>
                    <asp:Button ID="CancelButton" runat="server" CssClass="myButton" PostBackUrl="~/Admin.aspx" Text="Cancel" />
                </td>
            </tr>
        </table>
    </body>
</asp:Content>
