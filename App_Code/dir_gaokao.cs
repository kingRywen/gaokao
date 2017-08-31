using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// dir_provice 的摘要说明
/// </summary>
public class dir_gaokao
{
    public dir_gaokao()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    public static List<string> GetProvince()
    {
        List<string> lis = new List<string>();
        lis.Add("天津");
        lis.Add("河北");
        lis.Add("河南");
        lis.Add("山东");
        lis.Add("山西");
        lis.Add("陕西");
        lis.Add("内蒙古");
        lis.Add("辽宁");
        lis.Add("吉林");
        lis.Add("黑龙江");
        lis.Add("上海");
        lis.Add("江苏");
        lis.Add("安徽");
        lis.Add("江西");
        lis.Add("湖北");
        lis.Add("湖南");
        lis.Add("重庆");
        lis.Add("四川");
        lis.Add("贵州");
        lis.Add("云南");
        lis.Add("广东");
        lis.Add("广西");
        lis.Add("福建");
        lis.Add("甘肃");
        lis.Add("宁夏");
        lis.Add("新疆");
        lis.Add("西藏");
        lis.Add("海南");
        lis.Add("浙江");
        lis.Add("青海");
        return lis;
    }
    public static List<string> GetSort()
    {
        List<string> lis = new List<string>();
        lis.Add("本科一批");
        lis.Add("本科二批");
        lis.Add("本科三批");
        lis.Add("专科一批");
        lis.Add("专科二批");
        return lis;
    }
    public static List<string> GetYear()
    {
        List<string> lis = new List<string>();
        lis.Add("2017");
        lis.Add("2016");
        lis.Add("2015");
        lis.Add("2014");
        lis.Add("2013");
        lis.Add("2012");
        lis.Add("2011");
        lis.Add("2010");
        return lis;
    }
    public static List<string> GetType()
    {
        List<string> lis = new List<string>();
        lis.Add("文科");
        lis.Add("理科");
        return lis;
    }
}