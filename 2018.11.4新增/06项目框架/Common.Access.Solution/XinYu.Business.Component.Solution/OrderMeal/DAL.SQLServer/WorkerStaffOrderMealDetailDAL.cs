using System;
using System.Data;
using System.Data.SqlClient;
using XinYu.Framework.Library.Utility.DAL;
using XinYu.Framework.OrderMeal.Model;

namespace XinYu.Framework.OrderMeal.DAL.SQLServer
{
     public  class WorkerStaffOrderMealDetailDAL
    {
        const string CONST_SQL_INSERT = @"
                    INSERT INTO [Cater].[WorkerStaffOrderMealDetail]
                        ([WorkerStaffOrderMealId],[CookbookId],[CookBookName], [CreatedByName],  [CreatedByID], [CreatedDate], [LastUpdByID], [LastUpdByName],[LastUpdDate]
                        [LastUpdDate])
                    VALUES
                        (@WorkerStaffOrderMealId,@CookbookId,@CookBookName,@CreatedByName, @CreatedByID, @CreatedDate, @LastUpdByID,@LastUpdByName,@LastUpdDate
                         )
                    SELECT @@IDENTITY";

        const string CONST_SQL_UPDATE = @"
                    UPDATE [Cater].[WorkerStaffOrderMealDetail]
                       SET [WorkerStaffOrderMealId] = @WorkerStaffOrderMealId 
                          ,[CookbookId]                       = @CookbookId
                          ,[CookBookName]            = @CookBookName
                          ,[CreatedByName]                       = @CreatedByName
                          ,[CreatedByID]                   = @CreatedByID
                          ,[CreatedDate]                        = @CreatedDate
                          ,[LastUpdByID]                     = @LastUpdByID
                          ,[LastUpdByName]              =@LastUpdByName
                          ,[LastUpdDate]             = @LastUpdDate
                     WHERE Id = @Id";

        const string CONST_SQL_DELETE = "DELETE FROM [Cater].[WorkerStaffOrderMealDetail] WHERE WorkerStaffOrderMealId = @WorkerStaffOrderMealId";

        const string CONST_SQL_SELECT = "SELECT * FROM [Cater].[WorkerStaffOrderMealDetail] WHERE WorkerStaffOrderMealId = @WorkerStaffOrderMealId";


        /// <summary>
        /// 添加订单
        /// </summary>
        public void Insert(WorkerStaffOrderMealDetailInfo csInfo)
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
        /// 移除订单
        /// </summary>
        public void Delete(int pcid)
        {
            SQLHelper.ExecuteNonQuery(SQLHelper.ConnString, CommandType.Text, CONST_SQL_DELETE, new SqlParameter("@WorkerStaffOrderMealId", pcid));
        }


        /// <summary>
        /// 修改订单
        /// </summary>
        public void Update(WorkerStaffOrderMealDetailInfo csInfo)
        {
            var parameters = this.GetSqlParameter(csInfo);

            SQLHelper.ExecuteNonQuery(SQLHelper.ConnString, CommandType.Text, CONST_SQL_UPDATE, parameters);
        }

        /// <summary>
        /// 获取订单
        /// </summary>
        public WorkerStaffOrderMealDetailInfo Select(int csId)
        {
            WorkerStaffOrderMealDetailInfo ret = null;
            using (var dr = SQLHelper.ExecuteReader(SQLHelper.ConnString, CommandType.Text, CONST_SQL_SELECT, new SqlParameter("@WorkerStaffOrderMealId", csId)))
            {
                if (dr.Read())
                {
                    ret = this.BuildModel(dr);
                }
                dr.Close();
            }
            return ret;
        }



        #region Private methods.

        public override WorkerStaffOrderMealDetailInfo BuildModel(IDataReader dr)
        {
            var ret = new WorkerStaffOrderMealDetailInfo
            {
                Id = int.Parse(dr["Id"].ToString()),
                WorkerStaffOrderMealId = int.Parse(dr["WorkerStaffOrderMealId"].ToString()),
                CookbookId = int.Parse(dr["CookbookId"].ToString()),
                CookbookName = dr["CookbookName"].ToString(),
                CreatedByName = dr["CreatedByName"].ToString(),
                CreatedByID = int.Parse(dr["CreatedByID"].ToString()),
                CreatedDate = DateTime.Parse(dr["CreatedDate"].ToString()),
                LastUpdByID = int.Parse(dr["LastUpdByID"].ToString()),
                LastUpdByName = dr["LastUpdByName"].ToString(),
                LastUpdDate = DateTime.Parse(dr["LastUpdDate"].ToString())
            };
            return ret;
        }

        private SqlParameter[] GetSqlParameter(WorkerStaffOrderMealDetailInfo csInfo)
        {
            return new[] {
                new SqlParameter("@Id", csInfo.Id),
                new SqlParameter("@WorkerStaffOrderMealId", csInfo.WorkerStaffOrderMealId),

                new SqlParameter("@CookbookId", csInfo.CookbookId),
                new SqlParameter("@CookbookName", csInfo.CookbookName),
                new SqlParameter("@CreatedByName", csInfo.CreatedByName),
                new SqlParameter("@CreatedByID", csInfo.CreatedByID),

                new SqlParameter("@CreatedDate", csInfo.CreatedDate),
                new SqlParameter("@LastUpdByID", csInfo.LastUpdByID),

                new SqlParameter("@LastUpdByName", csInfo.LastUpdByName),
                 new SqlParameter("@LastUpdDate", csInfo.LastUpdDate)
            };
        }
        #endregion
    }
}
