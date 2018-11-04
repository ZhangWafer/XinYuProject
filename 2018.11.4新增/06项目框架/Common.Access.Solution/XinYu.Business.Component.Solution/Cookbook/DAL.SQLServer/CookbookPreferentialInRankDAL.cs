using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using XinYu.Framework.Cookbook.Model;
using XinYu.Framework.Library.Utility.DAL;

namespace XinYu.Framework.Cookbook.DAL.SQLServer
{
    /// <summary>
    /// 菜品优惠数据访问类
    /// </summary>
    public class CookbookPreferentialInRankDAL : AbstractSQLDAL<CookbookPreferentialInRankInfo>
    {
        #region Const SQL String.
        const string CONST_SQL_INSERT = @"
                    INSERT INTO [Cater].[CookbookPreferentialInRank]
                        ([Name], [Description],
                        [RankId], [RandName],      
                        [CookbookId], [CookbookName],   
                        [SalePrice],[RealPrice], 
                        [OrganizationId], [OrganizationName],
                        [DisplayOrder], [CreatedByID], [CreatedByName], [CreatedDate], [LastUpdByID], [LastUpdByName], [LastUpdDate])
                    VALUES
                        (@Name,@Description,
                        @RankId, @RandName,
                        @CookbookId, @CookbookName,
                        @SalePrice, @RealPrice,
                        @OrganizationId, @OrganizationName,
                        @DisplayOrder, @CreatedByID, @CreatedByName, @CreatedDate, @LastUpdByID, @LastUpdByName, @LastUpdDate)
                    SELECT @@IDENTITY";

        const string CONST_SQL_UPDATE = @"
                    UPDATE [Cater].[CookbookPreferentialInRank]
                       SET [Name]                       = @Name
                          ,[Description]                = @Description

                          ,[RankId]                     = @RankId   
                          ,[RandName]                   = @RandName   

                          ,[CookbookId]                 = @CookbookId   
                          ,[CookbookName]               = @CookbookName  

                          ,[SalePrice]                  = @SalePrice
                          ,[RealPrice]                  = @RealPrice

                          ,[OrganizationId]             = @OrganizationId
                          ,[OrganizationName]           = @OrganizationName

                          ,[DisplayOrder]               = @DisplayOrder
                          ,[LastUpdByID]                = @LastUpdByID
                          ,[LastUpdByName]              = @LastUpdByName
                          ,[LastUpdDate]                = @LastUpdDate
                     WHERE ID = @ID";

        const string CONST_SQL_DELETE = "DELETE FROM [Cater].[CookbookPreferentialInRank] WHERE Id = @Id";

        const string CONST_SQL_SELECT = "SELECT * FROM [Cater].[CookbookPreferentialInRank] WHERE Id = @Id";

        const string CONST_SQL_SELECT_BY_RID_CBID_ORGID = "SELECT * FROM [Cater].[CookbookPreferentialInRank] WHERE RankId = @RankId AND CookbookId = @CookbookId AND OrganizationId =@OrganizationId";

        const string CONST_SQL_SELECT_LIST = @"
                    SELECT * FROM [Cater].[CookbookPreferentialInRank] 
                    WHERE (@Name    = ''    OR Name    LIKE '%' + @Name +  '%')
                      AND (@RankId  IS NULL OR RankId  = @RankId)
                      AND (@CookbookId  IS NULL OR CookbookId  = @CookbookId)
                      AND (@OrganizationId  IS NULL OR OrganizationId  = @OrganizationId)
                    @OrderString";
        #endregion

        /// <summary>
        /// 添加菜品优惠
        /// </summary>
        public void Insert(CookbookPreferentialInRankInfo cbrInfo)
        {
            var parameters = GetSqlParameter(cbrInfo);

            using (var dr = SQLHelper.ExecuteReader(SQLHelper.ConnString, CommandType.Text, CONST_SQL_INSERT, parameters))
            {
                dr.Read();
                cbrInfo.Id = Convert.ToInt32(dr[0]);
                dr.Close();
            }
        }

        /// <summary>
        /// 删除菜品优惠
        /// </summary>
        public void Delete(int cbrId)
        {
            SQLHelper.ExecuteNonQuery(SQLHelper.ConnString, CommandType.Text, CONST_SQL_DELETE, new SqlParameter("@Id", cbrId));
        }

        /// <summary>
        /// 修改菜品优惠
        /// </summary>
        public void Update(CookbookPreferentialInRankInfo cbrInfo)
        {
            var parameters = this.GetSqlParameter(cbrInfo);

            SQLHelper.ExecuteNonQuery(SQLHelper.ConnString, CommandType.Text, CONST_SQL_UPDATE, parameters);
        }

