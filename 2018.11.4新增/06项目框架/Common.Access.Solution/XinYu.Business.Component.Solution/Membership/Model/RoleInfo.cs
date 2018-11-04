namespace XinYu.Framework.Membership.Model
{
    public class RoleInfo : ModelBase
    {
        int id;
        string roleName;
        string headImage;
        string popedomIDs;
        string description;



        public int ID
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public string RoleName
        {
            get { return roleName; }
            set { roleName = value; }
        }

        public string HeadImage
        {
            get { return headImage; }
            set { headImage = value; }
        }

        public string PopedomIDs
        {
            get { return popedomIDs; }
            set { popedomIDs = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }


        public int[] PopedomIDList
        {
            get { return this.deformatIDs(this.popedomIDs); }
            set { this.popedomIDs = this.formatIDs(value); }
        }



        /// <summary>
        /// �жϸý�ɫ�Ƿ����ָ��ģ���Ȩ��
        /// </summary>
        /// <param name="moduleID"></param>
        /// <returns></returns>
        public bool HasPopedom(ModuleInfo module)
        {
            // ��ģ�鲻��Ҫ����Ȩ����֤��ֱ�ӷ���True
            if (module.IsPopedom) return true;

            // ��ɫû�������κ�Ȩ�ޣ�ֱ�ӷ���False
            if (string.IsNullOrEmpty(this.popedomIDs))
                return false;

            var moduleIDString = string.Format("{0}{1}{0}", CONST_POPEDOM_SEPT, module.ID);
            return this.popedomIDs.IndexOf(moduleIDString) >= 0;
        }

    }
}
