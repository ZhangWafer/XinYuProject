using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using XinYu.Framework.Library.Utility.DAL;
using XinYu.Framework.Membership.Model;

namespace XinYu.Framework.Membership.DAL.SQLServer
{
    public class UserDAL : AbstractSQLDAL<UserInfo>
    {

        #region Const SQL String.

        const string CONST_SQL_INSERT = @"
INSERT INTO [Membership].[User]
    ([UserName], [Password], [OrganizationId], [OrganizationName], [Alias], [Email], [Description],
    [PasswordQuestion], [PasswordAnswer], [SessionIdentify], 
    [IsSystem], [IsAdmin], [IsApproved], [IsLockedOut], [RoleIDs], [PopedomIDs],
    [LastLoginDate], [LastActivityDate], [LastPwdChangedDate], [LastLockoutDate], 
    [FailedPwdAttemptCount], [FailedPwdAttemptDate], [FailedPwdAnswerAttemptCount], [FailedPwdAnswerAttemptDate],
    [DisplayOrder], [CreatedByID], [CreatedByName], [CreatedDate], [LastUpdByID], [LastUpdByName], [LastUpdDate])
VALUES
    (@UserName, @Password, @OrganizationId, @OrganizationName, @Alias, @Email, @Description,
    @PasswordQuestion, @PasswordAnswer, @SessionIdentify,
    @IsSystem, @IsAdmin, @IsApproved, @IsLockedOut, @RoleIDs, @PopedomIDs,
    @LastLoginDate, @LastActivityDate, @LastPwdChangedDate, @LastLockoutDate,
    @FailedPwdAttemptCount, @FailedPwdAttemptDate, @FailedPwdAnswerAttemptCount, @FailedPwdAnswerAttemptDate,
    @DisplayOrder, @CreatedByID, @CreatedByName, @CreatedDate, @LastUpdByID, @LastUpdByName, @LastUpdDate)

SELECT @@IDENTITY";

        const string CONST_SQL_DELETE = "DELETE FROM [Membership].[User] WHERE ID = @ID";

        const string CONST_SQL_UPDATE = @"
UPDATE [Membership].[User]
   SET [UserName]                   = @UserName
      ,[Password]                   = @Password

      ,[OrganizationId]             = @OrganizationId
      ,[OrganizationName]           = @OrganizationName

      ,[Alias]                      = @Alias
      ,[Email]                      = @Email
      ,[Description]                = @Description
      ,[PasswordQuestion]           = @PasswordQuestion
      ,[PasswordAnswer]             = @PasswordAnswer
      ,[SessionIdentify]            = @SessionIdentify
      ,[IsSystem]                   = @IsSystem
      ,[IsAdmin]                    = @IsAdmin
      ,[IsApproved]                 = @IsApproved
      ,[IsLockedOut]                = @IsLockedOut
      ,[RoleIDs]                    = @RoleIDs
      ,[PopedomIDs]                 = @PopedomIDs
      ,[LastLoginDate]              = @LastLoginDate
      ,[LastActivityDate]           = @LastActivityDate
      ,[LastPwdChangedDate]         = @LastPwdChangedDate
      ,[LastLockoutDate]            = @LastLockoutDate
      ,[FailedPwdAttemptCount]      = @FailedPwdAttemptCount
      ,[FailedPwdAttemptDate]       = @FailedPwdAttemptDate
      ,[FailedPwdAnswerAttemptCount]= @FailedPwdAnswerAttemptCount
      ,[FailedPwdAnswerAttemptDate] = @FailedPwdAnswerAttemptDate
      ,[DisplayOrder]               = @DisplayOrder
      ,[LastUpdByID]                = @LastUpdByID
      ,[LastUpdByName]              = @LastUpdByName
      ,[LastUpdDate]                = @LastUpdDate
 WHERE ID = @ID";

