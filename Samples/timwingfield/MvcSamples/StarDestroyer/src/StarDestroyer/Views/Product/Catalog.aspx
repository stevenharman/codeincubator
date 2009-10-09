<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<List<ProductListingModel>>" %>
<%@ Import Namespace="StarDestroyer.Models"%>
<%@ Import Namespace="StarDestroyer.Helpers.HTML"%>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	ProductCatalog
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Product Catalog</h2>
    
    <%= Html.Table("Products", Model, null) %>

</asp:Content>
