using System;
using System.Collections.Generic;
using XinYu.Framework.Membership.Model;

namespace XinYu.Framework.Membership.BLL
{
    public class UserManagerBLL : MembershipBLLBase
    {
        public void AddUser(UserInfo user)
        {
            UserInfo oldUser = Static_User_DAL.SelectByName(user.UserName);
            if (oldUser != null && oldUser.ID != user.ID)
            {
                throw new Exception("会员账号已存在，无法新增该账号！");
            }

            // 给密码进行HASH加密
            user.EncryptedPassword = Static_Hash_Cryptorgrapher.CreateHash(user.EncryptedPassword);

            Static_User_DAL.Insert(user);

        }

        public void RemoveUser(int userID)
        {
            Static_User_DAL.Delete(userID);
        }

        public void ModifyUser(UserInfo user)
        {
            // 检查新的编号是否已被使用
            var oldUser = Static_User_DAL.SelectByName(user.UserName);
            if (oldUser != null && oldUser.ID != user.ID)
            {
                throw new Exception("新修改的会员账号已存在，无法修改当前会员的账号！");
            }

            Static_User_DAL.Update(user);
        }

        public void LockUser(int userID, bool lockThisUser)
        {
            var oldUser = Static_User_DAL.Select(userID);
            if (oldUser != null)
            {
                oldUser.IsLockedOut = lockThisUser;
                Static_User_DAL.Update(oldUser);
            }
        }

        public IList<UserInfo> GetUserList(string partUserName, bool? isSystem, bool? isAdmin, bool? isLockedOut, int pageIndex, int pageSize, out int total)
        {
            return Static_User_DAL.SelectList(partUserName, isSystem, isAdmin, null, isLockedOut, pageIndex, pageSize, out total);
        }
    }
}
