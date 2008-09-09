<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AjaxIntroCodeSamples._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>ASP.Net AJAX 201</title>
    <style type="text/css">
        .upPanel{
            border: solid 1px #333; 
            margin: 20px; 
            padding: 10px; 
            width: 300px; 
            height: 120px;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="conditional">
            <ContentTemplate>
                <asp:Panel ID="Panel1" runat="server" CssClass="upPanel">
                    <div>
                        <asp:Button ID="btnShowTime" runat="server" Text="Show Time" />
                    </div>
                    <div>
                        <asp:Label ID="lblMessage" runat="server" Text="Welcome Race Fans"></asp:Label>
                    </div>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="always">
            <ContentTemplate>
                <asp:Panel ID="Panel2" runat="server" CssClass="upPanel">
                    <div>
                        <asp:Button ID="Button1" runat="server" Text="Show Time" OnClick="Button1_onClick" />
                    </div>
                    <div>
                        <asp:Label ID="Label1" runat="server" Text="Welcome Race Fans"></asp:Label>
                    </div>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
