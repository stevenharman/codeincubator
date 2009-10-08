<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Product>" %>

<%@ Import Namespace="StarDestroyer.Controllers" %>
<%@ Import Namespace="MvcContrib" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Search
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Products</h2>
    <div id="SuggestedProducts">
        <h3>
            Suggested Products</h3>
        <%
            foreach (var product in ViewData.Get<List<Product>>())
            { %>
        <span class="Name">
            <%= Html.Encode(product.Name) %>
        </span>
        <br />
        <span>
            <%= Html.Encode(product.Description) %>
        </span>
        <br />
        <br />
        <%
            } 
        %>
    </div>
    <div id="SearchResults">
        <div class="productAttribute">
            <span>Name: </span>
            <br />
            <span>
                <%= Html.Encode(Model.Name) %>
            </span>
        </div>
        <div class="productAttribute">
            <span>Description:</span><br />
            <span>
                <%= Html.Encode(Model.Description) %>
            </span>
        </div>
    </div>
</asp:Content>
