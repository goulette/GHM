<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditCarrierPhone.aspx.cs" Inherits="GHM.EditCarrierPhone" %>
<%@ Register TagPrefix="uc" TagName="ucGHM" Src="~/GHMUserControls.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <body style:"width=100%;">
        <table style="text-align:center">
            <tr style="height: 50px">
                <td>
                    <asp:Label ID="EditCarrierLabel" runat="server" Text="GHM Intranet Administration - Edit Carrier Phone" CssClass="myHeaderLabel" ></asp:Label>
                </td>
            </tr>
        </table>
         <table style="text-align:center">
            <uc:ucGHM id="CarrierHeader" runat="server" />
            <tr style="height: 60px">
                <td>
                </td>
                <td>
                    <asp:DropDownList ID="PhoneDropDownList" runat="server" OnSelectedIndexChanged="PhoneDropDownList_SelectedIndexChanged" AppendDataBoundItems="true" DataSourceID="SqlDataSource1" DataTextField="PhoneDescription" DataValueField="Id" Width="400px" AutoPostBack="True">
                        <asp:ListItem Value="0" Text="Add New Phone..." Selected="True"></asp:ListItem>
                    </asp:DropDownList><br />
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:GHMConnectionString %>" SelectCommand="SELECT * FROM [Phone] WHERE ([CarrierID] = @CarrierID)">
                        <SelectParameters>
                            <asp:QueryStringParameter Name="CarrierID" QueryStringField="id" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
            </tr>
            <tr style="height: 20px">
                <td style="text-align:right">
                    <asp:Label ID="DescriptionLabel" runat="server" Text="Description: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="DescriptionTextBox" runat="server" Width="400px"></asp:TextBox>
                </td>
            </tr>
            <tr style="height: 20px">
                <td style="text-align:right">
                    <asp:Label ID="PhoneLabel" runat="server" Text="Phone: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="PhoneTextBox" runat="server" Width="400px"></asp:TextBox><br />
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
