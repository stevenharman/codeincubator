<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<List<ProductListingModel>>" %>

<%@ Import Namespace="StarDestroyer.Models" %>
<%@ Import Namespace="StarDestroyer.Helpers.HTML" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Product Catalog
</asp:Content>
<asp:Content ID="HeadContent" ContentPlaceHolderID="HeadContent" runat="server">

    <script type="text/javascript">
        jQuery(document).ready(function() {
            jQuery("#list").jqGrid({
                url: '/Product/List/',
                datatype: 'json',
                mtype: 'GET',
                colNames: ['Id', 'Votes', 'Title'],
                colModel: [
          { name: 'Id', index: 'Id', width: 40, align: 'left' },
          { name: 'Votes', index: 'Votes', width: 40, align: 'left' },
          { name: 'Title', index: 'Title', width: 200, align: 'left'}],
                pager: jQuery('#pager'),
                rowNum: 10,
                rowList: [5, 10, 20, 50],
                sortname: 'Id',
                sortorder: "desc",
                viewrecords: true,
                imgpath: '/content/images',
                caption: 'My first grid'
            });
        }); 

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Product Catalog</h2>
    <%= Html.Table("Products", Model, null) %>
    <table id="list" class="scroll" cellpadding="0" cellspacing="0">
    </table>
    <div id="pager" class="scroll" style="text-align: center;">
    </div>
</asp:Content>
