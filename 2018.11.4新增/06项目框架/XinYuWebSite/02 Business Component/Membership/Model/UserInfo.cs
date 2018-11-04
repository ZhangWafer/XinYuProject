using System;
using System.Collections.Generic;

namespace XinYu.Framework.Membership.Model
{

    /// <summary>
    /// 用户.
    /// </summary>
    public class UserInfo : ModelBase
    {
        int id;
        string userName;
        string encryptedPassword;
        string alias;
        string email;
        string description;

        string passwordQuestion;
        string passwordAnswer;
        string sessionIdentify;

        bool isSystem;
        bool isAdmin;
        bool isApproved;
        bool isLockedOut;

        string roleIDs = string.Empty;
        string popedomIDs = string.Empty;

        DateTime lastLoginDate;
        DateTime lastActivityDate;
        DateTime lastPwdChangedDate;
        DateTime lastLockoutDate;

        int? failedPwdAttemptCount;
        DateTime? failedPwdAttemtpDate;
        int? failedAnswerAttemptCount;
        DateTime? failedAnswerAttemptDate;


        public UserInfo()
        {
        }


        #region Pulic Properties.

        public int ID
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public string UserName
        {
            get { return this.userName; }
            set { this.userName = value; }
        }

        public string EncryptedPassword
        {
            get { return this.encryptedPassword; }
            set { this.encryptedPassword = value; }
        }

        public string Alias
        {
            get { return this.alias; }
            set { this.alias = value; }
        }

        public string Email
        {
            get { return this.email; }
            set { this.email = value; }
        }

        public string Description
        {
            get { return this.description; }
            set { this.description = value; }
        }




        public string PasswordQuestion
        {
            get { return this.passwordQuestion; }
            set { this.passwordQuestion = value; }
        }

        public string PasswordAnswer
        {
            get { return this.passwordAnswer; }
            set { this.passwordAnswer = value; }
        }

        public string SessionIdentify
        {
            get { return this.sessionIdentify; }
            set { this.sessionIdentify = value; }
        }



        public bool IsSystem
        {
            get { return this.isSystem; }
            set { this.isSystem = value; }
        }

        public bool IsAdmin
        {
            get { return this.isAdmin; }
            set { this.isAdmin = value; }
        }

        public bool IsApproved
        {
            get { return this.isApproved; }
            set { this.isApproved = value; }
        }

        public bool IsLockedOut
        {
            get { return this.isLockedOut; }
            set { this.isLockedOut = value; }
        }



        public string RoleIDs
        {
            get { return roleIDs; }
            set { roleIDs = value; }
        }

        public string PopedomIDs
        {
            get { return this.popedomIDs; }
            set { this.popedomIDs = value; }
        }



        public DateTime LastLoginDate
        {
            get { return this.lastLoginDate; }
            set { this.lastLoginDate = value; }
        }

        public DateTime LastActivityDate
        {
            get { return this.lastActivityDate; }
            set { this.lastActivityDate = value; }
        }

        public DateTime LastPwdChangedDate
        {
            get { return this.lastPwdChangedDate; }
            set { this.lastPwdChangedDate = value; }
        }

        public DateTime LastLockoutDate
        {
            get { return this.lastLockoutDate; }
            set { this.lastLockoutDate = value; }
        }



        public int? FailedPwdAttemptCount
        {
            get { return this.failedPwdAttemptCount; }
            set { this.failedPwdAttemptCount = value; }
        }

        public DateTime? FailedPwdAttemptDate
        {
            get { return this.failedPwdAttemtpDate; }
            set { this.failedPwdAttemtpDate = value; }
        }

        public int? FailedAnswerAttemptCount
        {
            get { return this.failedAnswerAttemptCount; }
            set { this.failedAnswerAttemptCount = value; }
        }

        public DateTime? FailedAnswerAttemptDate
        {
            get { return this.failedAnswerAttemptDate; }
            set { this.failedAnswerAttemptDate = value; }
        }

        #endregion


        public override int GetHashCode()
        {
            if (this.id <= 0) return base.GetHashCode();

            return this.id;
            //return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var otherUser = obj as UserInfo;
            if (otherUser == null) return false;

            return otherUser.id == this.id;
        }

        public int[] PopedomIDList
        {
            get { return this.deformatIDs(this.popedomIDs); }
            set { this.popedomIDs = this.formatIDs(value); }
        }

        public int[] RoleIDList
        {
            get { return this.deformatIDs(this.roleIDs); }
            set { this.roleIDs = this.formatIDs(value); }
        }

        public void AddRole(int roleID)
        {
            if (this.IsRole(roleID)) return;

            if (string.IsNullOrEmpty(this.roleIDs.Trim()))
                this.roleIDs = string.Format("{0}{1}{0}", CONST_POPEDOM_SEPT, roleID);
            else
                this.roleIDs += string.Format("{0}{1}", roleID, CONST_POPEDOM_SEPT);
        }

        public bool IsRole(RoleInfo role)
        {
            return this.IsRole(role.ID);
        }

        public bool IsRole(int roleID)
        {
            if (this.isSystem) return true;

            // 用户没有设置任何权限，直接返回False
            if (string.IsNullOrEmpty(this.roleIDs))
                return false;

            var roleNoString = string.Format("{0}{1}{0}", CONST_POPEDOM_SEPT, roleID);
            return this.roleIDs.IndexOf(roleNoString) >= 0;
        }

        /// <summary>
        /// 判断该用户是否具有指定模块的权限
        /// </summary>
        /// <param name="moduleID"></param>
        /// <returns></returns>
        public bool HasPopedom(ModuleInfo module)
        {
            if (module == null) return false;

            // 该模块不需要进行权限认证，直接返回True
            if (module.IsPopedom) return true;

            return this.HasPopedom(module.ID);
        }

        /// <summary>
        /// 判断该用户是否具有指定模块的权限
        /// </summary>
        /// <param name="moduleID"></param>
        /// <returns></returns>
        public bool HasPopedom(int moduleID)
        {
            if (this.isSystem) return true;

            // 用户没有设置任何权限，直接返回False
            if (string.IsNullOrEmpty(this.popedomIDs)) return false;

            var moduleIDString = string.Format("{0}{1}{0}", CONST_POPEDOM_SEPT, moduleID);
            return this.popedomIDs.IndexOf(moduleIDString) >= 0;
        }

        /// <summary>
        /// 判断当前用户是否具有访问指定模块对象的权限
        /// </summary>
        /// <param name="module"></param>
        /// <param name="allRoleList"></param>
        /// <returns></returns>
        public bool HasPopedom(ModuleInfo module, IList<RoleInfo> allRoleList)
        {
            if (module == null) return false;
            if (this.isSystem) return true;

            // 该模块不需要进行权限认证，直接返回True
            if (module.IsPopedom) return true;

            if (this.HasPopedom(module.ID)) return true;

            foreach (RoleInfo role in allRoleList)
            {
                if (this.IsRole(role) && role.HasPopedom(module)) return true;
            }

            return false;
        }
    }
}
