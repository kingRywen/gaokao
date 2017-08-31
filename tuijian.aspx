<%@ Page Language="C#" AutoEventWireup="true" CodeFile="tuijian.aspx.cs" Inherits="tuijian" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="initial-scale=1, maximum-scale=1, user-scalable=no">
    <meta name="format-detection" content="telephone=no">
    <title>高考志愿查询</title>
    <link rel="stylesheet" href="/src/css/frozen.css">
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager runat="server"></asp:ScriptManager>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    请输入你的成绩:<asp:TextBox ID="tbScore" runat="server" TextMode="Number"></asp:TextBox><br />
                    文理分科:<asp:RadioButtonList runat="server" ID="rbl1">
                        <asp:ListItem Value="0">文科</asp:ListItem>
                        <asp:ListItem Value="1">理科</asp:ListItem>
                    </asp:RadioButtonList><br />
                    请选择生源地:<asp:DropDownList runat="server" ID="ddlProvince"></asp:DropDownList><br />
                    <asp:Button ID="btn" runat="server" Text="查询" OnClick="btn_Click" /><br />
                    <asp:GridView runat="server" ID="gv2">

                    </asp:GridView>
                    <asp:GridView runat="server" ID="gv1">

                    </asp:GridView>
                    <asp:GridView runat="server" ID="gv0">

                    </asp:GridView>
                                        <asp:Literal runat="server" ID="txtAll"></asp:Literal><br />
                    冲一冲
                    <asp:DropDownList runat="server" ID="d2"></asp:DropDownList>
                    稳一稳
                    <asp:DropDownList runat="server" ID="d1"></asp:DropDownList>
                    保一保
                    <asp:DropDownList runat="server" ID="d0"></asp:DropDownList><br />
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:UpdateProgress runat="server"><ProgressTemplate>加载中。。。</ProgressTemplate></asp:UpdateProgress>
        </div>
    </form>
    <script type="text/javascript" src="/src/js/lib/zeptojs/zepto.min.js"></script>
    <script type="text/javascript" src="/src/js/frozen.js"></script>
</body>
</html>
