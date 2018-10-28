﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using XinYu.Framework.Cookbook.Model;
using XinYu.Framework.Library.Utility.DAL;

namespace XinYu.Framework.Cookbook.DAL.SQLServer
{
    /// <summary>
    /// 排餐数据访问类
    /// </summary>
    public class CookbookSetInDateDAL : AbstractSQLDAL<CookbookSetInDateInfo>
    {
        #region Const SQL String.
        const string CONST_SQL_INSERT = @"
                    INSERT INTO [Cater].[CookbookSetInDate]
                        ([CafeteriaId], [CafeteriaName], 
                        [ChooseDate], [CookbookEnum], 
                        [OrganizationId], [OrganizationName],[Price],
                        [DisplayOrder],
                        [CreatedByID], [CreatedByName], [CreatedDate], [LastUpdByID], [LastUpdByName], [LastUpdDate])
                    VALUES
                        (@CafeteriaId, @CafeteriaName,
                        @ChooseDate,@CookbookEnum,
                        @OrganizationId, @OrganizationName,@Price,
                        @DisplayOrder,
                        @CreatedByID, @CreatedByName, @CreatedDate, @LastUpdByID, @LastUpdByName, @LastUpdDate)
                    SELECT @@IDENTITY";

        const string CONST_SQL_UPDATE = @"
                    UPDATE [Cater].[CookbookSetInDate]
                       SET [CafeteriaId]                = @CafeteriaId
                          ,[CafeteriaName]              = @CafeteriaName
                          ,[ChooseDate]                 = @ChooseDate
                          ,[OrganizationId]             = @OrganizationId
                          ,[OrganizationName]           = @OrganizationName
                          ,[Price]                      = @Price
                          ,[DisplayOrder]               = @DisplayOrder
                          ,[CookbookEnum]               = @CookbookEnum
                          ,[CookbookName]               = @CookbookName
                          ,[LastUpdByID]                = @LastUpdByID
                          ,[LastUpdByName]              = @LastUpdByName
                          ,[LastUpdDate]                = @LastUpdDate
                     WHERE ID = @ID";

        const string CONST_SQL_DELETE = "DELETE FROM [Cater].[CookbookSetInDate] WHERE Id = @Id";

        const string CONST_SQL_SELECT = "SELECT * FROM [Cater].[CookbookSetInDate] WHERE Id = @Id";

        private const string CONST_SQL_SELECT_LIST = @"
                    SELECT * FROM [Cater].[CookbookSetInDate] 
                    WHERE (@CookbookEnum    = ''        OR CookbookEnum     = @CookbookEnum)
                      AND (@ChooseDate      IS NULL     OR ChooseDate = @ChooseDate)
                      AND (@OrganizationId  IS NULL     OR OrganizationId  = @OrganizationId)
                      AND (@CafeteriaId     IS NULL     OR CafeteriaId  = @CafeteriaId) ORDER BY ID DESC";

        #endregion

        #region Private methods.

        /// <summary>
        /// 添加排餐
        /// </summary>
        public void Insert(CookbookSetInDateInfo cbInfo)
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
        /// 移除排餐
        /// </summary>
        public void Delete(int id)
        {
            SQLHelper.ExecuteNonQuery(SQLHelper.ConnString, CommandType.Text, CONST_SQL_DELETE, new SqlParameter("@Id", id));
        }

        /// <summary>
        /// 修改排餐
        /// </summary>
        public void Update(CookbookSetInDateInfo cbInfo)
        {
            var parameters = this.GetSqlParameter(cbInfo);

            SQLHelper.ExecuteNonQuery(SQLHelper.ConnString, CommandType.Text, CONST_SQL_UPDATE, parameters);
        }

