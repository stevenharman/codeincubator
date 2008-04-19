<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="MvcDemoApp.Views.Product.Products" %>
<%@ Import Namespace="MvcDemoApp.Controllers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
<h2>Products</h2>
<table cellpadding="4" cellspacing="0" border="1">
    <tr>
        <th>&nbsp;</th>
        <th>Product Name</th>
        <th>Units in Stock</th>
        <th>List Price</th>
    </tr>
    <% foreach (var p in ViewData)
       { %>
    <tr>
        <td><%= Html.ActionLink("Edit", "Edit", new { id=p.ProductID } ) %></td>
        <td><%= p.ProductName %></td>
        <td><%= p.UnitsInStock %></td>
        <td>$<%= p.UnitPrice %></td>
    </tr>
    <% } %>
</table>
<br />
<p>
    <%= Html.ActionLink<ProductController>(c => c.Categories(), "Show Category Listing") %>
</p>
</asp:Content>
