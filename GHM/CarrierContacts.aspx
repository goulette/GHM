<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CarrierContacts.aspx.cs" Inherits="GHM.CarrierContacts" %>
<%@ Register TagPrefix="uc" TagName="ucGHM" Src="~/GHMUserControls.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <table style="text-align:center">
         <tr style="height: 50px">
             <td>
                <asp:Label ID="EditCarrierLabel" runat="server" Text="GHM Intranet - Carrier Contact Types" CssClass="myHeaderLabel" ></asp:Label>
             </td>
         </tr>
     </table>
     <table style="text-align:center">
         <uc:ucGHM id="CarrierHeader" runat="server" />
     </table>
    <asp:PlaceHolder ID="DBDataPlaceHolder" runat="server"></asp:PlaceHolder>
    <table style="text-align:center">
           <tr style="height: 60px">
                <td style="text-align:center" colspan="2">
                    <asp:Button ID="BackButton" runat="server" CssClass="myButton" Text="Back" OnClick="BackButton_Click"/>
                </td>
            </tr>
     </table>
</asp:Content>
