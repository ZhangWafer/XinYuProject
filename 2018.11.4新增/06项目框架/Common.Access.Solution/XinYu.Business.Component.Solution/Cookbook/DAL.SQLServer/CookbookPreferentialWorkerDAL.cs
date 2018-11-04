using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XinYu.Framework.Cookbook.Model;
using XinYu.Framework.Library.Utility.DAL;
using XinYu.Framework.Staff;
using XinYu.Framework.Staff.Model;

namespace XinYu.Framework.Cookbook.DAL.SQLServer
{
    public class CookbookPreferentialWorkerDAL : AbstractSQLDAL<CookbookPreferentialWorkerInfo>
    {
        #region Const SQL String.
        const string CONST_SQL_INSERT = @"
                    INSERT INTO [Cater].[CookbookPreferentialWorker]
                        ([Name], [Description],
                        [WorkerStaffEnum],      
                        [CookbookId], [CookbookName],   
                        [SalePrice],[RealPrice], 
                        [OrganizationId], [OrganizationName],
                        [DisplayOrder], [CreatedByID], [CreatedByName], [CreatedDate], [LastUpdByID], [LastUpdByName], [LastUpdDate])
                    VALUES
                        (@Name,@Description,
                        @WorkerStaffEnum,
                        @CookbookId, @CookbookName,
                        @SalePrice, @RealPrice,
                        @OrganizationId, @OrganizationName,
                        @DisplayOrder, @CreatedByID, @CreatedByName, @CreatedDate, @LastUpdByID, @LastUpdByName, @LastUpdDate)
                    SELECT @@IDENTITY";

        const string CONST_SQL_UPDATE = @"
                    UPDATE [Cater].[CookbookPreferentialWorker]
                       SET [Name]                       = @Name
                          ,[Description]                = @Description

                          ,[WorkerStaffEnum]            = @WorkerStaffEnum

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

        const string CONST_SQL_DELETE = "DELETE FROM [Cater].[CookbookPreferentialWorker] WHERE Id = @Id";

        const string CONST_SQL_SELECT = "SELECT * FROM [Cater].[CookbookPreferentialWorker] WHERE Id = @Id";

        const string CONST_SQL_SELECT_BY_WORKERSTAFFENUM_CBID_ORGID = "SELECT * FROM [Cater].[CookbookPreferentialWorker] WHERE WorkerStaffEnum = @WorkerStaffEnum AND CookbookId = @CookbookId AND OrganizationId =@OrganizationId";

        const string CONST_SQL_SELECT_LIST = @"
                    SELECT * FROM [Cater].[CookbookPreferentialWorker] 
                    WHERE (@Name    = ''    OR Name    LIKE '%' + @Name +  '%')
                      AND (@WorkerStaffEnum    = ''    OR WorkerStaffEnum    LIKE '%' + @WorkerStaffEnum +  '%')
                      AND (@CookbookId  IS NULL OR CookbookId  = @CookbookId)
                      AND (@OrganizationId  IS NULL OR OrganizationId  = @OrganizationId)
                    @OrderString";
        #endregion

        /// <summary>
        /// 添加菜品优惠
        /// </summary>
        public void Insert(CookbookPreferentialWorkerInfo cbrInfo)
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
        public void Update(CookbookPreferentialWorkerInfo cbrInfo)
        {
            var parameters = this.GetSqlParameter(cbrInfo);

            SQLHelper.ExecuteNonQuery(SQLHelper.ConnString, CommandType.Text, CONST_SQL_UPDATE, parameters);
        }

        /// <summary>
        /// 获取菜品优惠
        /// </summary>
        public CookbookPreferentialWorkerInfo Select(int cbrId)
        {
            CookbookPreferentialWorkerInfo ret = null;
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
        /// <param name="workerStaffEnum">职工类型</param>
        /// <param name="cookbookId">菜品ID</param>
        /// <param name="organizationId">机构ID</param>
        public CookbookPreferentialWorkerInfo Select(WorkerStaffEnum workerStaffEnum, int cookbookId, int organizationId)
        {
            var parameters = new[] { 
                new SqlParameter("@WorkerStaffEnum", workerStaffEnum.ToString()),
                new SqlParameter("@CookbookId", cookbookId),
                new SqlParameter("@OrganizationId", organizationId),
            };

            CookbookPreferentialWorkerInfo ret = null;
            using (var dr = SQLHelper.ExecuteReader(SQLHelper.ConnString, CommandType.Text, CONST_SQL_SELECT_BY_WORKERSTAFFENUM_CBID_ORGID, parameters))
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
        public IList<CookbookPreferentialWorkerInfo> SelectList(string name, WorkerStaffEnum? workerStaffEnum, int? cookbookId, int? organizationId, string orderString, int pageIndex, int pageSize, out int total)
        {
            var parameters = new[] { 
                new SqlParameter("@Name", name),
                new SqlParameter("@CookbookId", cookbookId),
                new SqlParameter("@WorkerStaffEnum", workerStaffEnum.ToString()),
                new SqlParameter("@OrganizationId", organizationId),
            };

            string sql = CONST_SQL_SELECT_LIST.Replace("@OrderString", orderString);

            using (var dr = SQLHelper.ExecuteReader(SQLHelper.ConnString, CommandType.Text, sql, parameters))
            {
                return GetModels(dr, pageIndex, pageSize, out total);
            }
        }

        #region Private methods.

        public override CookbookPreferentialWorkerInfo BuildModel(IDataReader dr)
        {
            var ret = new CookbookPreferentialWorkerInfo
            {
                Id = int.Parse(dr["Id"].ToString()),
                Name = dr["Name"].ToString(),
                Description = dr["Description"].ToString(),

                WorkerStaffEnum = (WorkerStaffEnum)Enum.Parse(typeof(WorkerStaffEnum), dr["WorkerStaffEnum"].ToString()),

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

        private SqlParameter[] GetSqlParameter(CookbookPreferentialWorkerInfo cprInfo)
        {
            return new[] {
                new SqlParameter("@Id", cprInfo.Id),
                new SqlParameter("@Name", cprInfo.Name),
                new SqlParameter("@Description", cprInfo.Description),

                new SqlParameter("@WorkerStaffEnum", cprInfo.WorkerStaffEnum.ToString()),

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
