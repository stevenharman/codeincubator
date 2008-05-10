<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductTable.aspx.cs" Inherits="MvcDemoApp.Views.Product.ProductTable" %>
<%@ Import Namespace="MvcDemoApp.Controllers" %>
<h4>HTML Render View</h4>
<table width="400" cellpadding="4" cellspacing="0" border="1" style="background-color: Silver">
    <tr>
        <th>Name</th>
        <th>Units in Stock</th>
        <th>Price</th>
    </tr>
    <% foreach (var p in ViewData)
       {%>
        <tr>
            <td><%= p.ProductName %></td>
            <td><%= p.UnitsInStock %></td>
            <td><%= p.UnitPrice %></td>
        </tr>
    <% } %>
</table>
