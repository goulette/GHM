<%@ Page Title="GHM Intranet Administration - Add Carrier Contact" Language="C#" AutoEventWireup="true" CodeBehind="AddCarrierContact.aspx.cs" Inherits="GHM.AddCarrierContact" MasterPageFile="Site.Master" %>
<%@ Register TagPrefix="uc" TagName="ucGHM" Src="~/GHMUserControls.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <body>
        <table align="center">
            <tr style="height: 50px">
                <td>
                    <asp:Label ID="AddCarrierContactLabel" runat="server" Text="GHM Intranet Administration - Add Carrier Contact" CssClass="myHeaderLabel"></asp:Label>
                </td>
            </tr>
        </table>
         <table style="text-align:center">
           <uc:ucGHM id="CarrierHeader" runat="server" />
             <tr>
                 <td>
                    <asp:DropDownList ID="CarrierContactTypeDropDownList" runat="server" CssClass="dropdownmaster" Width="300px" DataSourceID="DS_ContactTypes" DataTextField="ContactTypeDescription" DataValueField="Id">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="DS_ContactTypes" runat="server" ConnectionString="<%$ ConnectionStrings:GHMConnectionString %>" SelectCommand="SELECT * FROM [ContactTypes] ORDER BY [ContactTypeDescription]"></asp:SqlDataSource>
                 </td>
             </tr>
           <tr style="height: 60px">
                <td style="text-align:center">
                    <asp:Button ID="SaveButton" runat="server" CssClass="myButton" Text="Save" OnClick="SaveButton_Click"/>
                    <asp:Button ID="CancelButton" runat="server" CssClass="myButton" OnClick="CancelButton_Click" Text="Cancel" />
                </td>
            </tr>
        </table>
    </body>
</asp:Content>
