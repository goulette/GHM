<%@ Page Title="GHM Intranet Administration - Edit Carrier" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditCarrier.aspx.cs" Inherits="GHM.EditCarrier" %>
<%@ Register TagPrefix="uc" TagName="ucGHM" Src="~/GHMUserControls.ascx" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <body style:"width=100%;">
        <table align="center">
            <tr style="height: 50px">
                <td>
                    <asp:Label ID="EditCarrierLabel" runat="server" Text="GHM Intranet Administration - Edit Carrier" CssClass="myHeaderLabel" ></asp:Label>
                </td>
            </tr>
        </table>
        <table align="center">
           <uc:ucGHM id="CarrierHeader" runat="server" />
           <tr style="height: 40px">
                <td style="text-align:center">
                    <asp:HyperLink ID="DetailsLink" runat="server" CssClass="myLink">Details</asp:HyperLink><br />
                    <asp:HyperLink ID="AddressLink" runat="server" CssClass="myLink">Addresses</asp:HyperLink><br />
                    <asp:HyperLink ID="PhoneLink" runat="server" CssClass="myLink">Phone Numbers</asp:HyperLink><br />
                    <asp:HyperLink ID="FaxLink" runat="server" CssClass="myLink">Fax Numbers</asp:HyperLink><br />
                    <asp:HyperLink ID="CodesLink" runat="server" CssClass="myLink">Agency Codes</asp:HyperLink><br />
                    <asp:HyperLink ID="ContactsLink" runat="server" CssClass="myLink">Contacts</asp:HyperLink><br />
                    <asp:HyperLink ID="WebsitesLink" runat="server" CssClass="myLink">Websites</asp:HyperLink><br />
                    <asp:HyperLink ID="DocumentsLink" runat="server" CssClass="myLink">Documents</asp:HyperLink>
                </td>
            </tr>
            <tr style="height: 60px">
                <td style="text-align:center">
                    <asp:Button ID="CancelButton" runat="server" CssClass="myButton" PostBackUrl="~/Admin.aspx" Text="Cancel" />
                </td>
            </tr>
        </table>
    </body>
</asp:Content>
