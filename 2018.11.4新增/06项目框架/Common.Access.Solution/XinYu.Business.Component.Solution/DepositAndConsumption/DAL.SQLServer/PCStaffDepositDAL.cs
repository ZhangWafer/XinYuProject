using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using XinYu.Framework.DepositAndConsumption.Model;
using XinYu.Framework.Library.Utility.DAL;

namespace XinYu.Framework.DepositAndConsumption.DAL.SQLServer
{
    public class PCStaffDepositDAL : AbstractSQLDAL<PCStaffDepositInfo>
    {
        #region Const SQL String.
        const string CONST_SQL_INSERT = @"
                    INSERT INTO [Cater].[PCStaffDepositInfo]
                        ([PCStaffId], [PCStaffName],
                        [PCStaffDepositEnum], [Amount], [AmountDate],
                        [CreatedByID], [CreatedByName], [CreatedDate], [LastUpdByID], [LastUpdByName], [LastUpdDate])
                    VALUES
                        (@PCStaffId, @PCStaffName,
                         @PCStaffDepositEnum, @Amount, @AmountDate,
                         @CreatedByID, @CreatedByName, @CreatedDate, @LastUpdByID, @LastUpdByName, @LastUpdDate)
                    SELECT @@IDENTITY";

        const string CONST_SQL_UPDATE = @"
                    UPDATE [Cater].[PCStaffDepositInfo]
                       SET [PCStaffId]                       = @PCStaffId
                          ,[PCStaffName]                     = @PCStaffName

                          ,[PCStaffDepositEnum]              = @PCStaffDepositEnum
                          ,[Amount]                          = @Amount
                          ,[AmountDate]                      = @AmountDate
                          ,[DisplayOrder]                    = @DisplayOrder
                          ,[LastUpdByID]                     = @LastUpdByID
                          ,[LastUpdByName]                   = @LastUpdByName
                          ,[LastUpdDate]                     = @LastUpdDate
                     WHERE ID = @ID";

        const string CONST_SQL_DELETE = "DELETE FROM [Cater].[PCStaffDepositInfo] WHERE Id = @Id";

        const string CONST_SQL_SELECT = "SELECT * FROM [Cater].[PCStaffDepositInfo] WHERE Id = @Id";

        const string CONST_SQL_SELECT_LIST = @"
                    SELECT * FROM [Cater].[PCStaffDepositInfo] 
                    WHERE 
                      AND (@PCStaffId  IS NULL OR PCStaffId  = @PCStaffId )
                    @OrderString";
        #endregion


        public void Insert(PCStaffDepositInfo pInfo)
        {
            var parameters = GetSqlParameter(pInfo);

            using (var dr = SQLHelper.ExecuteReader(SQLHelper.ConnString, CommandType.Text, CONST_SQL_INSERT, parameters))
            {
                dr.Read();
                pInfo.Id = Convert.ToInt32(dr[0]);
                dr.Close();
            }
        }

        public void Delete(int id)
        {
            SQLHelper.ExecuteNonQuery(SQLHelper.ConnString, CommandType.Text, CONST_SQL_DELETE, new SqlParameter("@Id", id));
        }

        public void Update(PCStaffDepositInfo pInfo)
        {
            var parameters = this.GetSqlParameter(pInfo);

            SQLHelper.ExecuteNonQuery(SQLHelper.ConnString, CommandType.Text, CONST_SQL_UPDATE, parameters);
        }

        public PCStaffDepositInfo Select(int id)
        {
            PCStaffDepositInfo ret = null;
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

        public IList<PCStaffDepositInfo> SelectList(int? pcStaffId, string orderString, int pageIndex, int pageSize, out int total)
        {
            var parameters = new[] { 
                new SqlParameter("@PCStaffId", pcStaffId)
            };

            string sql = CONST_SQL_SELECT_LIST.Replace("@OrderString", orderString);

            using (var dr = SQLHelper.ExecuteReader(SQLHelper.ConnString, CommandType.Text, sql, parameters))
            {
                return GetModels(dr, pageIndex, pageSize, out total);
            }
        }

        #region Private methods.

        public override PCStaffDepositInfo BuildModel(IDataReader dr)
        {
            var ret = new PCStaffDepositInfo
            {
                Id = int.Parse(dr["Id"].ToString()),

                PCStaffId = int.Parse(dr["PCStaffId"].ToString()),
                PCStaffName = dr["PCStaffName"].ToString(),
                PCStaffDepositEnum = (PCStaffDepositEnum)Enum.Parse(typeof(PCStaffDepositEnum), dr["PCStaffDepositEnum"].ToString()),

                Amount = Convert.ToDecimal(dr["Amount"].ToString()),
                AmountDate = Convert.ToDateTime(dr["AmountDate"].ToString()),

                CreatedByID = int.Parse(dr["CreatedByID"].ToString()),
                CreatedByName = dr["CreatedByName"].ToString(),
                CreatedDate = DateTime.Parse(dr["CreatedDate"].ToString()),
                LastUpdByID = int.Parse(dr["LastUpdByID"].ToString()),
                LastUpdByName = dr["LastUpdByName"].ToString(),
                LastUpdDate = DateTime.Parse(dr["LastUpdDate"].ToString())
            };
            return ret;
        }

        private SqlParameter[] GetSqlParameter(PCStaffDepositInfo pcStaffDepositInfo)
        {
            return new[] {
                new SqlParameter("@Id", pcStaffDepositInfo.Id),

                new SqlParameter("@PCStaffId", pcStaffDepositInfo.PCStaffId),
                new SqlParameter("@PCStaffName", pcStaffDepositInfo.PCStaffName),

                new SqlParameter("@PCStaffDepositEnum", pcStaffDepositInfo.PCStaffDepositEnum),

                new SqlParameter("@Amount", pcStaffDepositInfo.Amount),
                new SqlParameter("@AmountDate", pcStaffDepositInfo.AmountDate),

                new SqlParameter("@CreatedByID", pcStaffDepositInfo.CreatedByID),
                new SqlParameter("@CreatedByName", pcStaffDepositInfo.CreatedByName),
                new SqlParameter("@CreatedDate", pcStaffDepositInfo.CreatedDate),
                new SqlParameter("@LastUpdByID", pcStaffDepositInfo.LastUpdByID),
                new SqlParameter("@LastUpdByName", pcStaffDepositInfo.LastUpdByName),
                new SqlParameter("@LastUpdDate", pcStaffDepositInfo.LastUpdDate),
            };
        }
        #endregion
    }
}