        const string CONST_SQL_UPDATE_PASSWORD = "UPDATE [Membership].[User] set Password = @NewPassword, LastPwdChangedDate = GETDATE() WHERE UserName = @UserName AND Password = @OldPassword";

        const string CONST_SQL_SELECT = "SELECT * FROM [Membership].[User] WHERE ID = @ID";

        const string CONST_SQL_SELECT_BY_NAME_PWD = "SELECT * FROM [Membership].[User] WHERE UserName = @UserName AND Password = @Password";

        const string CONST_SQL_SELECT_BY_USERNAME = "SELECT * FROM [Membership].[User] WHERE UserName = @UserName";

        const string CONST_SQL_SELECT_LIST = @"
SELECT * FROM [Membership].[User] 
WHERE (@UserName    = ''    OR UserName    LIKE '%' + @UserName +  '%')
  AND (@IsSystem    IS NULL OR IsSystem    = @IsSystem)
  AND (@IsAdmin     IS NULL OR IsAdmin     = @IsAdmin)
  AND (@IsApproved  IS NULL OR IsApproved  = @IsApproved)
  AND (@IsLockedOut IS NULL OR IsLockedOut = @IsLockedOut)
@OrderString";

        #endregion

        public void Insert(IDbTransaction trans, UserInfo user)
        {
            var parameters = GetSqlParameter(user);

            using (var dr = SQLHelper.ExecuteReader(trans as SqlTransaction, CommandType.Text, CONST_SQL_INSERT, parameters))
            {
                dr.Read();
                user.ID = Convert.ToInt32(dr[0]);
                dr.Close();
            }
        }

        public void Insert(UserInfo user)
        {
            var parameters = GetSqlParameter(user);

            using (var dr = SQLHelper.ExecuteReader(SQLHelper.ConnString, CommandType.Text, CONST_SQL_INSERT, parameters))
            {
                dr.Read();
                user.ID = Convert.ToInt32(dr[0]);
                dr.Close();
            }
        }

        public void Delete(int userID)
        {
            SQLHelper.ExecuteNonQuery(SQLHelper.ConnString, CommandType.Text, CONST_SQL_DELETE, new SqlParameter("@ID", userID));
        }

        public void Update(UserInfo user)
        {
            using (var trans = BeginTransaction(SQLHelper.ConnString))
            {
                Update(trans, user);

                trans.Commit();
            }
        }

        public void Update(IDbTransaction trans, UserInfo user)
        {
            var parameters = GetSqlParameter(user);

            SQLHelper.ExecuteNonQuery(trans as SqlTransaction, CommandType.Text, CONST_SQL_UPDATE, parameters);
        }

        public void Update(string userName, string oldEncryptedPassword, string newEncryptedPassword)
        {
            var parameters = new[] { 
                new SqlParameter("@UserName", userName), 
                new SqlParameter("@NewPassword", newEncryptedPassword), 
                new SqlParameter("@OldPassword", oldEncryptedPassword)
            };

            SQLHelper.ExecuteNonQuery(SQLHelper.ConnString, CommandType.Text, CONST_SQL_UPDATE_PASSWORD, parameters);
        }

        public UserInfo Select(IDbTransaction trans, int userID)
        {
            UserInfo user = null;
            using (var dr = SQLHelper.ExecuteReader(trans as SqlTransaction, CommandType.Text, CONST_SQL_SELECT, new SqlParameter("@ID", userID)))
            {
                if (dr.Read())
                {
                    user = BuildModel(dr);
                }
                dr.Close();
            }
            return user;
        }

        public UserInfo Select(int userID)
        {
            UserInfo user = null;
            using (var dr = SQLHelper.ExecuteReader(SQLHelper.ConnString, CommandType.Text, CONST_SQL_SELECT, new SqlParameter("@ID", userID)))
            {
                if (dr.Read())
                {
                    user = BuildModel(dr);
                }
                dr.Close();
            }
            return user;
        }

