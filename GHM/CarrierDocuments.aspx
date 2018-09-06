<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CarrierDocuments.aspx.cs" Inherits="GHM.CarrierDocuments" %>
<%@ Register TagPrefix="uc" TagName="ucGHM" Src="~/GHMUserControls.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <body style:"width=100%;">
        <table style="text-align:center">
           <uc:ucGHM id="CarrierHeader" runat="server" />
           <tr style="height: 50px">
                <td>
                    <asp:Label ID="CarrierDocumentsLabel" runat="server" Text="Carrier Documents" CssClass="myHeaderLabel" ></asp:Label>
                </td>
            </tr>
            <tr style="height: 20px">
                <td>
                      <asp:TreeView ID="DocumentTreeView" runat="server" OnSelectedNodeChanged="DocumentTreeView_SelectedNodeChanged">
                          <RootNodeStyle ImageUrl="~/Images/folder.ico" />
                      </asp:TreeView>
                </td>
            </tr>
           <tr style="height: 60px">
                <td style="text-align:center">
                    <asp:Button ID="BackButton" runat="server" CssClass="myButton" OnClick="BackButton_Click" Text="Back" />
                </td>
            </tr>
        </table>
    </body>
</asp:Content>
