<%@ Page Title="GHM Intranet Administration" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="GHM.Admin" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <table style="text-align:center; width: 100%">
            <tr style="height: 50px">
                <td>
                    <asp:Label ID="AdminLabel" runat="server" Text="GHM Intranet Administration" CssClass="myHeaderLabel"></asp:Label>
                </td>
            </tr>
        </table>
        <table align="center">
             <tr style="height: 20px;">
                 <td colspan=2 style="text-align: left">
                     <asp:Label ID="CarrierLabel" runat="server" CssClass="myBlackHeaderLabel" Text="Carriers:"></asp:Label>
                 </td>
             </tr>
             <tr>
                 <td>
                    <asp:DropDownList ID="CarriersDropDownList" runat="server" CssClass="dropdownmaster" Width="300px" DataSourceID="DS_Carriers" DataTextField="CarrierName" DataValueField="Id">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="DS_Carriers" runat="server" ConnectionString="<%$ ConnectionStrings:GHMConnectionString %>" SelectCommand="SELECT [Id], [CarrierName] FROM [Carriers] ORDER BY [CarrierName]"></asp:SqlDataSource>
                 </td>
                 <td>
                    <asp:Button ID="EditButton" runat="server" Text="Change" CssClass="myButton" OnClick="EditButton_Click" />
                    <asp:Button ID="AddButton" runat="server" Text="Add New" CssClass="myButton" PostBackUrl="~/AddCarrier.aspx"/>
                 </td>
             </tr>
             <tr colspan=2 style="height: 20px">
                <td>
                </td>
             </tr>
             <tr colspan=2 style="height: 20px">
                 <td style="text-align: left">
                     <asp:Label ID="UsefulSitesLabel" runat="server" CssClass="myBlackHeaderLabel" Text="Useful Sites:"></asp:Label>
                 </td>
             </tr>
             <tr>
                 <td>
                    <asp:DropDownList ID="UsefulSitesDropDownList" runat="server" CssClass="dropdownmaster" Width="300px" DataSourceID="DS_UsefulSites" DataTextField="UsefulSiteDescription" DataValueField="Id">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="DS_UsefulSites" runat="server" ConnectionString="<%$ ConnectionStrings:GHMConnectionString %>" SelectCommand="SELECT * FROM [UsefulSites] ORDER BY [UsefulSiteDescription]"></asp:SqlDataSource>
                 </td>
                 <td>
                    <asp:Button ID="EditUsefulSiteButton" runat="server" Text="Change" CssClass="myButton" OnClick="EditUsefulSiteButton_Click" />
                    <asp:Button ID="AddUsefulSiteButton" runat="server" Text="Add New" CssClass="myButton" PostBackUrl="~/AddUsefulSite.aspx"/>
                    <asp:Button ID="DeleteUsefulSiteButton" runat="server" Text="Delete" CssClass="myDeleteButton" OnClick="DeleteUsefulSiteButton_Click"/>
                 </td>
             </tr>
             <tr colspan=2 style="height: 20px">
                <td>
                </td>
             </tr>
             <tr colspan=2 style="height: 20px">
                 <td style="text-align: left">
                     <asp:Label ID="ContactTypesLabel" runat="server" CssClass="myBlackHeaderLabel" Text="Contact Types:"></asp:Label>
                 </td>
             </tr>
             <tr>
                 <td>
                    <asp:DropDownList ID="ContactTypeDropDownList" runat="server" CssClass="dropdownmaster" Width="300px" DataSourceID="DS_ContactTypes" DataTextField="ContactTypeDescription" DataValueField="Id">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="DS_ContactTypes" runat="server" ConnectionString="<%$ ConnectionStrings:GHMConnectionString %>" SelectCommand="SELECT * FROM [ContactTypes] ORDER BY [ContactTypeDescription]"></asp:SqlDataSource>
                 </td>
                 <td>
                    <asp:Button ID="EditContactType" runat="server" Text="Change" CssClass="myButton" OnClick="EditContactType_Click"/>
                    <asp:Button ID="AddContactType" runat="server" Text="Add New" CssClass="myButton" PostBackUrl="~/AddContactType.aspx"/>
                 </td>
             </tr>
             <tr colspan=2 style="height: 20px">
                <td>
                </td>
             </tr>
             <tr colspan=2 style="height: 20px">
                 <td style="text-align: left">
                     <asp:Label ID="Label1" runat="server" CssClass="myBlackHeaderLabel" Text="Company Name for Agency Codes:"></asp:Label>
                 </td>
             </tr>
             <tr>
                 <td>
                    <asp:DropDownList ID="CompanyNameDropDownList" runat="server" CssClass="dropdownmaster" Width="300px" DataSourceID="DS_CompanyNames" DataTextField="AgencyName" DataValueField="Id">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="DS_CompanyNames" runat="server" ConnectionString="<%$ ConnectionStrings:GHMConnectionString %>" SelectCommand="SELECT * FROM [Agencies] ORDER BY [AgencyName]"></asp:SqlDataSource>
                 </td>
                 <td>
                    <asp:Button ID="EditCompanyButton" runat="server" Text="Change" CssClass="myButton" OnClick="EditCompanyButton_Click" />
                    <asp:Button ID="AddCompanyButton" runat="server" Text="Add New" CssClass="myButton" PostBackUrl="~/AddCompanyName.aspx"/>
                 </td>
             </tr>
        </table>
</asp:Content>
