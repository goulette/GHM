<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CarrierInfo.aspx.cs" Inherits="GHM.CarrierInfo" %>
<%@ Register TagPrefix="uc" TagName="ucGHM" Src="~/GHMUserControls.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <table style="text-align:center">
         <tr style="height: 50px">
             <td>
                <asp:Label ID="EditCarrierLabel" runat="server" Text="GHM Intranet - Carrier Information" CssClass="myHeaderLabel" ></asp:Label>
             </td>
         </tr>
     </table>
     <table style="text-align:center">
         <uc:ucGHM id="CarrierHeader" runat="server" />
     </table>
     <asp:PlaceHolder ID="DBDataPlaceHolder" runat="server"></asp:PlaceHolder>
     <table style="text-align:center">
         <tr style="width: 90%">
             <td>
                 <asp:HyperLink ID = 'DocumentsLink' runat = 'server' CssClass = 'myLink'>Documents</asp:HyperLink>
             </td>
         </tr>
         <tr style="width: 90%">
             <td>
                 <asp:HyperLink ID = 'ContactsLink' runat = 'server' CssClass = 'myLink'>Contacts</asp:HyperLink>
             </td>
         </tr>
     </table>

</asp:Content>