        /// <summary>
        /// 获取菜品优惠
        /// </summary>
        public CookbookPreferentialInRankInfo Select(int cbrId)
        {
            CookbookPreferentialInRankInfo ret = null;
            using (var dr = SQLHelper.ExecuteReader(SQLHelper.ConnString, CommandType.Text, CONST_SQL_SELECT, new SqlParameter("@Id", cbrId)))
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
        /// 获取菜品优惠
        /// </summary>
        /// <param name="rankId">警衔ID</param>
        /// <param name="cookbookId">菜品ID</param>
        /// <param name="organizationId">机构ID</param>
        public CookbookPreferentialInRankInfo Select(int rankId, int cookbookId, int organizationId)
        {
            var parameters = new[] { 
                new SqlParameter("@RankId", rankId),
                new SqlParameter("@CookbookId", cookbookId),
                new SqlParameter("@OrganizationId", organizationId),
            };

            CookbookPreferentialInRankInfo ret = null;
            using (var dr = SQLHelper.ExecuteReader(SQLHelper.ConnString, CommandType.Text, CONST_SQL_SELECT_BY_RID_CBID_ORGID, parameters))
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
        /// 获取菜品优惠
        /// </summary>
        /// <param name="rankId">警衔ID</param>
        /// <param name="cookbookId">菜品ID</param>
        /// <param name="organizationId">机构ID</param>
        public IList<CookbookPreferentialInRankInfo> SelectList(string name, int? rankId, int? cookbookId, int? organizationId, string orderString, int pageIndex, int pageSize, out int total)
        {
            var parameters = new[] { 
                new SqlParameter("@Name", name),
                new SqlParameter("@CookbookId", cookbookId),
                new SqlParameter("@RankId", rankId),
                new SqlParameter("@OrganizationId", organizationId),
            };

            string sql = CONST_SQL_SELECT_LIST.Replace("@OrderString", orderString);

            using (var dr = SQLHelper.ExecuteReader(SQLHelper.ConnString, CommandType.Text, sql, parameters))
            {
                return GetModels(dr, pageIndex, pageSize, out total);
            }
        }


        #region Private methods.

        public override CookbookPreferentialInRankInfo BuildModel(IDataReader dr)
        {
            var ret = new CookbookPreferentialInRankInfo
            {
                Id = int.Parse(dr["Id"].ToString()),
                Name = dr["Name"].ToString(),
                Description = dr["Description"].ToString(),

                RandName = dr["RandName"].ToString(),
                RankId = int.Parse(dr["RankId"].ToString()),

                CookbookName = dr["CookbookName"].ToString(),
                CookbookId = int.Parse(dr["CookbookId"].ToString()),

                RealPrice = Convert.ToDecimal(dr["RealPrice"].ToString()),
                SalePrice = Convert.ToDecimal(dr["SalePrice"].ToString()),

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

        private SqlParameter[] GetSqlParameter(CookbookPreferentialInRankInfo cprInfo)
        {
            return new[] {
                new SqlParameter("@Id", cprInfo.Id),
                new SqlParameter("@Name", cprInfo.Name),
                new SqlParameter("@Description", cprInfo.Description),

                new SqlParameter("@RankId", cprInfo.RankId),
                new SqlParameter("@RandName", cprInfo.RandName),

                new SqlParameter("@CookbookId", cprInfo.CookbookId),
                new SqlParameter("@CookbookName", cprInfo.CookbookName),

                new SqlParameter("@RealPrice", cprInfo.RealPrice),
                new SqlParameter("@SalePrice", cprInfo.SalePrice),

                new SqlParameter("@OrganizationId", cprInfo.OrganizationId),
                new SqlParameter("@OrganizationName", cprInfo.OrganizationName),

                new SqlParameter("@DisplayOrder", cprInfo.DisplayOrder),
                new SqlParameter("@CreatedByID", cprInfo.CreatedByID),
                new SqlParameter("@CreatedByName", cprInfo.CreatedByName),
                new SqlParameter("@CreatedDate", cprInfo.CreatedDate),
                new SqlParameter("@LastUpdByID", cprInfo.LastUpdByID),
                new SqlParameter("@LastUpdByName", cprInfo.LastUpdByName),
                new SqlParameter("@LastUpdDate", cprInfo.LastUpdDate),
            };
        }
        #endregion
    }
}
