<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="MvcDemoApp.Views.Product.Edit" %>
<%@ Import Namespace="MvcDemoApp.Controllers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
<h2>Edit <%= ViewData.ProductName %></h2>
<% using (Html.Form<ProductController>(p => p.Update(ViewData.ProductID))) { %>
<ul style="list-style-type: none;">
    <li>Units In Stock: <%= Html.TextBox("Product.UnitsInStock", ViewData.UnitsInStock)%></li>
    <li>List Price: <%= Html.TextBox("Product.UnitPrice", ViewData.UnitPrice)%></li>
    <li><%= Html.SubmitButton("submit", "Save")%></li>
</ul>
<% } %>
</asp:Content>
