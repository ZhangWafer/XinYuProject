using System;

namespace XinYu.Framework.Cookbook.Model
{

    /// <summary>
    /// ��Ʒ��Ϣʵ��
    /// </summary>
    public class CookbookInfo
    {
        public CookbookInfo() { }

        /// <summary>
        /// ��ƷID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// �۸�
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// ʵ�ʼ۸�
        /// </summary>
        public decimal RealPrice { get; set; }

        /// <summary>
        /// �Żݼ۸�
        /// </summary>
        public decimal SalePrice { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// ��ƷͼƬ
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// ��Լͼ
        /// </summary>
        public string IconThum { get; set; }

        /// <summary>
        /// ����ID
        /// </summary>
        public int? OrganizationId { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        public string OrganizationName { get; set; }

        public int DisplayOrder { get; set; }

        public int CreatedByID { get; set; }

        public string CreatedByName { get; set; }

        public DateTime CreatedDate { get; set; }

        public int LastUpdByID { get; set; }

        public string LastUpdByName { get; set; }

        public DateTime LastUpdDate { get; set; }
    }
}
