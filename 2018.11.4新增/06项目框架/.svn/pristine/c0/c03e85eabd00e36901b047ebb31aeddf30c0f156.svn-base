using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using XinYu.Framework.Library.Utility.DAL;
using XinYu.Framework.Membership.Model;

namespace XinYu.Framework.Membership.DAL.SQLServer
{

    public class ModuleDAL : AbstractSQLDAL<ModuleInfo>
    {

        #region Const SQL String.

        const string CONST_SQL_INSERT = @"
INSERT INTO [Membership].[Module]
([RootID], [ParentID], [Name], [Icon], [URL], [IsMenu], [IsFloder], [IsPopedom], 
[DisplayOrder],[CreatedByID], [CreatedByName], [CreatedDate], [LastUpdByID], [LastUpdByName], [LastUpdDate])
VALUES
(@RootID, @ParentID, @Name, @Icon, @Url, @IsMenu, @IsFloder, @IsPopedom,
@DisplayOrder, @CreatedByID, @CreatedByName, @CreatedDate, @LastUpdByID, @LastUpdByName, @LastUpdDate)

SELECT @@IDENTITY";

        const string CONST_SQL_DELETE = "DELETE FROM [Membership].[Module] WHERE ID = @ID";

        const string CONST_SQL_UPDATE = @"
UPDATE [Membership].[Module]
SET [RootID]       = @RootID,
    [ParentID]     = @ParentID,
    [Name]         = @Name,
    [Icon]         = @Icon,
    [Url]          = @Url,
    [IsMenu]       = @IsMenu,
    [IsFloder]     = @IsFloder,
    [IsPopedom]    = @IsPopedom, 
    [DisplayOrder] = @DisplayOrder,
    LastUpdByID    = @LastUpdByID,
    LastUpdByName  = @LastUpdByName,
    LastUpdDate    = @LastUpdDate
WHERE ID = @ID";

        const string CONST_SQL_SELECT = "SELECT * FROM [Membership].[Module] WHERE ID = @ID";

        const string CONST_SQL_SELECT_LIST = @"
SELECT * FROM [Membership].[Module]
WHERE (@RootID    IS NULL OR RootID    = @RootID)
  AND (@ParentID  IS NULL OR ParentID  = @ParentID)
  AND (@Url       =  ''   OR Url       LIKE '%' + @Url + '%')
  AND (@IsMenu    IS NULL OR IsMenu    = @IsMenu)
  AND (@IsFloder  IS NULL OR IsFloder  = @IsFloder)
  AND (@IsPopedom IS NULL OR IsPopedom = @IsPopedom)
@OrderString";

        #endregion


        public void Insert(ModuleInfo module)
        {
            var parameters = this.GetSqlParameter(module);

            using (var dr = SQLHelper.ExecuteReader(SQLHelper.ConnString, CommandType.Text, CONST_SQL_INSERT, parameters))
            {
                dr.Read();
                module.ID = Convert.ToInt32(dr[0]);
                dr.Close();
            }
        }

        public void Delete(int moduleID)
        {
            SQLHelper.ExecuteNonQuery(SQLHelper.ConnString, CommandType.Text, CONST_SQL_DELETE, new SqlParameter("@ID", moduleID));
        }

        public void Update(ModuleInfo module)
        {
            var parameters = GetSqlParameter(module);

            SQLHelper.ExecuteNonQuery(SQLHelper.ConnString, CommandType.Text, CONST_SQL_UPDATE, parameters);
        }

        public ModuleInfo Select(int moduleID)
        {
            ModuleInfo ret = null;
            using (var dr = SQLHelper.ExecuteReader(SQLHelper.ConnString, CommandType.Text, CONST_SQL_SELECT, new SqlParameter("@ID", moduleID)))
            {
                if (dr.Read())
                {
                    ret = BuildModel(dr);
                }
                dr.Close();
            }
            return ret;
        }

        public IList<ModuleInfo> SelectList(int? rootID, int? parentID, string url, bool? isMenu, bool? isFloder, bool? isPopedom)
        {
            return SelectList(rootID, parentID, url, isMenu, isFloder, isPopedom, "ORDER BY DisplayOrder ASC");
        }

