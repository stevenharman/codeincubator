<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="MvcDemoApp_Preview3.Views.Beer.Index" %>
<%@ Import Namespace="MvcDemoApp_Preview3.Controllers"%>
<%@ Import Namespace="MvcDemoApp_Preview3.Models"%>
<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
<script src="../../Content/jquery-1.2.3.min.js" type="text/javascript"></script>
    <h1>Beer List : Count : <%= ViewData["TotalBeers"].ToString() %></h1>
    <div id="gridColumn">
        <table id="beerList" class="beerGrid" cellpadding="0" cellspacing="0" border="0">
            <tr>
                <th class="first">&nbsp;</th>
                <th>Name</th>
            </tr>
            <%
            foreach (Beer beer in ViewData.Model)
            { %>
            <tr>
                <td class="first"><a href="javascript: ShowBeer(<%= beer.id %>)">View</a></td>
                <td><%= beer.Name %></td>
            </tr>
            <% } %>
        </table>
        <p>Page: 
        <%
        for (int i = 1; i <= (int)ViewData["NumberOfPages"]; i++) {%>
            <a href="/Beer/Index/<%= i %>"><%= i %></a>&nbsp;
        <% } %>
        </p>
    </div>
    <div id="detailColumn">
        <div id="beerDetail"></div>
    </div>
    
    <script type="text/javascript">
        function ShowBeer(beerId)
        {
            $.post("/Beer/BeerPlease/" + beerId, 
                function(results){
                    $('#beerDetail').html(results);
                }
            );
        }
    </script>

</asp:Content>
