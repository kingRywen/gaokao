using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
public partial class _Default : System.Web.UI.Page
{
    public string str = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            ddlProvince.DataSource = GetAllType(dir_gaokao.GetProvince(),true);
            ddlProvince.DataTextField = "key";
            ddlProvince.DataValueField = "value";
            ddlProvince.DataBind();
            ddlSort.DataSource =GetAllType(dir_gaokao.GetSort(),true);
            ddlSort.DataTextField = "key";
            ddlSort.DataValueField = "value";
            ddlSort.DataBind();
            ddlType.DataSource = GetAllType(dir_gaokao.GetType(),true);
            ddlType.DataTextField = "key";
            ddlType.DataValueField = "value";
            ddlType.DataBind();
            ddlYear.DataSource = GetAllType(dir_gaokao.GetYear(),false);
            ddlYear.DataTextField = "key";
            ddlYear.DataValueField = "value";
            ddlYear.DataBind();
        }
    }
    private Dictionary<string,string> GetAllType(List<string> lis,bool temp)
    {
        Dictionary<string, string> dic = new Dictionary<string, string>();
        if(temp)
        {
            dic.Add("不限", "");
        }
        foreach(string str in lis)
        {
            dic.Add(str,str);
        }
        return dic;
    }
    protected void btn_Click(object sender, EventArgs e)
    {
        //System.Threading.Thread.Sleep(2000);
        string country = ddlProvince.SelectedItem.Value;
        string year = ddlYear.SelectedItem.Value;
        string sort = ddlSort.SelectedItem.Value;
        string type = ddlType.SelectedItem.Value;
        string strUrl = string.Format("http://data.api.gkcx.eol.cn/soudaxue/queryProvince.html?messtype=jsonp&luqutype3={3}&province3={0}&year3={1}&luqupici3={2}&page=1&size=1000&temp=165413165",country,year,sort,type);
        var request = (HttpWebRequest)WebRequest.Create(strUrl);
        var response = (HttpWebResponse)request.GetResponse();
        var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
        str = responseString;
    }
}