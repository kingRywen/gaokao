using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// gaokao 的摘要说明
/// </summary>
public class gaokao:SqlDbBase.dbConfigBySql
{
	public gaokao()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    #region 得到某个省份的所有招生学校最低分和平均线
    ///<summary>
    ///得到某个省份的所有招生学校最低分和平均线
    ///</summary>
    public DataTable GetScoreByProvinceAndStudentType(string localprovince, string studenttype)
    {
        string sqlStr = "select schoolname,batch,(SUM(CAST(proscore as int))/(COUNT(schoolname))) as 最低分,(SUM(CAST(var_score as int))/(COUNT(schoolname))) as 平均分 from tb_univers where proscore!='--' and localprovince=@localprovince and batch!='提前' and studenttype=@studenttype group by schoolname,batch";
        Dictionary<string, object> dic = new Dictionary<string, object>();
        dic.Add("localprovince", localprovince);
        dic.Add("studenttype", studenttype);
        return GetDataTable(sqlStr, dic);
    }
    #endregion
}