<%@ Page Title="Edit Beer" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="MvcDemoApp_Preview3.Views.Beer.Edit" %>
<%@ Import Namespace="MvcDemoApp_Preview3.Controllers"%>
<asp:Content ID="EditContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Edit <%= ViewData.Model.Name %></h2>
    <% using (Html.Form<BeerController>(c => c.Update(ViewData.Model.id))) { %>
        <table>
            <tr><td align="right">Name: </td><td><%= Html.TextBox("Beer.Name", ViewData.Model.Name) %></td></tr>
            <tr><td align="right">Type: </td><td><%= Html.DropDownList("Type_id")%></td></tr>
            <tr><td align="right">Brewery: </td><td><%= Html.DropDownList("Brewery_id")%></td></tr>
            <tr><td align="right">Description: </td><td><%= Html.TextArea("Beer.Description", ViewData.Model.Description, 4, 30) %></td></tr>
            <tr><td align="right"><%= Html.SubmitButton("submit", "Save") %></td></tr>
        </table>
        <p><%= Html.ActionLink("Return To List", "Index") %></p>
    <% } %>
</asp:Content>
