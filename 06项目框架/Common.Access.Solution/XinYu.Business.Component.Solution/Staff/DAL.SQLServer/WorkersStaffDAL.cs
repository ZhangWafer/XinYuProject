using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XinYu.Framework.Library.Utility.DAL;
using XinYu.Framework.Staff.Model;

namespace XinYu.Framework.Staff.DAL.SQLServer
{
    class WorkersStaffDAL
    {
        #region Const SQL String.
        const string CONST_SQL_INSERT = @"
                    INSERT INTO [Cater].[WorkerStaff]
                        ([InformationNum],[Name],[Category], [Icon],  [IconThum], [Tel], [Wechat], 
                        [OrganizationId], [OrganizationName],
                        [CafeteriaId], [CafeteriaName],
                        [DisplayOrder], [CreatedByID], [CreatedByName], [CreatedDate], [LastUpdByID], [LastUpdByName], [LastUpdDate])
                    VALUES
                        (@InformationNum,@Name,@Category,@Icon, @IconThum, @Tel, @Wechat,
                        @OrganizationId, @OrganizationName,
                        @CafeteriaId, @CafeteriaName,
                        @DisplayOrder, @CreatedByID, @CreatedByName, @CreatedDate, @LastUpdByID, @LastUpdByName, @LastUpdDate)
                    SELECT @@IDENTITY";

        const string CONST_SQL_UPDATE = @"
                    UPDATE [Cater].[WorkerStaff]
                       SET [InformationNum] = @InformationNum 
                          ,[Name]                       = @Name
                          ,[Category]                   = @Category
                          ,[Icon]                       = @Icon
                          ,[IconThum]                   = @IconThum
                          ,[Tel]                        = @Tel
                          ,[Wechat]                     = @Wechat

                          ,[OrganizationId]             = @OrganizationId
                          ,[OrganizationName]           = @OrganizationName

                          ,[CafeteriaId]                = @CafeteriaId
                          ,[CafeteriaName]              = @CafeteriaName

                          ,[DisplayOrder]               = @DisplayOrder
                          ,[LastUpdByID]                = @LastUpdByID
                          ,[LastUpdByName]              = @LastUpdByName
                          ,[LastUpdDate]                = @LastUpdDate
                     WHERE Id = @Id";

        const string CONST_SQL_DELETE = "DELETE FROM [Cater].[WorkerStaff] WHERE Id = @Id";

        const string CONST_SQL_SELECT = "SELECT * FROM [Cater].[WorkerStaff] WHERE Id = @Id";

        const string CONST_SQL_SELECT_LIST = @"
                    SELECT * FROM [Cater].[WorkerStaff] 
                    WHERE (@Name    = ''    OR Name    LIKE '%' + @Name +  '%')
                      AND (@OrganizationId  IS NULL OR OrganizationId  = @OrganizationId)
                      AND (@CafeteriaId  IS NULL OR CafeteriaId  = @CafeteriaId)
                    @OrderString";
        #endregion



        /// <summary>
        /// 添加食管人员
        /// </summary>
        public void Insert(WorkersStaffInfo csInfo)
        {
            var parameters = GetSqlParameter(csInfo);

            using (var dr = SQLHelper.ExecuteReader(SQLHelper.ConnString, CommandType.Text, CONST_SQL_INSERT, parameters))
            {
                dr.Read();
                csInfo.Id = Convert.ToInt32(dr[0]);
                dr.Close();
            }
        }

        /// <summary>
        /// 移除食管人员
        /// </summary>
        public void Delete(int csId)
        {
            SQLHelper.ExecuteNonQuery(SQLHelper.ConnString, CommandType.Text, CONST_SQL_DELETE, new SqlParameter("@Id", csId));
        }

        /// <summary>
        /// 修改食管人员
        /// </summary>
        public void Update(CafeteriaStaffInfo csInfo)
        {
            var parameters = this.GetSqlParameter(csInfo);

            SQLHelper.ExecuteNonQuery(SQLHelper.ConnString, CommandType.Text, CONST_SQL_UPDATE, parameters);
        }

        /// <summary>
        /// 获取食管人员
        /// </summary>
        public CafeteriaStaffInfo Select(int csId)
        {
            CafeteriaStaffInfo ret = null;
            using (var dr = SQLHelper.ExecuteReader(SQLHelper.ConnString, CommandType.Text, CONST_SQL_SELECT, new SqlParameter("@Id", csId)))
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
        /// 获取食管人员列表
        /// </summary>
        /// <param name="name">姓名</param>
        /// <param name="organizationId">机构ID</param>
        /// <param name="cafeteriaId">食堂id</param>
        /// <param name="orderString">sql排序</param>
        public IList<CafeteriaStaffInfo> SelectList(string name, int? organizationId, int? cafeteriaId, string orderString)
        {
            var parameters = new[] {
                new SqlParameter("@Name", name),
                new SqlParameter("@OrganizationId", organizationId),
                new SqlParameter("@CafeteriaId", cafeteriaId)
            };

            string sql = CONST_SQL_SELECT_LIST.Replace("@OrderString", orderString);

            using (var dr = SQLHelper.ExecuteReader(SQLHelper.ConnString, CommandType.Text, sql, parameters))
            {
                return GetModels(dr);
            }
        }

        /// <summary>
        /// 获取食管人员列表
        /// </summary>
        /// <param name="name">姓名</param>
        /// <param name="organizationId">机构ID</param>
        /// <param name="cafeteriaId">食堂id</param>
        /// <param name="orderString">sql排序</param>
        public IList<CafeteriaStaffInfo> SelectList(string name, int? organizationId, int? cafeteriaId, string orderString, int pageIndex, int pageSize, out int total)
        {
            var parameters = new[] { 
                new SqlParameter("@Name", name),
                new SqlParameter("@OrganizationId", organizationId),
                new SqlParameter("@CafeteriaId", cafeteriaId)
            };

            string sql = CONST_SQL_SELECT_LIST.Replace("@OrderString", orderString);

            using (var dr = SQLHelper.ExecuteReader(SQLHelper.ConnString, CommandType.Text, sql, parameters))
            {
                return GetModels(dr, pageIndex, pageSize, out total);
            }
        }
    }
}
