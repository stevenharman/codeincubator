<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="MvcDemoApp.Views.Product.Products" %>
<%@ Import Namespace="MvcDemoApp.Controllers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
<h2>Products</h2>
<table cellpadding="4" cellspacing="0" border="1">
    <tr>
        <th>&nbsp;</th>
        <th>Product Name</th>
        <th>Color</th>
        <th>List Price</th>
    </tr>
    <% foreach (MvcDemoApp.Models.Product p in ViewData)
       { %>
    <tr>
        <td><%= Html.ActionLink("Edit", "Edit", new { id=p.ProductID } ) %></td>
        <td><%= p.Name %></td>
        <td><%= p.Color %></td>
        <td>$<%= p.ListPrice.ToString("###,###.#0") %></td>
    </tr>
    <% } %>
</table>
<br />
</asp:Content>
