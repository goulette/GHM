<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditCarrierAddress.aspx.cs" Inherits="GHM.EditCarrierAddress" %>
<%@ Register TagPrefix="uc" TagName="ucGHM" Src="~/GHMUserControls.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <body style:"width=100%;">
        <table style="text-align:center">
            <tr style="height: 50px">
                <td>
                    <asp:Label ID="EditCarrierLabel" runat="server" Text="GHM Intranet Administration - Edit Carrier Addresses" CssClass="myHeaderLabel" ></asp:Label>
                </td>
            </tr>
        </table>
         <table style="text-align:center">
            <uc:ucGHM id="CarrierHeader" runat="server" />
            <tr style="height: 60px">
                <td>
                </td>
                <td>
                    <asp:DropDownList ID="AddressDropDownList" runat="server" OnSelectedIndexChanged="AddressDropDownList_SelectedIndexChanged" AppendDataBoundItems="true" DataSourceID="SqlDataSource1" DataTextField="AddressDescription" DataValueField="Id" Width="400px" AutoPostBack="True">
                        <asp:ListItem Value="0" Text="Add New Address..." Selected="True"></asp:ListItem>
                    </asp:DropDownList><br />
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:GHMConnectionString %>" SelectCommand="SELECT [AddressDescription], [Id] FROM [Address] WHERE ([CarrierID] = @CarrierID) ORDER BY [AddressDescription]">
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
                    <asp:TextBox ID="DescriptionTextBox" runat="server" Width="400px"></asp:TextBox><br />
                </td>
            </tr>
            <tr style="height: 20px">
                <td  style="text-align:right">
                    <asp:Label ID="Address1Label" runat="server" Text="Address 1: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="Address1TextBox" runat="server" Width="400px"></asp:TextBox><br />
                </td>
            </tr>
            <tr style="height: 20px">
                <td  style="text-align:right">
                    <asp:Label ID="Address2Label" runat="server" Text="Address 2: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="Address2TextBox" runat="server" Width="400px"></asp:TextBox><br />
                </td>
            </tr>
            <tr style="height: 20px">
                <td  style="text-align:right">
                    <asp:Label ID="Address3Label" runat="server" Text="Address 3: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="Address3TextBox" runat="server" Width="400px"></asp:TextBox><br />
                </td>
            </tr>
            <tr style="height: 20px">
                <td  style="text-align:right">
                    <asp:Label ID="CountryLabel" runat="server" Text="Country: "></asp:Label>
                </td>
                <td style="text-align:left">
                    <asp:DropDownList ID="CountryDropDownList" runat="server" OnSelectedIndexChanged="CountryDropDownList_SelectedIndexChanged" DataSourceID="SqlDataSource2" DataTextField="Name" DataValueField="Id" AutoPostBack="True"></asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:GHMConnectionString %>" SelectCommand="SELECT * FROM [Country]"></asp:SqlDataSource>
                </td>
            </tr>
             <tr style="height: 20px">
                <td style="text-align:right">
                    <asp:Label ID="CityLabel" runat="server" Text="City: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="CityTextBox" runat="server" Width="400px"></asp:TextBox><br />
                </td>
            </tr>
            <tr style="height: 20px">
                <td style="text-align:right">
                    <asp:Label ID="StateLabel" runat="server" Text="State: "></asp:Label>
                </td>
                <td style="text-align:left">
                    <asp:DropDownList ID="StateDropDownList" runat="server"></asp:DropDownList>
                </td>
            </tr>
             <tr style="height: 20px">
                <td style="text-align:right">
                    <asp:Label ID="ZipLabel" runat="server" Text="Zip: "></asp:Label>
                </td>
                <td style="text-align:left">
                    <asp:TextBox ID="ZipTextBox" runat="server" Width="200px"></asp:TextBox><br />
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
