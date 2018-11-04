using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using XinYu.Framework.Library.Utility.DAL;
using XinYu.Framework.Staff.Model;

namespace XinYu.Framework.Staff.DAL.SQLServer
{
    /// <summary>
    /// 警务人员数据访问类
    /// </summary>
    public class PCStaffDAL : AbstractSQLDAL<PCStaffInfo>
    {
        #region Const SQL String.
        const string CONST_SQL_INSERT = @"
                    INSERT INTO [Cater].[PCStaff]
                        ([Name], [PcRank], [PcRankId], [PCNum], [Password], [Icon], [IconThum], [Tel], [Wechat], 
                        [OrganizationId], [OrganizationName],
                        [DisplayOrder], [CreatedByID], [CreatedByName], [CreatedDate], [LastUpdByID], [LastUpdByName], [LastUpdDate])
                    VALUES
                        (@Name,@PcRank, @PcRankId, @PCNum, @Password, @Icon, @IconThum, @Tel, @Wechat,
                        @OrganizationId, @OrganizationName,
                        @DisplayOrder, @CreatedByID, @CreatedByName, @CreatedDate, @LastUpdByID, @LastUpdByName, @LastUpdDate)
                    SELECT @@IDENTITY";

        const string CONST_SQL_UPDATE = @"
                    UPDATE [Cater].[PCStaff]
                       SET [Name]                       = @Name
                          ,[PcRank]                     = @PcRank
                          ,[PcRankId]                   = @PcRankId
                          ,[PCNum]                      = @PCNum
                          ,[Password]                   = @Password
                          ,[Icon]                       = @Icon
                          ,[IconThum]                   = @IconThum
                          ,[Tel]                        = @Tel
                          ,[Wechat]                     = @Wechat

                          ,[OrganizationId]             = @OrganizationId
                          ,[OrganizationName]           = @OrganizationName

                          ,[DisplayOrder]               = @DisplayOrder
                          ,[LastUpdByID]                = @LastUpdByID
                          ,[LastUpdByName]              = @LastUpdByName
                          ,[LastUpdDate]                = @LastUpdDate
                     WHERE ID = @ID";

        const string CONST_SQL_DELETE = "DELETE FROM [Cater].[PCStaff] WHERE Id = @Id";

        const string CONST_SQL_SELECT = "SELECT * FROM [Cater].[PCStaff] WHERE Id = @Id";

        const string CONST_SQL_SELECT_PCNUM_PASSWORD = "SELECT * FROM [Cater].[PCStaff] WHERE PCNum = @PCNum And Password = @Password";

        const string CONST_SQL_SELECT_LIST = @"
                    SELECT * FROM [Cater].[PCStaff] 
                    WHERE (@Name    = ''    OR Name    LIKE '%' + @Name +  '%')
                      AND (@PCNum    = ''    OR PCNum    LIKE '%' + @PCNum +  '%')
                      AND (@OrganizationId  IS NULL OR OrganizationId  = @OrganizationId)
                    @OrderString";
        #endregion

        /// <summary>
        /// 添加警员
        /// </summary>
        public void Insert(PCStaffInfo pcInfo)
        {
            var parameters = GetSqlParameter(pcInfo);

            using (var dr = SQLHelper.ExecuteReader(SQLHelper.ConnString, CommandType.Text, CONST_SQL_INSERT, parameters))
            {
                dr.Read();
                pcInfo.Id = Convert.ToInt32(dr[0]);
                dr.Close();
            }
        }

        /// <summary>
        /// 移除警员
        /// </summary>
        public void Delete(int pcId)
        {
            SQLHelper.ExecuteNonQuery(SQLHelper.ConnString, CommandType.Text, CONST_SQL_DELETE, new SqlParameter("@Id", pcId));
        }

        /// <summary>
        /// 修改警员
        /// </summary>
        public void Update(PCStaffInfo pcInfo)
        {
            var parameters = this.GetSqlParameter(pcInfo);

            SQLHelper.ExecuteNonQuery(SQLHelper.ConnString, CommandType.Text, CONST_SQL_UPDATE, parameters);
        }


        /// <summary>
        /// 获取警员
        /// </summary>
        public PCStaffInfo Select(int pcId)
        {
            PCStaffInfo ret = null;
            using (var dr = SQLHelper.ExecuteReader(SQLHelper.ConnString, CommandType.Text, CONST_SQL_SELECT, new SqlParameter("@Id", pcId)))
            {
                if (dr.Read())
                {
                    ret = this.BuildModel(dr);
                }
                dr.Close();
            }
            return ret;
        }

        /// <summary>
        /// 登录验证
        /// </summary>
        public PCStaffInfo Select(string pcNum, string password)
        {
            PCStaffInfo ret = null;

            var parameters = new[] {
                new SqlParameter("@PCNum", pcNum),
                new SqlParameter("@Password", password)
            };

            using (var dr = SQLHelper.ExecuteReader(SQLHelper.ConnString, CommandType.Text, CONST_SQL_SELECT_PCNUM_PASSWORD, parameters))
            {
                if (dr.Read())
                {
                    ret = this.BuildModel(dr);
                }
                dr.Close();
            }
            return ret;
        }