        public UserInfo SelectByNamePwd(string userName, string hashedPWD)
        {
            var parameters = new[] { 
                new SqlParameter("@UserName", userName), 
                new SqlParameter("@PassWord", hashedPWD)
            };

            UserInfo user = null;
            using (var dr = SQLHelper.ExecuteReader(SQLHelper.ConnString, CommandType.Text, CONST_SQL_SELECT_BY_NAME_PWD, parameters))
            {
                if (dr.Read())
                {
                    user = BuildModel(dr);
                }
                dr.Close();
            }
            return user;
        }

        public UserInfo SelectByName(string userName)
        {
            var parameters = new[] { new SqlParameter("@UserName", userName) };

            UserInfo user = null;
            using (var dr = SQLHelper.ExecuteReader(SQLHelper.ConnString, CommandType.Text, CONST_SQL_SELECT_BY_USERNAME, parameters))
            {
                if (dr.Read())
                {
                    user = BuildModel(dr);
                }
                dr.Close();
            }
            return user;
        }

        public IList<UserInfo> SelectList(string partUserName, bool? isSystem, bool? isAdmin, bool? isApproved, bool? isLockedOut)
        {
            return SelectList(partUserName, isSystem, isAdmin, isApproved, isLockedOut, "");
        }

        public IList<UserInfo> SelectList(string partUserName, bool? isSystem, bool? isAdmin, bool? isApproved, bool? isLockedOut, string orderString)
        {
            var parameters = new[] { 
                new SqlParameter("@UserName", partUserName), 
                new SqlParameter("@IsSystem", isSystem), 
                new SqlParameter("@IsAdmin", isAdmin),
                new SqlParameter("@IsApproved", isApproved), 
                new SqlParameter("@IsLockedOut", isLockedOut)
            };

            string sql = CONST_SQL_SELECT_LIST.Replace("@OrderString", orderString);

            using (var dr = SQLHelper.ExecuteReader(SQLHelper.ConnString, CommandType.Text, sql, parameters))
            {
                return GetModels(dr);
            }
        }

        public IList<UserInfo> SelectList(string partUserName, bool? isSystem, bool? isAdmin, bool? isApproved, bool? isLockedOut, int pageIndex, int pageSize, out int total)
        {
            return SelectList(partUserName, isSystem, isAdmin, isApproved, isLockedOut, "",
                pageIndex, pageSize, out total);
        }

        public IList<UserInfo> SelectList(string partUserName, bool? isSystem, bool? isAdmin, bool? isApproved, bool? isLockedOut, string orderString, int pageIndex, int pageSize, out int total)
        {
            var parameters = new[] { 
                new SqlParameter("@UserName", partUserName), 
                new SqlParameter("@IsSystem", isSystem), 
                new SqlParameter("@IsAdmin", isAdmin),
                new SqlParameter("@IsApproved", isApproved), 
                new SqlParameter("@IsLockedOut", isLockedOut),
            };

            string sql = CONST_SQL_SELECT_LIST.Replace("@OrderString", orderString);

            using (var dr = SQLHelper.ExecuteReader(SQLHelper.ConnString, CommandType.Text, sql, parameters))
            {
                return GetModels(dr, pageIndex, pageSize, out total);
            }
        }

        #region Private methods.

