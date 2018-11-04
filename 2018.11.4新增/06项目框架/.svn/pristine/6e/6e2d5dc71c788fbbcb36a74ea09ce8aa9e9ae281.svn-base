using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using XinYu.Framework.Cookbook.Model;
using XinYu.Framework.Library.Utility.DAL;

namespace XinYu.Framework.Cookbook.DAL.SQLServer
{
    /// <summary>
    /// 菜品管理数据访问类
    /// </summary>
    public class CookbookDAL : AbstractSQLDAL<CookbookInfo>
    {
        #region Const SQL String.
        const string CONST_SQL_INSERT = @"
                    INSERT INTO [Cater].[Cookbook]
                        ([Name], [Description],
                        [Price], [RealPrice], [SalePrice],
                        [Icon], [IconThum], 
                        [OrganizationId], [OrganizationName],
                        [DisplayOrder], [CreatedByID], [CreatedByName], [CreatedDate], [LastUpdByID], [LastUpdByName], [LastUpdDate])
                    VALUES
                        (@Name,@Description,
                        @Price, @RealPrice, @SalePrice,
                        @Icon, @IconThum,
                        @OrganizationId, @OrganizationName,
                        @DisplayOrder, @CreatedByID, @CreatedByName, @CreatedDate, @LastUpdByID, @LastUpdByName, @LastUpdDate)
                    SELECT @@IDENTITY";

        const string CONST_SQL_UPDATE = @"
                    UPDATE [Cater].[Cookbook]
                       SET [Name]                       = @Name
                          ,[Description]                = @Description

                          ,[Price]                      = @Price
                          ,[RealPrice]                  = @RealPrice
                          ,[SalePrice]                  = @SalePrice

                          ,[Icon]                       = @Icon
                          ,[IconThum]                   = @IconThum

                          ,[OrganizationId]             = @OrganizationId
                          ,[OrganizationName]           = @OrganizationName

                          ,[DisplayOrder]               = @DisplayOrder
                          ,[LastUpdByID]                = @LastUpdByID
                          ,[LastUpdByName]              = @LastUpdByName
                          ,[LastUpdDate]                = @LastUpdDate
                     WHERE ID = @ID";

        const string CONST_SQL_DELETE = "DELETE FROM [Cater].[Cookbook] WHERE Id = @Id";

        const string CONST_SQL_SELECT = "SELECT * FROM [Cater].[Cookbook] WHERE Id = @Id";

        const string CONST_SQL_SELECT_LIST = @"
                    SELECT * FROM [Cater].[Cookbook] 
                    WHERE (@Name    = ''    OR Name    LIKE '%' + @Name +  '%')
                      AND (@OrganizationId  IS NULL OR (OrganizationId  = @OrganizationId OR OrganizationId IS NULL))
                    @OrderString";
        #endregion

        /// <summary>
        /// 添加菜品
        /// </summary>
        public void Insert(CookbookInfo cbInfo)
        {
            var parameters = GetSqlParameter(cbInfo);

            using (var dr = SQLHelper.ExecuteReader(SQLHelper.ConnString, CommandType.Text, CONST_SQL_INSERT, parameters))
            {
                dr.Read();
                cbInfo.Id = Convert.ToInt32(dr[0]);
                dr.Close();
            }
        }

        /// <summary>
        /// 删除菜品
        /// </summary>
        public void Delete(int cbId)
        {
            SQLHelper.ExecuteNonQuery(SQLHelper.ConnString, CommandType.Text, CONST_SQL_DELETE, new SqlParameter("@Id", cbId));
        }

        /// <summary>
        /// 修改菜品
        /// </summary>
        public void Update(CookbookInfo cbInfo)
        {
            var parameters = this.GetSqlParameter(cbInfo);

            SQLHelper.ExecuteNonQuery(SQLHelper.ConnString, CommandType.Text, CONST_SQL_UPDATE, parameters);
        }

        /// <summary>
        /// 获取菜品
        /// </summary>
        public CookbookInfo Select(int pcId)
        {
            CookbookInfo ret = null;
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
        /// 获取菜品列表
        /// </summary>
        /// <param name="name">菜品名称</param>
        public IList<CookbookInfo> SelectList(string name, int? organizationId, string orderString)
        {
            var parameters = new[] {
                new SqlParameter("@Name", name),
                new SqlParameter("@OrganizationId", organizationId)
            };

            string sql = CONST_SQL_SELECT_LIST.Replace("@OrderString", orderString);

            using (var dr = SQLHelper.ExecuteReader(SQLHelper.ConnString, CommandType.Text, sql, parameters))
            {
                return GetModels(dr);
            }
        }

        /// <summary>
        /// 获取菜品列表
        /// </summary>
        /// <param name="name">菜品名称</param>
        /// <param name="organizationId">机构ID</param>
        public IList<CookbookInfo> SelectList(string name, int? organizationId, string orderString, int pageIndex, int pageSize, out int total)
        {
            var parameters = new[] { 
                new SqlParameter("@Name", name),
                new SqlParameter("@OrganizationId", organizationId)
            };

            string sql = CONST_SQL_SELECT_LIST.Replace("@OrderString", orderString);

            using (var dr = SQLHelper.ExecuteReader(SQLHelper.ConnString, CommandType.Text, sql, parameters))
            {
                return GetModels(dr, pageIndex, pageSize, out total);
            }
        }

        #region Private methods.

        public override CookbookInfo BuildModel(IDataReader dr)
        {
            var ret = new CookbookInfo
            {
                Id = int.Parse(dr["Id"].ToString()),
                Name = dr["Name"].ToString(),
                Description = dr["Description"].ToString(),

                Price = Convert.ToDecimal(dr["Price"].ToString()),
                RealPrice = Convert.ToDecimal(dr["RealPrice"].ToString()),
                SalePrice = Convert.ToDecimal(dr["SalePrice"].ToString()),

                Icon = dr["Icon"].ToString(),
                IconThum = dr["IconThum"].ToString(),

                OrganizationName = dr["OrganizationName"] == DBNull.Value
              ? null
              : dr["OrganizationName"].ToString(),

                OrganizationId = dr["OrganizationId"] == DBNull.Value
                ? (int?)null
                : Convert.ToInt32(dr["OrganizationId"].ToString()),

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

        private SqlParameter[] GetSqlParameter(CookbookInfo cbInfo)
        {
            return new[] {
                new SqlParameter("@Id", cbInfo.Id),
                new SqlParameter("@Name", cbInfo.Name),
                new SqlParameter("@Description", cbInfo.Description),

                new SqlParameter("@Price", cbInfo.Price),
                new SqlParameter("@RealPrice", cbInfo.RealPrice),
                new SqlParameter("@SalePrice", cbInfo.SalePrice),

                new SqlParameter("@Icon", cbInfo.Icon),
                new SqlParameter("@IconThum", cbInfo.IconThum),

                new SqlParameter("@OrganizationId", cbInfo.OrganizationId),
                new SqlParameter("@OrganizationName", cbInfo.OrganizationName),

                new SqlParameter("@DisplayOrder", cbInfo.DisplayOrder),
                new SqlParameter("@CreatedByID", cbInfo.CreatedByID),
                new SqlParameter("@CreatedByName", cbInfo.CreatedByName),
                new SqlParameter("@CreatedDate", cbInfo.CreatedDate),
                new SqlParameter("@LastUpdByID", cbInfo.LastUpdByID),
                new SqlParameter("@LastUpdByName", cbInfo.LastUpdByName),
                new SqlParameter("@LastUpdDate", cbInfo.LastUpdDate),
            };
        }
        #endregion
    }
}
