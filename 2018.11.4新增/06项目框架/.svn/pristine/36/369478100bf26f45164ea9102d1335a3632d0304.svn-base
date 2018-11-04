using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using XinYu.Framework.Library.Utility.DAL;
using XinYu.Framework.Membership.Model;

namespace XinYu.Framework.Membership.DAL.SQLServer
{
    public class RoleDAL : AbstractSQLDAL<RoleInfo>
    {

        #region Const SQL String.

        const string CONST_SQL_INSERT = @"
INSERT INTO [Membership].[Role]
([RoleName], [HeadImage], [PopedomIDs], [Description],
[DisplayOrder],[CreatedByID], [CreatedByName], [CreatedDate], [LastUpdByID], [LastUpdByName], [LastUpdDate])
VALUES
(@RoleName, @HeadImage, @PopedomIDs, @Description,
@DisplayOrder, @CreatedByID, @CreatedByName, @CreatedDate, @LastUpdByID, @LastUpdByName, @LastUpdDate)

SELECT @@IDENTITY";

        const string CONST_SQL_DELETE = "DELETE FROM [Membership].[Role] WHERE ID = @ID";

        const string CONST_SQL_UPDATE = @"
UPDATE [Membership].[Role]
SET [RoleName]     = @RoleName,
    [HeadImage]    = @HeadImage,
    [PopedomIDs]   = @PopedomIDs,
    [Description]  = @Description,
    [DisplayOrder] = @DisplayOrder,
    LastUpdByID    = @LastUpdByID,
    LastUpdByName  = @LastUpdByName,
    LastUpdDate    = @LastUpdDate
WHERE [ID] = @ID";

        const string CONST_SQL_SELECT = "SELECT * FROM [Membership].[Role] WHERE ID = @ID";

        const string CONST_SQL_SELECT_LIST = @"
SELECT * FROM [Membership].[Role] 
WHERE (@RoleName    = ''    OR RoleName   LIKE '%' + @RoleName    +  '%')
  AND (@PopedomIDs  = ''    OR PopedomIDs LIKE '%' + @PopedomIDs +  '%')
@OrderString";

        #endregion

        public void Insert(RoleInfo role)
        {
            var parameters = this.GetSqlParameter(role);

            using (var dr = SQLHelper.ExecuteReader(SQLHelper.ConnString, CommandType.Text, CONST_SQL_INSERT, parameters))
            {
                dr.Read();
                role.ID = Convert.ToInt32(dr[0]);
                dr.Close();
            }
        }

        public void Delete(int roleID)
        {
            SQLHelper.ExecuteNonQuery(SQLHelper.ConnString, CommandType.Text, CONST_SQL_DELETE, new SqlParameter("@ID", roleID));
        }

        public void Update(RoleInfo role)
        {
            var parameters = this.GetSqlParameter(role);

            SQLHelper.ExecuteNonQuery(SQLHelper.ConnString, CommandType.Text, CONST_SQL_UPDATE, parameters);
        }

        public RoleInfo Select(int roleID)
        {
            RoleInfo ret = null;
            using (var dr = SQLHelper.ExecuteReader(SQLHelper.ConnString, CommandType.Text, CONST_SQL_SELECT, new SqlParameter("@ID", roleID)))
            {
                if (dr.Read())
                {
                    ret = this.BuildModel(dr);
                }
                dr.Close();
            }
            return ret;
        }

        public IList<RoleInfo> SelectList(string partRoleName, string partPopedomIDs)
        {
            return SelectList(partRoleName, partPopedomIDs, "ORDER BY DisplayOrder ASC");
        }

        public IList<RoleInfo> SelectList(string partRoleName, string partPopedomIDs, string orderString)
        {
            var parameters = new[] { 
                new SqlParameter("@RoleName", partRoleName), 
                new SqlParameter("@PopedomIDs", partPopedomIDs),
            };

            string sql = CONST_SQL_SELECT_LIST.Replace("@OrderString", orderString);

            using (SqlDataReader dr = SQLHelper.ExecuteReader(SQLHelper.ConnString, CommandType.Text, sql, parameters))
            {
                return GetModels(dr);
            }
        }

        public IList<RoleInfo> SelectList(string partRoleName, string partPopedomIDs, int pageIndex, int pageSize, out int total)
        {
            return this.SelectList(partRoleName, partPopedomIDs, "ORDER BY DisplayOrder ASC",
                pageIndex, pageSize, out total);
        }

        public IList<RoleInfo> SelectList(string partRoleName, string partPopedomIDs, string orderString, int pageIndex, int pageSize, out int total)
        {
            var parameters = new[] { 
                new SqlParameter("@RoleName", partRoleName), 
                new SqlParameter("@PopedomIDs", partPopedomIDs),
            };

            string sql = CONST_SQL_SELECT_LIST.Replace("@OrderString", orderString);

            using (SqlDataReader dr = SQLHelper.ExecuteReader(SQLHelper.ConnString, CommandType.Text, sql, parameters))
            {
                return GetModels(dr, pageIndex, pageSize, out total);
            }
        }

        #region Private methods.

        public override RoleInfo BuildModel(IDataReader dr)
        {
            var role = new RoleInfo
            {
                ID = int.Parse(dr["ID"].ToString()),
                RoleName = dr["RoleName"].ToString(),
                HeadImage = dr["HeadImage"].ToString(),
                PopedomIDs = dr["PopedomIDs"].ToString(),
                Description = dr["Description"].ToString(),
                DisplayOrder = int.Parse(dr["DisplayOrder"].ToString()),
                CreatedByID = int.Parse(dr["CreatedByID"].ToString()),
                CreatedByName = dr["CreatedByName"].ToString(),
                CreatedDate = DateTime.Parse(dr["CreatedDate"].ToString()),
                LastUpdByID = int.Parse(dr["LastUpdByID"].ToString()),
                LastUpdByName = dr["LastUpdByName"].ToString(),
                LastUpdDate = DateTime.Parse(dr["LastUpdDate"].ToString())
            };

            return role;
        }

        private SqlParameter[] GetSqlParameter(RoleInfo role)
        {
            return new[] {
                new SqlParameter("@ID", role.ID),
                new SqlParameter("@RoleName", role.RoleName),
                new SqlParameter("@HeadImage", role.HeadImage),
                new SqlParameter("@PopedomIDs", role.PopedomIDs),
                new SqlParameter("@Description", role.Description),

                new SqlParameter("@DisplayOrder", role.DisplayOrder),
                new SqlParameter("@CreatedByID", role.CreatedByID),
                new SqlParameter("@CreatedByName", role.CreatedByName),
                new SqlParameter("@CreatedDate", role.CreatedDate),
                new SqlParameter("@LastUpdByID", role.LastUpdByID),
                new SqlParameter("@LastUpdByName", role.LastUpdByName),
                new SqlParameter("@LastUpdDate", role.LastUpdDate),
            };
        }
        #endregion
    }
}
