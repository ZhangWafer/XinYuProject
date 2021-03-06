﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using XinYu.Framework.Library.Utility.DAL;
using XinYu.Framework.Organization.Model;

namespace XinYu.Framework.Organization.DAL.SQLServer
{
    /// <summary>
    /// 机构管理数据访问类
    /// </summary>
    public class OrganizationDAL : AbstractSQLDAL<OrganizationInfo>
    {
        #region Const SQL String.
        const string CONST_SQL_INSERT = @"
                    INSERT INTO [Cater].[Organization]
                        ([Name], [Description],
                        [DisplayOrder], [CreatedByID], [CreatedByName], [CreatedDate], [LastUpdByID], [LastUpdByName], [LastUpdDate])
                    VALUES
                        (@Name,@Description,
                        @DisplayOrder, @CreatedByID, @CreatedByName, @CreatedDate, @LastUpdByID, @LastUpdByName, @LastUpdDate)
                    SELECT @@IDENTITY";

        const string CONST_SQL_UPDATE = @"
                    UPDATE [Cater].[Organization]
                       SET [Name]                   = @Name
                          ,[Description]                = @Description
                          ,[DisplayOrder]               = @DisplayOrder
                          ,[LastUpdByID]                = @LastUpdByID
                          ,[LastUpdByName]              = @LastUpdByName
                          ,[LastUpdDate]                = @LastUpdDate
                     WHERE ID = @ID";

        const string CONST_SQL_DELETE = "DELETE FROM [Cater].[Organization] WHERE Id = @Id";

        const string CONST_SQL_SELECT = "SELECT * FROM [Cater].[Organization] WHERE Id = @Id";

        const string CONST_SQL_SELECT_LIST = @"
                    SELECT * FROM [Cater].[Organization] 
                    WHERE (@Name    = ''    OR Name    LIKE '%' + @Name +  '%')
                    @OrderString";

        #endregion

        /// <summary>
        /// 添加机构
        /// </summary>
        public void Insert(OrganizationInfo org)
        {
            var parameters = this.GetSqlParameter(org);

            using (var dr = SQLHelper.ExecuteReader(SQLHelper.ConnString, CommandType.Text, CONST_SQL_INSERT, parameters))
            {
                dr.Read();
                org.Id = Convert.ToInt32(dr[0]);
                dr.Close();
            }
        }

        /// <summary>
        /// 移除机构
        /// </summary>
        public void Delete(int orgId)
        {
            SQLHelper.ExecuteNonQuery(SQLHelper.ConnString, CommandType.Text, CONST_SQL_DELETE, new SqlParameter("@ID", orgId));
        }

        /// <summary>
        /// 修改机构
        /// </summary>
        public void Update(OrganizationInfo org)
        {
            var parameters = this.GetSqlParameter(org);

            SQLHelper.ExecuteNonQuery(SQLHelper.ConnString, CommandType.Text, CONST_SQL_UPDATE, parameters);
        }

        /// <summary>
        /// 获取机构记录
        /// </summary>
        public OrganizationInfo Select(int orgId)
        {
            OrganizationInfo ret = null;
            using (var dr = SQLHelper.ExecuteReader(SQLHelper.ConnString, CommandType.Text, CONST_SQL_SELECT, new SqlParameter("@Id", orgId)))
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
        /// 获取机构列表
        /// </summary>
        /// <param name="name">机构名称</param>
        /// <param name="orderString">SQL排序</param>
        public IList<OrganizationInfo> SelectList(string name, string orderString)
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

        public override OrganizationInfo BuildModel(IDataReader dr)
        {
            var ret = new OrganizationInfo
            {
                Id = int.Parse(dr["Id"].ToString()),
                Name = dr["Name"].ToString(),
                Description = dr["Description"].ToString(),

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

        private SqlParameter[] GetSqlParameter(OrganizationInfo org)
        {
            return new[] {
                new SqlParameter("@ID", org.Id),
                new SqlParameter("@Name", org.Name),
                new SqlParameter("@Description", org.Description),

                new SqlParameter("@DisplayOrder", org.DisplayOrder),
                new SqlParameter("@CreatedByID", org.CreatedByID),
                new SqlParameter("@CreatedByName", org.CreatedByName),
                new SqlParameter("@CreatedDate", org.CreatedDate),
                new SqlParameter("@LastUpdByID", org.LastUpdByID),
                new SqlParameter("@LastUpdByName", org.LastUpdByName),
                new SqlParameter("@LastUpdDate", org.LastUpdDate),
            };
        }

        #endregion
    }
}
