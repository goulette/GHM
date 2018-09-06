<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditCarrierWebsites.aspx.cs" Inherits="GHM.EditCarrierWebsites" %>
<%@ Register TagPrefix="uc" TagName="ucGHM" Src="~/GHMUserControls.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <body style:"width=100%;">
        <table style="text-align:center">
            <tr style="height: 50px">
                <td>
                    <asp:Label ID="EditCarrierWebsiteLabel" runat="server" Text="GHM Intranet Administration - Edit Carrier Websites" CssClass="myHeaderLabel" ></asp:Label>
                </td>
            </tr>
        </table>
        <table style="text-align:right">
            <uc:ucGHM id="CarrierHeader" runat="server" />
            <tr style="height: 60px">
                <td>
                </td>
                <td>
                    <asp:DropDownList ID="WebsiteDropDownList" runat="server" OnSelectedIndexChanged="WebsiteDropDownList_SelectedIndexChanged" AppendDataBoundItems="true" DataSourceID="SqlDataSource1" DataTextField="WebsiteDescription" DataValueField="Id" Width="400px" AutoPostBack="True">
                        <asp:ListItem Value="0" Text="Add New Website..." Selected="True"></asp:ListItem>
                    </asp:DropDownList><br />
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:GHMConnectionString %>" SelectCommand="SELECT * FROM [Website] WHERE ([CarrierID] = @CarrierID) ORDER BY [WebsiteDescription]">
                        <SelectParameters>
                            <asp:QueryStringParameter Name="CarrierID" QueryStringField="id" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
            </tr>
            <tr style="height: 20px">
                <td style="text-align:right">
                    <asp:Label ID="DescriptionLabel" CSSClass="myTextBoxLabel" runat="server" Text="Description: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="DescriptionTextBox" runat="server" Width="400px"></asp:TextBox><br />
                </td>
            </tr>
            <tr style="height: 20px">
                <td style="text-align:right">
                    <asp:Label ID="WebsiteURLLabel" CSSClass="myTextBoxLabel" runat="server" Text="Website URL: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="WebsiteTextBox" runat="server" Width="400px"></asp:TextBox><br />
                </td>
            </tr>
            <tr style="height: 20px">
                <td style="text-align:center" colspan="2">
                    <asp:Label ID="ErrorMsg" runat="server" CssClass="myErrorMsg"></asp:Label>
                </td>
            <tr style="height: 60px">
                <td style="text-align:center" colspan="2">
                    <asp:Button ID="SaveButton" runat="server" CssClass="myButton" Text="Save" OnClick="SaveButton_Click"/>
                    <asp:Button ID="CancelButton" runat="server" CssClass="myButton" OnClick="CancelButton_Click" Text="Cancel" />
                </td>
            </tr>
        </table>
    </body>
</asp:Content>