        /// <summary>
        /// 获取警员列表
        /// </summary>
        /// <param name="name">姓名</param>
        /// <param name="pcNum">警号</param>
        /// <param name="organizationId">机构ID</param>
        /// <param name="orderString">sql排序</param>
        public IList<PCStaffInfo> SelectList(string name, string pcNum, int? organizationId, string orderString)
        {
            var parameters = new[] {
                new SqlParameter("@Name", name),
                new SqlParameter("@PCNum", pcNum),
                new SqlParameter("@OrganizationId", organizationId)
            };

            string sql = CONST_SQL_SELECT_LIST.Replace("@OrderString", orderString);

            using (var dr = SQLHelper.ExecuteReader(SQLHelper.ConnString, CommandType.Text, sql, parameters))
            {
                return GetModels(dr);
            }
        }

        /// <summary>
        /// 获取警员列表
        /// </summary>
        /// <param name="name">姓名</param>
        /// <param name="pcNum">警号</param>
        /// <param name="organizationId">机构ID</param>
        /// <param name="orderString">sql排序</param>
        public IList<PCStaffInfo> SelectList(string name, string pcNum, int? organizationId, string orderString, int pageIndex, int pageSize, out int total)
        {
            var parameters = new[] { 
                new SqlParameter("@Name", name),
                new SqlParameter("@PCNum", pcNum),
                new SqlParameter("@OrganizationId", organizationId)
            };

            string sql = CONST_SQL_SELECT_LIST.Replace("@OrderString", orderString);

            using (var dr = SQLHelper.ExecuteReader(SQLHelper.ConnString, CommandType.Text, sql, parameters))
            {
                return GetModels(dr, pageIndex, pageSize, out total);
            }
        }

        #region Private methods.

        public override PCStaffInfo BuildModel(IDataReader dr)
        {
            var ret = new PCStaffInfo
            {
                Id = int.Parse(dr["Id"].ToString()),
                Name = dr["Name"].ToString(),

                PcRank = dr["PcRank"].ToString(),
                PcRankId = int.Parse(dr["PcRankId"].ToString()),

                PCNum = dr["PCNum"].ToString(),
                Password = dr["Password"].ToString(),
                Icon = dr["Icon"].ToString(),
                IconThum = dr["IconThum"].ToString(),
                Tel = dr["Tel"].ToString(),
                Wechat = dr["Wechat"].ToString(),

                OrganizationName = dr["OrganizationName"].ToString(),
                OrganizationId = int.Parse(dr["OrganizationId"].ToString()),

                DisplayOrder = int.Parse(dr["DisplayOrder"].ToString()),
                CreatedByID = int.Parse(dr["CreatedByID"].ToString()),
                CreatedByName = dr["CreatedByName"].ToString(),
                CreatedDate = DateTime.Parse(dr["CreatedDate"].ToString()),
                LastUpdByID = int.Parse(dr["LastUpdByID"].ToString()),
                LastUpdByName = dr["LastUpdByName"].ToString(),
                LastUpdDate = DateTime.Parse(dr["LastUpdDate"].ToString())
            };
            return ret;
        }

        private SqlParameter[] GetSqlParameter(PCStaffInfo pcInfo)
        {
            return new[] {
                new SqlParameter("@Id", pcInfo.Id),
                new SqlParameter("@Name", pcInfo.Name),

                new SqlParameter("@PcRank", pcInfo.PcRank),
                new SqlParameter("@PcRankId", pcInfo.PcRankId),

                new SqlParameter("@PCNum", pcInfo.PCNum),
                new SqlParameter("@Password", pcInfo.Password),
                new SqlParameter("@Icon", pcInfo.Icon),
                new SqlParameter("@IconThum", pcInfo.IconThum),
                new SqlParameter("@Tel", pcInfo.Tel),
                new SqlParameter("@Wechat", pcInfo.Wechat),

                new SqlParameter("@OrganizationName", pcInfo.OrganizationName),
                new SqlParameter("@OrganizationId", pcInfo.OrganizationId),

                new SqlParameter("@DisplayOrder", pcInfo.DisplayOrder),
                new SqlParameter("@CreatedByID", pcInfo.CreatedByID),
                new SqlParameter("@CreatedByName", pcInfo.CreatedByName),
                new SqlParameter("@CreatedDate", pcInfo.CreatedDate),
                new SqlParameter("@LastUpdByID", pcInfo.LastUpdByID),
                new SqlParameter("@LastUpdByName", pcInfo.LastUpdByName),
                new SqlParameter("@LastUpdDate", pcInfo.LastUpdDate),
            };
        }
        #endregion
    }
}
