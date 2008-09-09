<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="6_disable.aspx.cs" Inherits="AjaxIntroCodeSamples.__disable" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>ASP.Net AJAX 201</title>
    <style type="text/css">
        .error{color: #f00;}
        .message{color: #000;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="3" />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div>
                    <asp:Button ID="btnShowTime" runat="server" Text="Show Time" OnClick="btnShowTime_Click" />
                    <asp:Button ID="btnError" runat="server" Text="Throw Error" OnClick="btnError_Click" />
                    <asp:Button ID="btnTimeout" runat="server" Text="Timeout" OnClick="btnTimeout_Click" />
                </div>
                <div>
                    <asp:Label ID="lblMessage" runat="server" Text="Label"></asp:Label>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
    <script type="text/javascript">
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(endRequest);
        
        function endRequest(sender, args)
        {
           var messageSpan = $get("<%= lblMessage.ClientID %>");
           if (args.get_error() != undefined)
           {
                var errorMessage = args.get_error().message;
                if (args.get_error() && args.get_error().name === 'Sys.WebForms.PageRequestManagerTimeoutException') { 
                    errorMessage = "Your operation has timed out."; 
                } 
                args.set_errorHandled(true);
                messageSpan.className = "error";
                messageSpan.innerHTML = errorMessage;
           }
        }
    </script>
</body>
</html>
