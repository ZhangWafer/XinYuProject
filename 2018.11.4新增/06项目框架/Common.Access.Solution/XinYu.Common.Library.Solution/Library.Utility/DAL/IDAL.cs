using System.Collections.Generic;
using System.Data;

namespace XinYu.Framework.Library.Utility.DAL
{
    /// <summary>
    /// ���ݿ���ʻ���ӿ�.
    /// �ýӿ���Ҫ���ڶ������ݿ��������빲ͬ��ѭ�Ļ�������Э��.
    /// </summary>
    /// <typeparam name="TModel">��Ҫ������Model��.</typeparam>
    public interface IDAL<TModel>
            where TModel : class
    {

        #region ���ݿ��������������.

        /// <summary>
        /// ��ʼһ�������ִ��.
        /// </summary>
        /// <param name="connectionString">���ݿ������ַ���.</param>
        /// <returns></returns>
        IDbTransaction BeginTransaction(string connectionString);

        /// <summary>
        /// ��ʼһ�������ִ��.
        /// </summary>
        /// <param name="connectionString">���ݿ������ַ���.</param>
        /// <returns>�������.</returns>
        IDbTransaction BeginTransaction(string connectionString, IsolationLevel isolationLevel);

        /// <summary>
        /// ��ʼһ�������ִ��.
        /// </summary>
        /// <param name="conn">���ݿ����Ӷ���.</param>
        /// <returns></returns>
        IDbTransaction BeginTransaction(IDbConnection conn);

        /// <summary>
        ///  ��ʼһ�������ִ��.
        /// </summary>
        /// <param name="isolationLevel"></param>
        /// <returns></returns>
        IDbTransaction BeginTransaction(IDbConnection conn, IsolationLevel isolationLevel);

        /// <summary>
        /// �ύ����ִ��.
        /// </summary>
        /// <param name="trans">�������.</param>
        void CommitTransaction(IDbTransaction trans);

        /// <summary>
        /// �ύ����ִ��.
        /// </summary>
        /// <param name="trans">�������.</param>
        /// <param name="closeConnection">�Ƿ������ر����ݿ�����.</param>
        void CommitTransaction(IDbTransaction trans, bool closeConnection);

        /// <summary>
        /// �ع�����ִ��.
        /// </summary>
        /// <param name="trans">�������.</param>
        void RollbackTransaction(IDbTransaction trans);

        /// <summary>
        /// �ع�����ִ��.
        /// </summary>
        /// <param name="trans">�������.</param>
        /// <param name="closeConnection">�Ƿ������ر����ݿ�����.</param>
        void RollbackTransaction(IDbTransaction trans, bool closeConnection);

        #endregion

        #region ͨ��IDataReaderʵ����ȡModel����.

        /// <summary>
        /// ��DataReaderʵ���й���һ��Modelʵ��.
        /// </summary>
        /// <param name="dr">DataReaderʵ��.</param>
        /// <returns>Modelʵ��.</returns>
        TModel BuildModel(IDataReader dr);

        /// <summary>
        /// ͨ��IDataReaderʵ����ȡ���е�Model�����б�.
        /// </summary>
        /// <param name="dr">Data Reader ʵ������.</param>
        /// <returns>Model�����б�.</returns>
        IList<TModel> GetModels(IDataReader dr);


           /// <summary>
        /// ͨ��IDataReaderʵ����ȡ���е�Model�����б�.
        /// </summary>
        /// <param name="dr">Data Reader ʵ������.</param>
        /// <param name="closeDataReader">��ȡ��Model�����, �Ƿ������ر�Data Readerʵ������.</param>
        /// <returns>Model�����б�.</returns>
         IList<TModel> GetModels(IDataReader dr, bool closeDataReader);

        /// <summary>
        /// ͨ��IDataReaderʵ����ȡ��ǰҳ��Model�����б�.
        /// </summary>
        /// <param name="dr">Data Reader ʵ������.</param>
        /// <param name="pageIndex">ҳ��.</param>
        /// <param name="pageSize">ÿҳ��ʾ�ļ�¼��.</param>
        /// <param name="totalRecords">����ȡ�ļ�¼��.</param>
        /// <returns>��ǰҳ��Model�����б�.</returns>
        IList<TModel> GetModels(IDataReader dr, int pageIndex, int pageSize, out int totalRecords);

        /// <summary>
        /// ͨ��IDataReaderʵ����ȡ��ǰҳ��Model�����б�.
        /// </summary>
        /// <param name="dr">Data Reader ʵ������.</param>
        /// <param name="closeDataReader">��ȡ��Model�����, �Ƿ������ر�Data Readerʵ������.</param>
        /// <param name="pageIndex">ҳ��.</param>
        /// <param name="pageSize">ÿҳ��ʾ�ļ�¼��.</param>
        /// <param name="totalRecords">����ȡ�ļ�¼��.</param>
        /// <returns>��ǰҳ��Model�����б�.</returns>
        IList<TModel> GetModels(IDataReader dr, bool closeDataReader, int pageIndex, int pageSize, out int totalRecords);

        #endregion
    }
}
