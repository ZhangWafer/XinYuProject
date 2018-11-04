using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XinYu.Framework.Library.Utility.DAL;
using XinYu.Framework.Staff.Model;

namespace XinYu.Framework.Staff.DAL.SQLServer
{
    public class WorkersStaffDAL : AbstractSQLDAL<WorkersStaffInfo>
    {
        #region Const SQL String.
        const string CONST_SQL_INSERT = @"
                    INSERT INTO [Cater].[WorkerStaff]
                        ([InformationNum],[Password],[Name],[WorkerStaffEnum], [Icon],  [IconThum], [Tel], [Wechat], 
                        [OrganizationId], [OrganizationName],
                        [CafeteriaId], [CafeteriaName],
                        [DisplayOrder], [CreatedByID], [CreatedByName], [CreatedDate], [LastUpdByID], [LastUpdByName], [LastUpdDate])
                    VALUES
                        (@InformationNum, @Password, @Name,@WorkerStaffEnum,@Icon, @IconThum, @Tel, @Wechat,
                        @OrganizationId, @OrganizationName,
                        @CafeteriaId, @CafeteriaName,
                        @DisplayOrder, @CreatedByID, @CreatedByName, @CreatedDate, @LastUpdByID, @LastUpdByName, @LastUpdDate)
                    SELECT @@IDENTITY";

        const string CONST_SQL_UPDATE = @"
                    UPDATE [Cater].[WorkerStaff]
                       SET [InformationNum]             = @InformationNum 
                          ,[Password]                   = @Password
                          ,[Name]                       = @Name
                          ,[WorkerStaffEnum]            = @WorkerStaffEnum
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

        const string CONST_SQL_SELECT_PCNUM_PASSWORD = "SELECT * FROM [Cater].[WorkerStaff] WHERE InformationNum = @InformationNum And Password = @Password";

        const string CONST_SQL_SELECT_LIST = @"
                    SELECT * FROM [Cater].[WorkerStaff] 
                    WHERE (@Name    = ''    OR Name    LIKE '%' + @Name +  '%')
                      AND (@OrganizationId  IS NULL OR OrganizationId  = @OrganizationId)
                      AND (@CafeteriaId  IS NULL OR CafeteriaId  = @CafeteriaId)
                    @OrderString";
        #endregion


        /// <summary>
        /// 添加职工人员
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
        /// 移除职工人员
        /// </summary>
        public void Delete(int csId)
        {
            SQLHelper.ExecuteNonQuery(SQLHelper.ConnString, CommandType.Text, CONST_SQL_DELETE, new SqlParameter("@Id", csId));
        }

        /// <summary>
        /// 修改职工人员
        /// </summary>
        public void Update(WorkersStaffInfo csInfo)
        {
            var parameters = this.GetSqlParameter(csInfo);

            SQLHelper.ExecuteNonQuery(SQLHelper.ConnString, CommandType.Text, CONST_SQL_UPDATE, parameters);
        }

        /// <summary>
        /// 获取职工人员
        /// </summary>
        public WorkersStaffInfo Select(int csId)
        {
            WorkersStaffInfo ret = null;
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
        /// 登录验证
        /// </summary>
        public WorkersStaffInfo Select(string informationNum, string password)
        {
            WorkersStaffInfo ret = null;

            var parameters = new[] {
                new SqlParameter("@InformationNum", informationNum),
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
        /// 获取职工人员列表
        /// </summary>
        /// <param name="name">姓名</param>
        /// <param name="organizationId">机构ID</param>
        /// <param name="cafeteriaId">食堂id</param>
        /// <param name="orderString">sql排序</param>
        public IList<WorkersStaffInfo> SelectList(string name, int? organizationId, int? cafeteriaId, string orderString)
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
        public IList<WorkersStaffInfo> SelectList(string name, int? organizationId, int? cafeteriaId, string orderString, int pageIndex, int pageSize, out int total)
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

        private SqlParameter[] GetSqlParameter(WorkersStaffInfo csInfo)
        {
            return new[] {
                new SqlParameter("@Id", csInfo.Id),
                new SqlParameter("@InformationNum", csInfo.InformationNum),
                new SqlParameter("@Password", csInfo.Password),
                new SqlParameter("@Name", csInfo.Name),
                new SqlParameter("@WorkerStaffEnum", csInfo.WorkerStaffEnum.ToString()),

                new SqlParameter("@Icon", csInfo.Icon),
                new SqlParameter("@IconThum", csInfo.IconThum),
                new SqlParameter("@Tel", csInfo.Tel),
                new SqlParameter("@Wechat", csInfo.Wechat),

                new SqlParameter("@OrganizationName", csInfo.OrganizationName),
                new SqlParameter("@OrganizationId", csInfo.OrganizationId),

                new SqlParameter("@CafeteriaId", csInfo.CafeteriaId),
                new SqlParameter("@CafeteriaName", csInfo.CafeteriaName),

                new SqlParameter("@DisplayOrder", csInfo.DisplayOrder),
                new SqlParameter("@CreatedByID", csInfo.CreatedByID),
                new SqlParameter("@CreatedByName", csInfo.CreatedByName),
                new SqlParameter("@CreatedDate", csInfo.CreatedDate),
                new SqlParameter("@LastUpdByID", csInfo.LastUpdByID),
                new SqlParameter("@LastUpdByName", csInfo.LastUpdByName),
                new SqlParameter("@LastUpdDate", csInfo.LastUpdDate),
            };
        }

        public override WorkersStaffInfo BuildModel(IDataReader dr)
        {
            var ret = new WorkersStaffInfo
            {
                Id = int.Parse(dr["Id"].ToString()),

                InformationNum = dr["InformationNum"].ToString(),
                Password = dr["Password"].ToString(),

                WorkerStaffEnum = (WorkerStaffEnum)Enum.Parse(typeof(WorkerStaffEnum), dr["WorkerStaffEnum"].ToString()),

                Name = dr["Name"].ToString(),

                Icon = dr["Icon"].ToString(),
                IconThum = dr["IconThum"].ToString(),
                Tel = dr["Tel"].ToString(),
                Wechat = dr["Wechat"].ToString(),

                OrganizationName = dr["OrganizationName"].ToString(),
                OrganizationId = int.Parse(dr["OrganizationId"].ToString()),

                CafeteriaName = dr["CafeteriaName"].ToString(),
                CafeteriaId = int.Parse(dr["CafeteriaId"].ToString()),

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
    }
}
