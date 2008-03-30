<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="MvcDemoApp.Views.Product.Edit" %>
<%@ Import Namespace="MvcDemoApp.Controllers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
<h2>Edit <%= ViewData.Name %></h2>
<% using (Html.Form<ProductController>(p => p.Update(ViewData.ProductID))) { %>
<ul style="list-style-type: none;">
    <li>Color: <%= Html.TextBox("Product.Color", ViewData.Color)%></li>
    <li>List Price: <%= Html.TextBox("Product.ListPrice", ViewData.ListPrice)%></li>
    <li><%= Html.SubmitButton("submit", "Save")%></li>
</ul>
<% } %>
</asp:Content>
