using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SqlDbBase;
using System.Net;
using System.IO;
using System.Xml;
public partial class tuijian : System.Web.UI.Page
{
    public static string str = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlProvince.DataSource = dir_gaokao.GetProvince();
            ddlProvince.DataBind();
            rbl1.Items[0].Selected = true;
        }
    }
    protected void btn_Click(object sender, EventArgs e)
    {
        //首先判断今年分数线
        int score = Convert.ToInt32(tbScore.Text);
        string type = rbl1.SelectedItem.Text;
        string province = ddlProvince.SelectedItem.Text;
        string strUrl = string.Format("http://data.api.gkcx.eol.cn/soudaxue/queryProvince.html?luqutype3={3}&province3={0}&year3={1}&luqupici3={2}&page=1&size=1000&temp=165413165", province, "2017", "", type);
        //分析这个分数线
        XmlDocument xmlDoc = new XmlDocument();
        XmlReader reader = XmlReader.Create(strUrl);
        xmlDoc.Load(reader);
        XmlNodeList nodes = xmlDoc.ChildNodes[1].SelectNodes("school");
        if (nodes.Count == 0)
        {
            str = "很抱歉，没有此省份的信息";
            return;
        }
        else
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            foreach (XmlNode xml in nodes)
            {
                if ((xml.ChildNodes[2].Name == "bath") && (xml.ChildNodes[4].Name == "score"))
                {
                    dic.Add(xml.ChildNodes[2].InnerText, xml.ChildNodes[4].InnerText);
                }
            }
            //获取一下这个省份的data
            gaokao db = new gaokao();
            DataTable dtProvince = db.GetScoreByProvinceAndStudentType(ddlProvince.SelectedItem.Text, rbl1.SelectedItem.Text);
            //设置一二本处理
            bool temp1 = true;
            bool temp2 = true;
            bool temp3 = true;
            //获取一本分数线
            if (dic.Keys.Contains("本科一批"))
            {
                int line1 = Convert.ToInt32(dic["本科一批"]);
                if (Convert.ToInt32(score)<line1 )
                {
                    temp1 = false;
                }
            }
            else
            {
                temp1 = false;
                temp2 = false;
                temp3 = false;
            }
            if (dic.Keys.Contains("本科二批"))
            {
                int line2 = Convert.ToInt32(dic["本科二批"]);
                if (Convert.ToInt32(score) < line2)
                {
                    temp1 = false;
                    temp2 = false;
                }
            }
            else
            {
                temp1 = false;
                temp2 = false;
            }
            if (dic.Keys.Contains("本科三批"))
            {
                int line3 = Convert.ToInt32(dic["本科三批"]);
                if (Convert.ToInt32(score) < line3)
                {
                    temp1 = false;
                    temp2 = false;
                    temp3 = false;
                }
            }
            else
            {
                if(temp1==false && temp2==false)
                {
                    temp3 = false;
                }
            }
            //开始推荐学校
            DataRow[] drs;
            if (temp1 == false)
            {
                string cname = dtProvince.Columns[3].ColumnName;
                drs = dtProvince.Select("batch in ('本科二批','本科三批','专科')", "平均分 desc");
            }
            else if (temp2 == false)
            {
                drs = dtProvince.Select("batch in ('本科三批','专科')", "平均分 desc");
            }
            else if (temp3 == false)
            {
                drs = dtProvince.Select("batch in ('专科')", "平均分 desc");
            }
            else
            {
                drs = dtProvince.Select("1=1","平均分 desc");
            }
            //冲一冲
            List<string> lis2 = new List<string>();
            //稳一稳
            List<string> lis1 = new List<string>();
            //保一保
            List<string> lis0 = new List<string>();
            //定义显示总数
            int all = 60;
            for (int i = 0; i < drs.Length; i++)
            {
                if ((score - Convert.ToInt32(drs[i]["平均分"]) > 50))
                {
                    if (lis0.Count < all * 0.2)
                    {
                        lis0.Add(drs[i]["schoolname"].ToString());
                    }
                }
                else if ((score - Convert.ToInt32(drs[i]["平均分"]) > 15) && (score - Convert.ToInt32(drs[i]["平均分"]) < 50))
                {
                    if (lis1.Count < all * 0.6)
                    {
                        lis1.Add(drs[i]["schoolname"].ToString());
                    }
                }
                else if (score > Convert.ToInt32(drs[i]["最低分"]))
                {
                    if (score - Convert.ToInt32(drs[i]["平均分"]) < 15)
                    {
                        if (lis2.Count < all * 0.2)
                        {
                            lis2.Add(drs[i]["schoolname"].ToString());
                        }
                    }
                }
            }
            //显示冲一冲
            d2.DataSource = lis2;
            d2.DataBind();
            //显示保一保
            d1.DataSource = lis1;
            d1.DataBind();
            //显示稳一稳
            d0.DataSource = lis0;
            d0.DataBind();
            txtAll.Text = string.Format("共向你推荐:{0}个", (lis0.Count + lis1.Count + lis2.Count));
        }
    }
}