        /// <summary>
        /// 获取排餐
        /// </summary>
        public CookbookSetInDateInfo Select(int id)
        {
            CookbookSetInDateInfo ret = null;
            using (var dr = SQLHelper.ExecuteReader(SQLHelper.ConnString, CommandType.Text, CONST_SQL_SELECT, new SqlParameter("@Id", id)))
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
        /// 获取排餐列表
        /// </summary>
        /// <param name="ce">用餐时段（早/中/晚）</param>
        /// <param name="chooseDate">排餐日期</param>
        /// <param name="organizationId">机构ID</param>
        /// <param name="cafeteriaId">食堂ID</param>
        public IList<CookbookSetInDateInfo> SelectList(CookbookEnum? ce, DateTime? chooseDate, int? organizationId, int? cafeteriaId)
        {
            var parameters = new[] {
                new SqlParameter("@CookbookEnum", ce.ToString()),
                new SqlParameter("@ChooseDate", chooseDate),
                new SqlParameter("@OrganizationId", organizationId),
                new SqlParameter("@CafeteriaId", cafeteriaId),
            };

            using (var dr = SQLHelper.ExecuteReader(SQLHelper.ConnString, CommandType.Text, CONST_SQL_SELECT_LIST, parameters))
            {
                return GetModels(dr);
            }
        }

        /// <summary>
        /// 获取排餐列表
        /// </summary>
        /// <param name="ce">用餐时段（早/中/晚）</param>
        /// <param name="chooseDate">排餐日期</param>
        /// <param name="organizationId">机构ID</param>
        /// <param name="cafeteriaId">食堂ID</param>
        public IList<CookbookSetInDateInfo> SelectList(CookbookEnum? ce, DateTime? chooseDate, int? organizationId, int? cafeteriaId, int pageIndex, int pageSize, out int total)
        {
            var parameters = new[] {
                new SqlParameter("@CookbookEnum", ce.ToString()),
                new SqlParameter("@ChooseDate", chooseDate),
                new SqlParameter("@OrganizationId", organizationId),
                new SqlParameter("@CafeteriaId", cafeteriaId),
            };

            using (var dr = SQLHelper.ExecuteReader(SQLHelper.ConnString, CommandType.Text, CONST_SQL_SELECT_LIST, parameters))
            {
                return GetModels(dr, pageIndex, pageSize, out total);
            }
        }


        public override CookbookSetInDateInfo BuildModel(IDataReader dr)
        {
            var ret = new CookbookSetInDateInfo
            {
                Id = int.Parse(dr["Id"].ToString()),

                CafeteriaId = int.Parse(dr["CafeteriaId"].ToString()),
                CafeteriaName = dr["CafeteriaName"].ToString(),
                ChooseDate = Convert.ToDateTime(dr["ChooseDate"].ToString()),
                CookbookEnum = (CookbookEnum)Enum.Parse(typeof(CookbookEnum), dr["CookbookEnum"].ToString()),
                OrganizationId = int.Parse(dr["OrganizationId"].ToString()),
                OrganizationName = dr["OrganizationName"].ToString(),

                Price = dr["Price"] == DBNull.Value
                 ? (decimal?)null : Convert.ToDecimal(dr["Price"].ToString()),

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

        private SqlParameter[] GetSqlParameter(CookbookSetInDateInfo csddInfo)
        {
            return new[] {
                new SqlParameter("@Id", csddInfo.Id),

                new SqlParameter("@CafeteriaId", csddInfo.CafeteriaId),
                new SqlParameter("@CafeteriaName", csddInfo.CafeteriaName),
                new SqlParameter("@ChooseDate", csddInfo.ChooseDate),
                new SqlParameter("@CookbookEnum", csddInfo.CookbookEnum.ToString()),
                new SqlParameter("@OrganizationId", csddInfo.OrganizationId),
                new SqlParameter("@OrganizationName", csddInfo.OrganizationName),

                new SqlParameter("@Price", csddInfo.Price),

                new SqlParameter("@DisplayOrder", csddInfo.DisplayOrder),
                new SqlParameter("@CreatedByID", csddInfo.CreatedByID),
                new SqlParameter("@CreatedByName", csddInfo.CreatedByName),
                new SqlParameter("@CreatedDate", csddInfo.CreatedDate),
                new SqlParameter("@LastUpdByID", csddInfo.LastUpdByID),
                new SqlParameter("@LastUpdByName", csddInfo.LastUpdByName),
                new SqlParameter("@LastUpdDate", csddInfo.LastUpdDate),
            };
        }
        #endregion
    }
}
