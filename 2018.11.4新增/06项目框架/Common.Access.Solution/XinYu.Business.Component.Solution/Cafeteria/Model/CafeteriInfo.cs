using System;

namespace XinYu.Framework.Cafeteria.Model
{

    /// <summary>
    /// ʳ����Ϣ��
    /// </summary>
    public class CafeteriInfo
    {
        public CafeteriInfo() { }

        /// <summary>
        /// ʳ��ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        public CafeteriaTypeEnum CafeteriaTypeEnum { get; set; }

        /// <summary>
        /// ����ID
        /// </summary>
        public int OrganizationId { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        public string OrganizationName { get; set; }

        /// <summary>
        /// �����ֶ�
        /// </summary>
        public int DisplayOrder { get; set; }

        public int CreatedByID { get; set; }

        public string CreatedByName { get; set; }

        public DateTime CreatedDate { get; set; }

        public int LastUpdByID { get; set; }

        public string LastUpdByName { get; set; }

        public DateTime LastUpdDate { get; set; }
    }
}
