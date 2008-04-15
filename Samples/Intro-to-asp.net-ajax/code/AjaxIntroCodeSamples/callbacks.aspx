<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="callbacks.aspx.cs" Inherits="AjaxIntroCodeSamples.callbacks1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
            <Services>
                <asp:ServiceReference Path="callback.asmx" />
            </Services>
        </asp:ScriptManager>
    <div>
        <input id="Button1" type="button" value="Hello World" onclick="HelloWorld()" />
        <input id="Button2" type="button" value="Page Method" onclick="PageMethod()" />
        <input id="Button3" type="button" value="Get My Obj" onclick="GetMyObject()" />
        <div><span id="output"></span></div>
    </div>
    </form>
    <script type="text/javascript">
        function HelloWorld()
        {
            AjaxIntroCodeSamples.callback.HelloWorld(OnRequestComplete);
        }
        
        function PageMethod()
        {
            PageMethods.GetPageMethod(OnRequestComplete);
        }
        
        function GetMyObject()
        {
            AjaxIntroCodeSamples.callback.getMyObject(ObjectComplete);
        }
        
        function OnRequestComplete(result)
        {
            $get("output").innerHTML = result;
        }
        
        function ObjectComplete(result)
        {
            var sb = new Sys.StringBuilder();
            
            sb.append("Name: ");
            sb.append(result["Name"]);
            sb.append("<br/>Number: ");
            sb.append(result.Number);
            sb.append("<br/>Sport: ");
            sb.append(result.Sport);
            
            $get("output").innerHTML = sb.toString();
        }
    </script>
</body>
</html>
