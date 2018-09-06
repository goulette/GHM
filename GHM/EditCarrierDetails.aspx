<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditCarrierDetails.aspx.cs" Inherits="GHM.EditCarrierDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <table style="text-align:center">
            <tr style="height: 50px">
                <td>
                    <asp:Label ID="AddCarrierLabel" runat="server" Text="GHM Intranet Administration - Edit Carrier Details" CssClass="myHeaderLabel"></asp:Label>
                </td>
            </tr>
        </table>
         <table>
            <tr style="height: 40px">
                <td colspan="3">
                </td>
            </tr>
            <tr>
                <td style="text-align:right">
                    <asp:Label ID="Name" runat="server" CSSClass="myTextBoxLabel" Text="Name:"></asp:Label>
                </td>
                <td style="text-align:left" colspan="2">
                    <asp:TextBox ID="NameTextBox" runat="server" Width="400"></asp:TextBox>
                </td>
            </tr>
            <tr style="height: 20px">
                <td style="text-align:center" colspan="3">
                    <asp:Label ID="ErrorMsg" runat="server" CssClass="myErrorMsg"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align:right">
                    <asp:Label ID="Logo" runat="server" CSSClass="myTextBoxLabel" Text="Logo:"></asp:Label>
                </td>
                <td>
                    <asp:FileUpload ID="LogoFileUpload" runat="server" />
                </td>
                <td style="height: 100px">
                    <asp:Button ID="btnUpload" Text="Upload" runat="server" CssClass="myButton" OnClick="UploadFile" />
                    <asp:Image ID="LogoImage" runat="server" ImageAlign="Middle" />
                </td>
            </tr>
            <tr>
                <td style="text-align:right" style="height: 40px">
                    <asp:Label ID="LogoLabel" runat="server" CSSClass="myTextBoxLabel" Text="Logo File:"></asp:Label>
                </td>
                <td style="text-align:left" colspan="2">
                    <asp:TextBox ID="LogoTextBox" runat="server" Width="400" Enabled="False" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align:right" style="height: 40px">
                    <asp:Label ID="LogoURLLabel" runat="server" CSSClass="myTextBoxLabel" Text="Logo URL:"></asp:Label>
                </td>
                <td style="text-align:left" colspan="2">
                    <asp:TextBox ID="LogoURLTextBox" runat="server" Width="400"></asp:TextBox>
                </td>
            </tr>
            <tr style="height: 60px">
                <td style="text-align:center" colspan="3">
                    <asp:Button ID="SaveButton" runat="server" Text="Save" CssClass="myButton" onclick="SaveButton_Click" />
                    <asp:Button ID="CancelButton" runat="server" CssClass="myButton" PostBackUrl="~/Admin.aspx" Text="Cancel" />
                </td>
            </tr>
        </table>
</asp:Content>