        public override UserInfo BuildModel(IDataReader dr)
        {
            var ret = new UserInfo
            {
                ID = int.Parse(dr["ID"].ToString()),
                UserName = dr["UserName"].ToString(),
                EncryptedPassword = dr["Password"].ToString(),

                OrganizationName = dr["OrganizationName"] == DBNull.Value
                ? null
                : dr["OrganizationName"].ToString(),

                OrganizationId = dr["OrganizationId"] == DBNull.Value
                ? (int?)null
                : Convert.ToInt32(dr["OrganizationId"].ToString()),

                Alias = dr["Alias"].ToString(),
                Email = dr["Email"].ToString(),
                Description = dr["Description"].ToString(),
                PasswordQuestion = dr["PasswordQuestion"].ToString(),
                PasswordAnswer = dr["PasswordAnswer"].ToString(),
                SessionIdentify = dr["SessionIdentify"].ToString(),
                IsSystem = bool.Parse(dr["IsSystem"].ToString()),
                IsAdmin = bool.Parse(dr["IsAdmin"].ToString()),
                IsApproved = bool.Parse(dr["IsApproved"].ToString()),
                IsLockedOut = bool.Parse(dr["IsLockedOut"].ToString()),
                RoleIDs = dr["RoleIDs"].ToString(),
                PopedomIDs = dr["PopedomIDs"].ToString(),
                LastLoginDate = DateTime.Parse(dr["LastLoginDate"].ToString()),
                LastActivityDate = DateTime.Parse(dr["LastActivityDate"].ToString()),
                LastPwdChangedDate = DateTime.Parse(dr["LastPwdChangedDate"].ToString()),
                LastLockoutDate = DateTime.Parse(dr["LastLockoutDate"].ToString()),
                FailedPwdAttemptCount = int.Parse(dr["FailedPwdAttemptCount"].ToString()),
                FailedPwdAttemptDate = DateTime.Parse(dr["FailedPwdAttemptDate"].ToString()),
                FailedAnswerAttemptCount = int.Parse(dr["FailedPwdAnswerAttemptCount"].ToString()),
                FailedAnswerAttemptDate = DateTime.Parse(dr["FailedPwdAnswerAttemptDate"].ToString()),
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

        private SqlParameter[] GetSqlParameter(UserInfo user)
        {
            return new[] {
                new SqlParameter("@ID", user.ID),
                new SqlParameter("@UserName", user.UserName),
                new SqlParameter("@Password", user.EncryptedPassword),

                new SqlParameter("@OrganizationId", user.OrganizationId),
                new SqlParameter("@OrganizationName", user.OrganizationName),

                new SqlParameter("@Alias", user.Alias),
                new SqlParameter("@Email", user.Email),
                new SqlParameter("@Description", user.Description),

                new SqlParameter("@PasswordQuestion", user.PasswordQuestion),
                new SqlParameter("@PasswordAnswer", user.PasswordAnswer),
                new SqlParameter("@SessionIdentify", user.SessionIdentify),

                new SqlParameter("@IsSystem", user.IsSystem),
                new SqlParameter("@IsAdmin", user.IsAdmin),
                new SqlParameter("@IsApproved", user.IsApproved),
                new SqlParameter("@IsLockedOut", user.IsLockedOut),
                new SqlParameter("@RoleIDs", user.RoleIDs),
                new SqlParameter("@PopedomIDs", user.PopedomIDs),

                new SqlParameter("@LastLoginDate", user.LastLoginDate),
                new SqlParameter("@LastActivityDate", user.LastActivityDate),
                new SqlParameter("@LastPwdChangedDate", user.LastPwdChangedDate),
                new SqlParameter("@LastLockoutDate", user.LastLockoutDate),

                new SqlParameter("@FailedPwdAttemptCount", user.FailedPwdAttemptCount),
                new SqlParameter("@FailedPwdAttemptDate", user.FailedPwdAttemptDate),
                new SqlParameter("@FailedPwdAnswerAttemptCount", user.FailedAnswerAttemptCount),
                new SqlParameter("@FailedPwdAnswerAttemptDate", user.FailedAnswerAttemptDate),

                new SqlParameter("@DisplayOrder", user.DisplayOrder),
                new SqlParameter("@CreatedByID", user.CreatedByID),
                new SqlParameter("@CreatedByName", user.CreatedByName),
                new SqlParameter("@CreatedDate", user.CreatedDate),
                new SqlParameter("@LastUpdByID", user.LastUpdByID),
                new SqlParameter("@LastUpdByName", user.LastUpdByName),
                new SqlParameter("@LastUpdDate", user.LastUpdDate),
            };
        }

        #endregion

    }
}
