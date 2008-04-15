<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="5_updateProgModal.aspx.cs" Inherits="AjaxIntroCodeSamples.__updateProgModal" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>ASP.Net AJAX 201</title>
    <style type="text/css">
        .error{color: #f00;}
        .message{color: #000;}
        .updating{margin: 12px;}
        .modalBackground 
        {
            background-color:#00f;
            filter:alpha(opacity=40);
            opacity:0.40;
        }    
        .updateProgress
        {
            border: solid 1px #333;
            background-color:#fff; 
            position:absolute; 
            text-align: center;
            width:160px; 
            height:60px;    
        }
        .updateProgressMessage
        {
            margin:3px; 
            vertical-align: middle;
        }
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
        <asp:Panel ID="pnlProg" runat="server" CssClass="updateProgress" style="display:none">
            <div class="updating">
                <img src="images/ajax-loader.gif" alt="Processing..." />
                <span class="updateProgressMessage">Processing...</span>
            </div>
        </asp:Panel>
        <AjaxToolkit:ModalPopupExtender 
            ID="mdlProgress" 
            runat="server" 
            TargetControlID="pnlProg" 
            PopupControlID="pnlProg" 
            BackgroundCssClass="modalBackground"/>
    </form>
    <script type="text/javascript">
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_beginRequest(beginRequest);
        prm.add_endRequest(endRequest);
        
        function beginRequest(sender, args)
        {
            $find("mdlProgress").show();
        }
        
        function endRequest(sender, args)
        {
           $find("mdlProgress").hide();
           
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