        public IList<ModuleInfo> SelectList(int? rootID, int? parentID, string url, bool? isMenu, bool? isFloder, bool? isPopedom, string orderString)
        {
            var parameters = new[] {
                new SqlParameter("@RootID", rootID),
                new SqlParameter("@ParentID", parentID),
                new SqlParameter("@Url", url),
                new SqlParameter("@IsMenu", isMenu),
                new SqlParameter("@IsFloder", isFloder),
                new SqlParameter("@IsPopedom", isPopedom)
            };

            string sql = CONST_SQL_SELECT_LIST.Replace("@OrderString", orderString);

            using (var dr = SQLHelper.ExecuteReader(SQLHelper.ConnString, CommandType.Text, sql, parameters))
            {
                return GetModels(dr);
            }
        }

        public IList<ModuleInfo> SelectList(int? rootID, int? parentID, string url, bool? isMenu, bool? isFloder, bool? isPopedom, int pageIndex, int pageSize, out int total)
        {
            return SelectList(rootID, parentID, url, isMenu, isFloder, isPopedom, "ORDER BY DisplayOrder ASC", pageIndex, pageSize, out total);
        }

        public IList<ModuleInfo> SelectList(int? rootID, int? parentID, string url, bool? isMenu, bool? isFloder, bool? isPopedom, string orderString, int pageIndex, int pageSize, out int total)
        {
            var parameters = new[] {
                new SqlParameter("@RootID", rootID),
                new SqlParameter("@ParentID", parentID),
                new SqlParameter("@Url", url),
                new SqlParameter("@IsMenu", isMenu),
                new SqlParameter("@IsFloder", isFloder),
                new SqlParameter("@IsPopedom", isPopedom)
            };

            string sql = CONST_SQL_SELECT_LIST.Replace("@OrderString", orderString);

            using (var dr = SQLHelper.ExecuteReader(SQLHelper.ConnString, CommandType.Text, sql, parameters))
            {
                return GetModels(dr, pageIndex, pageSize, out total);
            }
        }

        #region Private Methods.

        public override ModuleInfo BuildModel(IDataReader dr)
        {
            var module = new ModuleInfo { ID = int.Parse(dr["ID"].ToString()) };

            if (dr["RootID"] != DBNull.Value) module.RootID = int.Parse(dr["RootID"].ToString());
            if (dr["ParentID"] != DBNull.Value) module.ParentID = int.Parse(dr["ParentID"].ToString());

            module.Name = dr["Name"].ToString();
            module.Icon = dr["Icon"].ToString();
            module.Url = dr["Url"].ToString();

            module.IsMenu = bool.Parse(dr["IsMenu"].ToString());
            module.IsFloder = bool.Parse(dr["IsFloder"].ToString());
            module.IsPopedom = bool.Parse(dr["IsPopedom"].ToString());

            module.DisplayOrder = int.Parse(dr["DisplayOrder"].ToString());
            module.CreatedByID = int.Parse(dr["CreatedByID"].ToString());
            module.CreatedByName = dr["CreatedByName"].ToString();
            module.CreatedDate = DateTime.Parse(dr["CreatedDate"].ToString());
            module.LastUpdByID = int.Parse(dr["LastUpdByID"].ToString());
            module.LastUpdByName = dr["LastUpdByName"].ToString();
            module.LastUpdDate = DateTime.Parse(dr["LastUpdDate"].ToString());

            return module;
        }


        private SqlParameter[] GetSqlParameter(ModuleInfo module)
        {
            return new[] {
                new SqlParameter("@ID", module.ID),
                new SqlParameter("@RootID", module.RootID),
                new SqlParameter("@ParentID", module.ParentID),

                new SqlParameter("@Name", module.Name),
                new SqlParameter("@Icon", module.Icon),
                new SqlParameter("@Url", module.Url),

                new SqlParameter("@IsMenu", module.IsMenu),
                new SqlParameter("@IsFloder", module.IsFloder),
                new SqlParameter("@IsPopedom", module.IsPopedom),

                new SqlParameter("@DisplayOrder", module.DisplayOrder),
                new SqlParameter("@CreatedByID", module.CreatedByID),
                new SqlParameter("@CreatedByName", module.CreatedByName),
                new SqlParameter("@CreatedDate", module.CreatedDate),
                new SqlParameter("@LastUpdByID", module.LastUpdByID),
                new SqlParameter("@LastUpdByName", module.LastUpdByName),
                new SqlParameter("@LastUpdDate", module.LastUpdDate)
            };
        }

        #endregion
    }
}
