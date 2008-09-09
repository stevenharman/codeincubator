<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="callbackPaging.aspx.cs" Inherits="AjaxIntroCodeSamples.callbackPaging" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body onload="GetPagingLinks();">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
            <Services>
                <asp:ServiceReference Path="callback.asmx" />
            </Services>
        </asp:ScriptManager>
    <div>
        <div id="pageLinks" style="margin-bottom: 12px;"></div>
        <div id="dataGrid"></div>
    </div>
    </form>
</body>
<script type="text/javascript">
    function GetPagingLinks()
    {
        AjaxIntroCodeSamples.callback.PagingLinks(OnPagingRequestComlete);
    }
    
    function LoadDataForPageNumber(pageNumber)
    {
        AjaxIntroCodeSamples.callback.GetTableForPageNumber(pageNumber, OnLoadRequestComplete);
    }
    
    function OnPagingRequestComlete(results)
    {
        $get("pageLinks").innerHTML = results;
    }
    
    function OnLoadRequestComplete(results)
    {
        $get("dataGrid").innerHTML = results;
    }
</script>
</html>
