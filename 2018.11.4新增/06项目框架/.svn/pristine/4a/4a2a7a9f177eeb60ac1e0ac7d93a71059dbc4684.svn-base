using System;
using System.Collections.Generic;
using System.Text;

namespace XinYu.Framework.Membership.Model
{         
    public class ModelBase
    {
        int dislayOrder;

        int createdByID;
        string createdByName;
        DateTime createdDate;

        int lastUpdByID;
        string lastUpdByName;
        DateTime lastUpdDate;


        public int DisplayOrder
        {
            get { return dislayOrder; }
            set { dislayOrder = value; }
        }

        public int CreatedByID
        {
            get { return createdByID; }
            set { createdByID = value; }
        }

        public string CreatedByName
        {
            get { return createdByName; }
            set { createdByName = value; }
        }

        public DateTime CreatedDate
        {
            get { return createdDate; }
            set { createdDate = value; }
        }

        public int LastUpdByID
        {
            get { return lastUpdByID; }
            set { lastUpdByID = value; }
        }

        public string LastUpdByName
        {
            get { return lastUpdByName; }
            set { lastUpdByName = value; }
        }

        public DateTime LastUpdDate
        {
            get { return lastUpdDate; }
            set { lastUpdDate = value; }
        }


        #region Protected methods.

        protected const string CONST_POPEDOM_SEPT = "%&%";

        protected string formatIDs(int[] idList)
        {
            var sb = new StringBuilder(CONST_POPEDOM_SEPT);
            for (int i = 0; i < idList.Length; i++)
            {
                sb.AppendFormat("{0}{1}", idList[i], CONST_POPEDOM_SEPT);
            }
            return sb.ToString();
        }

        protected int[] deformatIDs(string idListString)
        {
            var pss = idListString.Trim().Split(new[] { CONST_POPEDOM_SEPT }, StringSplitOptions.RemoveEmptyEntries);
            var ret = new List<int>();

            foreach (string ps in pss)
            {
                if (string.IsNullOrEmpty(ps.Trim()))
                    continue;

                int outID;
                if (int.TryParse(ps, out outID)) ret.Add(outID);
            }

            return ret.ToArray();
        }

        #endregion


    }
}
