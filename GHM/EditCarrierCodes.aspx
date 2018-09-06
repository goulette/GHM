<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditCarrierCodes.aspx.cs" Inherits="GHM.EditCarrierCodes" %>
<%@ Register TagPrefix="uc" TagName="ucGHM" Src="~/GHMUserControls.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <body style:"width=100%;">
        <table style="text-align:center">
            <tr style="height: 50px">
                <td>
                    <asp:Label ID="EditCarrierLabel" runat="server" Text="GHM Intranet Administration - Edit Carrier Codes" CssClass="myHeaderLabel" ></asp:Label>
                </td>
            </tr>
        </table>
        <table style="text-align:center">
           <uc:ucGHM id="CarrierHeader" runat="server" />
            <tr style="height: 60px">
                <td>
                </td>
                <td>
                    <asp:DropDownList ID="CarrierCodeDropDownList" runat="server" OnSelectedIndexChanged="CarrierCodeDropDownList_SelectedIndexChanged" AppendDataBoundItems="true" DataSourceID="SqlDataSource1" DataTextField="AgencyName" DataValueField="Id" Width="400px" AutoPostBack="True">
                        <asp:ListItem Value="0" Text="Add New Agency Code..." Selected="True"></asp:ListItem>
                    </asp:DropDownList><br />
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:GHMConnectionString %>" SelectCommand="spGetCarrierCodes" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:QueryStringParameter Name="CarrierID" QueryStringField="id" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
            </tr>
            <tr style="height: 20px">
                <td style="text-align:right">
                    <asp:Label ID="AgencyLabel" runat="server" Text="Agency: "></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="AgencyDropDownList" runat="server" DataSourceID="SqlDataSource2" DataTextField="AgencyName" DataValueField="Id" Width="400px" AutoPostBack="True"></asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:GHMConnectionString %>" SelectCommand="SELECT * FROM [Agencies]"></asp:SqlDataSource>
                </td>
            </tr>
            <tr style="height: 20px">
                <td style="text-align:right">
                    <asp:Label ID="CodeLabel" runat="server" Text="Code: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="CodeTextBox" runat="server" Width="400px"></asp:TextBox><br />
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
