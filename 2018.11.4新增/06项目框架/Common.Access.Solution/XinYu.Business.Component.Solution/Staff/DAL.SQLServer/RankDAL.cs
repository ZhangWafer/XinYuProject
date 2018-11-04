using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using XinYu.Framework.Library.Utility.DAL;
using XinYu.Framework.Staff.Model;

namespace XinYu.Framework.Staff.DAL.SQLServer
{
    /// <summary>
    /// 警衔数据访问类
    /// </summary>
    public class RankDAL : AbstractSQLDAL<RankInfo>
    {
        #region Const SQL String.
        const string CONST_SQL_SELECT_LIST = @"
                    SELECT * FROM [DataDictionary].[Rank] 
                    @OrderString";
        #endregion

        /// <summary>
        /// 获取警衔列表
        /// </summary>
        /// <param name="name">警衔名称</param>
        /// <param name="orderString">sql排序</param>
        public IList<RankInfo> SelectList(string name, string orderString)
        {
            var parameters = new[] { 
                new SqlParameter("@Name", name),
            };

            var sql = CONST_SQL_SELECT_LIST.Replace("@OrderString", orderString);

            using (SqlDataReader dr = SQLHelper.ExecuteReader(SQLHelper.ConnString, CommandType.Text, sql, parameters))
            {
                return GetModels(dr);
            }
        }

        #region Private methods.

        public override RankInfo BuildModel(IDataReader dr)
        {
            var ret = new RankInfo
            {
                Id = int.Parse(dr["Id"].ToString()),
                Name = dr["Name"].ToString(),
                DisplayOrder = int.Parse(dr["DisplayOrder"].ToString())
            };
            return ret;
        }

        private SqlParameter[] GetSqlParameter(RankInfo rankInfo)
        {
            return new[] {
                new SqlParameter("@Id", rankInfo.Id),
                new SqlParameter("@Name", rankInfo.Name),
                new SqlParameter("@DisplayOrder", rankInfo.DisplayOrder)
            };
        }

        #endregion
    }
}
