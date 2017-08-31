<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta content="user-scalable=0;" name="viewport" />
    <link rel="stylesheet" type="text/css" href="/cardinal.min.css">
    <link rel="stylesheet" type="text/css" href="/main.css">
    <title>高考历年分数线查询</title>
</head>
<body>
<div id="pop" style="display:none">
    <div id="container">
        <div id="close" onclick="document.getElementById('pop').style.display='none'">X</div>
        <div id="wrapper"></div>
    </div>
</div>
<form id="form1" runat="server" visible="">
<asp:ScriptManager runat="server"></asp:ScriptManager>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
    <div class="container">
        <div class="header">
            <img src="/img/header.png" alt="高考历年分数线查询">
        </div>
        <div class="hr_line"></div>
        <div class="dt mb">
            <div class="dtc one-half"><div class="box mr-">
                <p>
                    <asp:DropDownList CssClass="form-select" runat="server" ID="ddlProvince"></asp:DropDownList>
              </p>
            </div></div>
            <div class="dtc one-half"><div class="box ml-">
                <p>
                    <asp:DropDownList CssClass="form-select" runat="server" ID="ddlSort"></asp:DropDownList>
              </p>
            </div></div>

        </div>
        <div class="dt mb">
            <div class="dtc one-half"><div class="box mr-">
                <p>
                <asp:DropDownList CssClass="form-select" runat="server" ID="ddlYear"></asp:DropDownList>
              </p>
            </div></div>
            <div class="dtc one-half"><div class="box ml-">
                <p>
                
                <asp:DropDownList CssClass="form-select" runat="server" ID="ddlType"></asp:DropDownList>
              </p>
            </div></div>
            
        </div>
        <div class="dt mb"><div class="dtc one-half"><div class="box mr-">
            <asp:Button ID="btn" CssClass="btn btn-primary btn-round one-whole" onClientClick="cl()" runat="server" Text="确定选择" OnClick="btn_Click" /> 
            <div id="el" style="display:none"><%=str %></div>
            
            </div></div>
        </div>
        <div class="dt mb"><div class="dtc one-half"><div class="box mr-" style="text-align:center">
        <br><br><br>
            <img src="/img/ma.jpg" width="200" align="center"><br><br><br>
            <span class="span" style="font-size:32px;font-weight:bold">长按识别二维码关注“科技视野”公众号<br>发现更多价值</span>
            </div></div>
        </div>
    </div>
    
                   
                </ContentTemplate>
            </asp:UpdatePanel>
           <asp:UpdateProgress runat="server"><ProgressTemplate><div class="container1"><img class="container1" src="/img/loading.gif"></div></ProgressTemplate></asp:UpdateProgress>
    
    </form>

    <script type="text/javascript">
    function cl() {
                clearInterval(timer);
                document.getElementById('el').innerHTML = '';
                var timer = setInterval(function(){
                    var data = document.getElementById('el').innerHTML;
                    var pop = document.getElementById('pop');
                    var wrapper = document.getElementById('wrapper');
                    var table = '';
                    
                    if(data){
                        console.log('成功');
                        clearInterval(timer);
                        data = data.slice(5,data.length-2);
                        data = eval("("+data+")");
                        console.log(data);
                        if (+data.totalRecord.num) {
                            for (var i = 0; i < data.school.length; i++) {
                                table = table + '<tr><td>'+data.school[i].province+'</td><td>'+data.school[i].year+'</td><td>'+data.school[i].bath+'</td><td>'+data.school[i].type+'</td><td>'+data.school[i].score + '</td></tr>';
                                
                            };

                            table = '<table class="table table-border-cells"><tr><th>地区</th><th>年份</th><th>考生类别</th><th>批次</th><th>分数线</td></tr>' + table + '</table>';
                            pop.style.display = 'block';
                            var Table = document.createElement('div');
                            Table.innerHTML = table;
                            wrapper.innerHTML = '';
                            wrapper.scrollTop = 0;
                            wrapper.appendChild(Table);
                            //pop.innerHTML = table;
                        }else{
                            pop.style.display = 'block';
                            wrapper.innerHTML = '<span style="font-size:2em;color:#fff">不存在数据</span>';
                        };
                    }
                }, 200)

            }

    </script>
</body>
</html>
