<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditCarrierDocuments.aspx.cs" Inherits="GHM.EditCarrierDocuments" %>
<%@ Register TagPrefix="uc" TagName="ucGHM" Src="~/GHMUserControls.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <body style:"width=100%;">
        <table style="text-align:center">
            <tr style="height: 50px">
                <td>
                    <asp:Label ID="EditCarrierLabel" runat="server" Text="GHM Intranet Administration - Edit Carrier Documents" CssClass="myHeaderLabel" ></asp:Label>
                </td>
            </tr>
        </table>
         <table style="text-align:center">
            <uc:ucGHM id="CarrierHeader" runat="server" />
            <tr style="height: 20px">
                <td>
                      <asp:TreeView ID="DocumentTreeView" runat="server">
                          <RootNodeStyle ImageUrl="~/Images/folder.ico" />
                      </asp:TreeView>
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
