<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddCompanyName.aspx.cs" Inherits="GHM.AddCompanyName" %>
<%@ Register TagPrefix="uc" TagName="ucGHM" Src="~/GHMUserControls.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <body>
        <table align="center">
            <tr style="height: 50px">
                <td>
                    <asp:Label ID="AddCompanyNameLabel" runat="server" Text="GHM Intranet Administration - Add Company Name" CssClass="myHeaderLabel"></asp:Label>
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
                    <asp:Label ID="CompanyName" runat="server" CSSClass="myTextBoxLabel" Text="Company Name:"></asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox ID="CompanyNameTextBox" runat="server" Width="400"></asp:TextBox>
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
