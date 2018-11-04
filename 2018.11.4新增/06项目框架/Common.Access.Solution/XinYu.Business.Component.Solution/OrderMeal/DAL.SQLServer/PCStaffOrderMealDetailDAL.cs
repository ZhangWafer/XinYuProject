using System;
using System.Data;
using System.Data.SqlClient;
using XinYu.Framework.Library.Utility.DAL;
using XinYu.Framework.OrderMeal.Model;

namespace XinYu.Framework.OrderMeal.DAL.SQLServer
{
      public  class PCStaffOrderMealDetailDAL
    {
        const string CONST_SQL_INSERT = @"
                    INSERT INTO [Cater].[PCStaffOrderMealDetail]
                        ([PCStaffOrderMealId],[CookbookId],[CookBookName], [CreatedByName],  [CreatedByID], [CreatedDate], [LastUpdByID], [LastUpdByName],[LastUpdDate]
                        [LastUpdDate])
                    VALUES
                        (@PCStaffOrderMealId,@CookbookId,@CookBookName,@CreatedByName, @CreatedByID, @CreatedDate, @LastUpdByID,@LastUpdByName,@LastUpdDate
                         )
                    SELECT @@IDENTITY";

        const string CONST_SQL_UPDATE = @"
                    UPDATE [Cater].[PCStaffOrderMealDetail]
                       SET [PCStaffOrderMealId] = @PCStaffOrderMealId 
                          ,[CookbookId]                       = @CookbookId
                          ,[CookBookName]            = @CookBookName
                          ,[CreatedByName]                       = @CreatedByName
                          ,[CreatedByID]                   = @CreatedByID
                          ,[CreatedDate]                        = @CreatedDate
                          ,[LastUpdByID]                     = @LastUpdByID
                          ,[LastUpdByName]              =@LastUpdByName
                          ,[LastUpdDate]             = @LastUpdDate
                     WHERE Id = @Id";

        const string CONST_SQL_DELETE = "DELETE FROM [Cater].[PCStaffOrderMealDetail] WHERE PCStaffOrderMealId = @PCStaffOrderMealId";

        const string CONST_SQL_SELECT = "SELECT * FROM [Cater].[PCStaffOrderMealDetail] WHERE PCStaffOrderMealId = @PCStaffOrderMealId";


        /// <summary>
        /// 添加订单
        /// </summary>
        public void Insert(PCStaffOrderMealDetailInfo csInfo)
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
            SQLHelper.ExecuteNonQuery(SQLHelper.ConnString, CommandType.Text, CONST_SQL_DELETE, new SqlParameter("@PCStaffOrderMealId", pcid));
        }

        /// <summary>
        /// 修改订单
        /// </summary>
        public void Update(PCStaffOrderMealDetailInfo csInfo)
        {
            var parameters = this.GetSqlParameter(csInfo);

            SQLHelper.ExecuteNonQuery(SQLHelper.ConnString, CommandType.Text, CONST_SQL_UPDATE, parameters);
        }

        /// <summary>
        /// 获取订单
        /// </summary>
        public PCStaffOrderMealDetailInfo Select(int csId)
        {
            PCStaffOrderMealDetailInfo ret = null;
            using (var dr = SQLHelper.ExecuteReader(SQLHelper.ConnString, CommandType.Text, CONST_SQL_SELECT, new SqlParameter("@PCStaffOrderMealId", csId)))
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

        public override PCStaffOrderMealDetailInfo BuildModel(IDataReader dr)
        {
            var ret = new PCStaffOrderMealDetailInfo
            {
                Id = int.Parse(dr["Id"].ToString()),
                PCStaffOrderMealId = int.Parse(dr["PCStaffOrderMealId"].ToString()),
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

        private SqlParameter[] GetSqlParameter(PCStaffOrderMealDetailInfo csInfo)
        {
            return new[] {
                new SqlParameter("@Id", csInfo.Id),
                new SqlParameter("@PCStaffOrderMealId", csInfo.PCStaffOrderMealId),

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
