using System;
using System.Data;
using System.Data.SqlClient;
using XinYu.Framework.Library.Utility.DAL;
using XinYu.Framework.OrderMeal.Model;

namespace XinYu.Framework.OrderMeal.DAL.SQLServer
{
   public class PCStaffOrderMealDAL: AbstractSQLDAL<PCStaffOrderMealInfo>
    {

        const string CONST_SQL_INSERT = @"
                    INSERT INTO [Cater].[PCStaffOrderMeal]
                        ([CookbookSetInDateId],[PCStaffId],[CreatedByName], [CreatedByID],  [CreatedDate], [LastUpdByID], [LastUpdByName], [LastUpdDate]
                        [LastUpdDate])
                    VALUES
                        (@CookbookSetInDateId,@PCStaffId,@CreatedByName,@CreatedByID, @CreatedDate, @LastUpdByID, @LastUpdByName,@LastUpdDate
                         )
                    SELECT @@IDENTITY";

        const string CONST_SQL_UPDATE = @"
                    UPDATE [Cater].[PCStaffOrderMeal]
                       SET [CookbookSetInDateId] = @CookbookSetInDateId 
                          ,[PCStaffId]                       = @PCStaffId
                          ,[CreatedByName]            = @CreatedByName
                          ,[CreatedByID]                       = @CreatedByID
                          ,[CreatedDate]                   = @CreatedDate
                          ,[LastUpdByID]                        = @LastUpdByID
                          ,[LastUpdByName]                     = @LastUpdByName

                          ,[LastUpdDate]             = @LastUpdDate
                     WHERE Id = @Id";

        const string CONST_SQL_DELETE = "DELETE FROM [Cater].[PCStaffOrderMeal] WHERE Id = @Id";

        const string CONST_SQL_SELECT = "SELECT * FROM [Cater].[PCStaffOrderMeal] WHERE Id = @Id";

        const string CONST_SQL_SELECT_condition = "SELECT *  FROM [Cater].[PCStaffOrderMeal] WHERE  CookbookSetInDateId=@CookbookSetInDateId AND PCStaffId=@PCStaffId";

        /// <summary>
        /// 添加订单
        /// </summary>
        public void Insert(PCStaffOrderMealInfo csInfo)
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
        public void Delete(int csId)
        {
            SQLHelper.ExecuteNonQuery(SQLHelper.ConnString, CommandType.Text, CONST_SQL_DELETE, new SqlParameter("@Id", csId));
        }

        /// <summary>
        /// 修改订单
        /// </summary>
        public void Update(PCStaffOrderMealInfo csInfo)
        {
            var parameters = this.GetSqlParameter(csInfo);

            SQLHelper.ExecuteNonQuery(SQLHelper.ConnString, CommandType.Text, CONST_SQL_UPDATE, parameters);
        }

        /// <summary>
        /// 获取订单
        /// </summary>
        public PCStaffOrderMealInfo Select(int csId)
        {
            PCStaffOrderMealInfo ret = null;
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
        /// 筛选条件订单
        /// </summary>
        public PCStaffOrderMealInfo SelectCondition(int pcid, int orderid)
        {
            PCStaffOrderMealInfo ret = null;
                var parameters = new[] { 
                new SqlParameter("@CookbookSetInDateId", orderid),
                new SqlParameter("@PCStaffId", pcid)
            };
            using (var dr =SQLHelper.ExecuteReader(SQLHelper.ConnString,
                CommandType.Text,CONST_SQL_SELECT_condition,parameters))
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

        public override PCStaffOrderMealInfo BuildModel(IDataReader dr)
        {
            var ret = new PCStaffOrderMealInfo
            {
                Id = int.Parse(dr["Id"].ToString()),
                CookbookSetInDateId =int.Parse(dr["CookbookSetInDateId"].ToString()),

                PCStaffId = int.Parse(dr["PCStaffId"].ToString()),
                CreatedByName = dr["CreatedByName"].ToString(),
                CreatedByID = int.Parse(dr["CreatedByID"].ToString()),
                CreatedDate = DateTime.Parse(dr["CreatedDate"].ToString()),

                LastUpdByID = int.Parse(dr["LastUpdByID"].ToString()),
                LastUpdByName = dr["LastUpdByName"].ToString(),

                LastUpdDate =  DateTime.Parse(dr["LastUpdDate"].ToString())
            };
            return ret;
        }

        private SqlParameter[] GetSqlParameter(PCStaffOrderMealInfo csInfo)
        {
            return new[] {
                new SqlParameter("@Id", csInfo.Id),
                new SqlParameter("@CookbookSetInDateId", csInfo.CookbookSetInDateId),

                new SqlParameter("@PCStaffId", csInfo.PCStaffId),
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
