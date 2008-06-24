<%@ Language="C#" AutoEventWireup="true" CodeBehind="BeerDetail.aspx.cs" Inherits="MvcDemoApp_Preview3.Views.Beer.BeerDetail" %>
<%@ Import Namespace="MvcDemoApp_Preview3.Controllers"%>

<h3><%= ViewData.Model.Name %></h3>
<ul class="beerlist">
    <li>Type: <%= ViewData.Model.BeerType.Name %></li>
    <li>Brewery: <%= ViewData.Model.Brewery.Name %> (<%= ViewData.Model.Brewery.Location %>, est. <%= ViewData.Model.Brewery.Established %>)</li>
</ul>
<p><%= ViewData.Model.Description %></p>
<p><%= Html.ActionLink<BeerController>(c => c.Edit(ViewData.Model.id), string.Format("Edit {0}", ViewData.Model.Name)) %></p>
