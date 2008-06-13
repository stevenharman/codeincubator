<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="MvcDemoApp.Views.Product.Categories" %>
<%@ Import Namespace="MvcDemoApp.Controllers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
<script src="../../Content/jquery-1.2.3.min.js" type="text/javascript"></script>
<h2>Products by Category</h2>
<ul id="categoryList">
    <% foreach (var cat in ViewData) { %>
        <li>
            <a href="javascript: jQueryAwesomeness(<%= cat.CategoryID %>)"><%= cat.CategoryName %></a>
        </li>
    <% } %>
</ul>
<div id="prodDetails"></div>
<script type="text/javascript">
    function jQueryAwesomeness(categoryId)
    {
        $.post("/Product/ProductsByCategory/" + categoryId, 
            function(results){
                $('#prodDetails').html(results);
            }
        );
    }
</script>
</asp:Content>
