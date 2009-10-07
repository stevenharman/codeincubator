<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Product>" %>

<%@ Import Namespace="StarDestroyer.Controllers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Search
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Search</h2>
    <div id="Product">
        <span>Name: <%= Html.Encode(Model.Name) %></span> 
        <br />
        <span>Description:<%= Html.Encode(Model.Description) %></span>
    </div>
</asp:Content>
