using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using XinYu.Framework.Cafeteria.Model;
using XinYu.Framework.Library.Utility.DAL;

namespace XinYu.Framework.Cafeteria.DAL.SQLServer
{
    /// <summary>
    /// 机构食堂数据访问类
    /// </summary>
    public class CafeteriDAL : AbstractSQLDAL<CafeteriInfo>
    {

        #region Const SQL String.
        const string CONST_SQL_INSERT = @"
                    INSERT INTO [Cater].[Cafeteria]
                        ([Name], [Description],[CafeteriaTypeEnum], [OrganizationId], [OrganizationName],
                        [DisplayOrder], [CreatedByID], [CreatedByName], [CreatedDate], [LastUpdByID], [LastUpdByName], [LastUpdDate])
                    VALUES
                        (@Name,@Description, @CafeteriaTypeEnum, @OrganizationId, @OrganizationName,
                        @DisplayOrder, @CreatedByID, @CreatedByName, @CreatedDate, @LastUpdByID, @LastUpdByName, @LastUpdDate)
                    SELECT @@IDENTITY";

        const string CONST_SQL_UPDATE = @"
                    UPDATE [Cater].[Cafeteria]
                       SET [Name]                       = @Name
                          ,[Description]                = @Description
                          ,[CafeteriaTypeEnum]          = @CafeteriaTypeEnum
                          ,[OrganizationId]             = @OrganizationId
                          ,[OrganizationName]           = @OrganizationName
                          ,[DisplayOrder]               = @DisplayOrder
                          ,[LastUpdByID]                = @LastUpdByID
                          ,[LastUpdByName]              = @LastUpdByName
                          ,[LastUpdDate]                = @LastUpdDate
                     WHERE ID = @ID";

        const string CONST_SQL_DELETE = "DELETE FROM [Cater].[Cafeteria] WHERE Id = @Id";

        const string CONST_SQL_SELECT = "SELECT * FROM [Cater].[Cafeteria] WHERE Id = @Id";

        const string CONST_SQL_SELECT_LIST = @"
                    SELECT * FROM [Cater].[Cafeteria] 
                    WHERE (@Name    = ''    OR Name    LIKE '%' + @Name +  '%')
                    @OrderString";

        #endregion

        /// <summary>
        /// 添加新的机构食堂
        /// </summary>
        public void Insert(CafeteriInfo cafeteriInfo)
        {
            var parameters = GetSqlParameter(cafeteriInfo);

            using (var dr = SQLHelper.ExecuteReader(SQLHelper.ConnString, CommandType.Text, CONST_SQL_INSERT, parameters))
            {
                dr.Read();
                cafeteriInfo.Id = Convert.ToInt32(dr[0]);
                dr.Close();
            }
        }

        /// <summary>
        /// 移除机构食堂
        /// </summary>
        public void Delete(int orgId)
        {
            SQLHelper.ExecuteNonQuery(SQLHelper.ConnString, CommandType.Text, CONST_SQL_DELETE, new SqlParameter("@ID", orgId));
        }

        public void Update(CafeteriInfo cafeteriInfo)
        {
            var parameters = this.GetSqlParameter(cafeteriInfo);

            SQLHelper.ExecuteNonQuery(SQLHelper.ConnString, CommandType.Text, CONST_SQL_UPDATE, parameters);
        }

        /// <summary>
        /// 修改机构食堂
        /// </summary>
        public CafeteriInfo Select(int cafId)
        {
            CafeteriInfo ret = null;
            using (var dr = SQLHelper.ExecuteReader(SQLHelper.ConnString, CommandType.Text, CONST_SQL_SELECT, new SqlParameter("@Id", cafId)))
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
        /// 查询机构食堂
        /// </summary>
        public IList<CafeteriInfo> SelectList(string name, string orderString)
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

        public override CafeteriInfo BuildModel(IDataReader dr)
        {
            var ret = new CafeteriInfo
            {
                Id = int.Parse(dr["Id"].ToString()),
                Name = dr["Name"].ToString(),
                Description = dr["Description"].ToString(),

                CafeteriaTypeEnum = (CafeteriaTypeEnum)Enum.Parse(typeof(CafeteriaTypeEnum), dr["CafeteriaTypeEnum"].ToString()),

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

        private SqlParameter[] GetSqlParameter(CafeteriInfo cafeteriInfo)
        {
            return new[] {
                new SqlParameter("@Id", cafeteriInfo.Id),
                new SqlParameter("@Name", cafeteriInfo.Name),
                new SqlParameter("@Description", cafeteriInfo.Description),

                new SqlParameter("@CafeteriaTypeEnum", cafeteriInfo.CafeteriaTypeEnum.ToString()),

                new SqlParameter("@OrganizationName", cafeteriInfo.OrganizationName),
                new SqlParameter("@OrganizationId", cafeteriInfo.OrganizationId),

                new SqlParameter("@DisplayOrder", cafeteriInfo.DisplayOrder),
                new SqlParameter("@CreatedByID", cafeteriInfo.CreatedByID),
                new SqlParameter("@CreatedByName", cafeteriInfo.CreatedByName),
                new SqlParameter("@CreatedDate", cafeteriInfo.CreatedDate),
                new SqlParameter("@LastUpdByID", cafeteriInfo.LastUpdByID),
                new SqlParameter("@LastUpdByName", cafeteriInfo.LastUpdByName),
                new SqlParameter("@LastUpdDate", cafeteriInfo.LastUpdDate),
            };
        }

        #endregion
    }
}
