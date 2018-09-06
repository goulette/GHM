<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditCarrierContacts.aspx.cs" Inherits="GHM.EditCarrierContacts" %>
<%@ Register TagPrefix="uc" TagName="ucGHM" Src="~/GHMUserControls.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <body style:"width=100%;">
        <table style="text-align:center">
            <tr style="height: 60px">
                <td>
                    <asp:Label ID="EditCarrierContactLabel" runat="server" Text="GHM Intranet Administration - Edit Carrier Contacts" CssClass="myHeaderLabel" ></asp:Label>
                </td>
            </tr>
        </table>
        <table style="text-align:center">
            <uc:ucGHM id="CarrierHeader" runat="server" />
            <tr>
                <td>
                </td>
                 <td>
                    <asp:DropDownList ID="CarrierContactTypeDropDownList" runat="server" CssClass="dropdownmaster" Width="300px" OnSelectedIndexChanged="CarrierContactTypeDropDownList_SelectedIndexChanged" DataSourceID="DS_ContactTypes" DataTextField="ContactTypeDescription" DataValueField="Id" AutoPostBack="true" OnDataBound="CarrierContactTypeDropDownList_DataBound">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="DS_ContactTypes" runat="server" ConnectionString="<%$ ConnectionStrings:GHMConnectionString %>" SelectCommand="SELECT * FROM [ContactTypes] ORDER BY [ContactTypeDescription]"></asp:SqlDataSource>
                 </td>
            </tr>
            <tr style="height: 20px">
                <td>
                </td>
                <td></td>
            </tr>             
            <tr>
                 <td>
                </td>
                <td>
                     <asp:DropDownList ID="CarrierContactList" runat="server" CssClass="dropdownmaster" Width="400px" OnSelectedIndexChanged="CarrierContactList_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                 </td>
             </tr>
            <tr style="height: 20px">
                <td style="text-align:right">
                    <asp:Label ID="ContactNameLabel" runat="server" Text="Contact Name: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="ContactNameTextBox" runat="server" Width="400px"></asp:TextBox><br />
                </td>
            </tr>
            <tr style="height: 20px">
                <td  style="text-align:right">
                    <asp:Label ID="ContactTitleLabel" runat="server" Text="Contact Title: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="ContactTitleTextBox" runat="server" Width="400px"></asp:TextBox><br />
                </td>
            </tr>
            <tr style="height: 20px">
                <td  style="text-align:right">
                    <asp:Label ID="ContactPhoneLabel" runat="server" Text="Contact Phone: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="ContactPhoneTextBox" runat="server" Width="400px"></asp:TextBox><br />
                </td>
            </tr>
            <tr style="height: 20px">
                <td  style="text-align:right">
                    <asp:Label ID="ContactFaxLabel" runat="server" Text="Contact Fax: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="ContactFaxTextBox" runat="server" Width="400px"></asp:TextBox><br />
                </td>
            </tr>
            <tr style="height: 20px">
                <td  style="text-align:right">
                    <asp:Label ID="ContactEmailLabel" runat="server" Text="Contact Email: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="ContactEmailTextBox" runat="server" Width="400px"></asp:TextBox><br />
                </td>
            </tr>
           <tr style="height: 20px">
                <td style="text-align:center" colspan="2">
                    <asp:Label ID="ErrorMsg" runat="server" CssClass="myErrorMsg"></asp:Label>
                </td>
            </tr>
           <tr style="height: 60px">
                <td style="text-align:center" colspan="2">
                    <asp:Button ID="SaveButton" runat="server" CssClass="myButton" Text="Save" OnClick="SaveButton_Click"/>
                    <asp:Button ID="CancelButton" runat="server" CssClass="myButton" OnClick="CancelButton_Click" Text="Cancel" />
                </td>
            </tr>
        </table>
    </body>
</asp:Content>
