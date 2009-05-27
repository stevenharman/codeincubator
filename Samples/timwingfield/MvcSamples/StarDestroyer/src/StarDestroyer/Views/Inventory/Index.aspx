<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<List<AssaultItem>>" %>
<%@ Import Namespace="StarDestroyer.Core.Entities"%>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Assault Inventory
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Available Personnel and Equipment</h2>
    <div id="inventoryList">
        <table id="equipmentList">
            <tr>
                <td>
                    <strong>Type</strong>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <%
            foreach (var item in Model)
            {%>
            <tr>
                <td>
                    <%=Html.Encode(item.Type) %>
                </td>
                <td>
                    <%=Html.ActionLink("Details", "Details", new { id = item.Id }) %>
                </td>
            </tr>
            <% } %>
        </table>
    </div>
    <div id="details">
        <img src="../../Content/Images/ISD_egvv.jpg" />
    </div>
</asp:Content>