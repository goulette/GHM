 <%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditContactType.aspx.cs" Inherits="GHM.EditContactType" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <table style="text-align:center">
            <tr style="height: 50px">
                <td>
                    <asp:Label ID="EditContactTypeLabel" runat="server" Text="GHM Intranet Administration - Edit Contact Type" CssClass="myHeaderLabel"></asp:Label>
                </td>
            </tr>
        </table>
         <table style="text-align:center">
            <tr style="height: 40px">
                <td colspan="2">
                </td>
            </tr>
            <tr>
                <td style="text-align:right">
                    <asp:Label ID="ContactType" runat="server" CSSClass="myTextBoxLabel" Text="Contact Type:"></asp:Label>
                </td>
                <td style="text-align:left">
                    <asp:TextBox ID="ContactTypeTextBox" runat="server" Width="400"></asp:TextBox>
                </td>
            </tr>
            <tr style="height: 20px">
                <td style="text-align:center" colspan="2">
                    <asp:Label ID="ErrorMsg" runat="server" CssClass="myErrorMsg"></asp:Label>
                </td>
            </tr>
           <tr style="height: 100px">
                <td style="text-align:center" colspan="2">
                    <asp:Button ID="UpdateButton" runat="server" CssClass="myButton" Text="Update" CausesValidation="False" OnClick="UpdateButton_Click"/>
                    <asp:Button ID="CancelButton" runat="server" CssClass="myButton" PostBackUrl="~/Admin.aspx" Text="Cancel" />
                </td>
            </tr>
        </table>
</asp:Content>
