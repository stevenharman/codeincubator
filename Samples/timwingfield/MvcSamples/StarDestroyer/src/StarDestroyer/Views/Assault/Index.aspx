<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<AssaultShipIndexModel>" %>
<%@ Import Namespace="StarDestroyer.Models"%>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Assault Controller</h2>
    <p>This text is on index.aspx</p>
    
    <% 
        var partial1 = new PartialRequest(Model.PartialOne);
        partial1.Inoke(ViewContext);
    %>

</asp:Content>
