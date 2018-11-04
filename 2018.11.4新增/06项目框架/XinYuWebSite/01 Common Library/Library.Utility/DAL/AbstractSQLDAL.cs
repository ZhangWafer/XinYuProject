using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Spotmau.Framework.Library.Utility.DAL;

namespace XinYu.Framework.Library.Utility.DAL
{
    /// <summary>
    /// ���ݿ���ʻ���.
    /// </summary>
    /// <typeparam name="TModel">��Ҫ������Model��.</typeparam>
    public abstract class AbstractSQLDAL<TModel> : IDAL<TModel>
        where TModel : class
    {

        #region ���ݿ��������������.

        /// <summary>
        /// ��ʼһ�������ִ��.
        /// </summary>
        /// <param name="connectionString">���ݿ������ַ���.</param>
        /// <returns></returns>
        public IDbTransaction BeginTransaction(string connectionString)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            return this.BeginTransaction(conn);
        }

        /// <summary>
        /// ��ʼһ�������ִ��.
        /// </summary>
        /// <param name="connectionString">���ݿ������ַ���.</param>
        /// <returns>�������.</returns>
        public IDbTransaction BeginTransaction(string connectionString, IsolationLevel isolationLevel)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            return this.BeginTransaction(conn, isolationLevel);
        }

        /// <summary>
        /// ��ʼһ�������ִ��.
        /// </summary>
        /// <param name="conn">���ݿ����Ӷ���.</param>
        /// <returns></returns>
        public IDbTransaction BeginTransaction(IDbConnection conn)
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            return conn.BeginTransaction();
        }

        /// <summary>
        ///  ��ʼһ�������ִ��.
        /// </summary>
        /// <param name="isolationLevel"></param>
        /// <returns></returns>
        public IDbTransaction BeginTransaction(IDbConnection conn, IsolationLevel isolationLevel)
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            return conn.BeginTransaction(isolationLevel);
        }

        /// <summary>
        /// �ύ����ִ��.
        /// </summary>
        /// <param name="trans">�������.</param>
        public void CommitTransaction(IDbTransaction trans)
        {
            this.CommitTransaction(trans, true);
        }

        /// <summary>
        /// �ύ����ִ��.
        /// </summary>
        /// <param name="trans">�������.</param>
        /// <param name="closeConnection">�Ƿ������ر����ݿ�����.</param>
        public void CommitTransaction(IDbTransaction trans, bool closeConnection)
        {
            trans.Commit();

            if (closeConnection && trans.Connection.State != ConnectionState.Closed)
            {
                trans.Connection.Close();
            }

            trans = null;
        }

        /// <summary>
        /// �ع�����ִ��.
        /// </summary>
        /// <param name="trans">�������.</param>
        public void RollbackTransaction(IDbTransaction trans)
        {
            this.RollbackTransaction(trans, true);
        }

        /// <summary>
        /// �ع�����ִ��.
        /// </summary>
        /// <param name="trans">�������.</param>
        /// <param name="closeConnection">�Ƿ������ر����ݿ�����.</param>
        public void RollbackTransaction(IDbTransaction trans, bool closeConnection)
        {
            trans.Rollback();

            if (closeConnection && trans.Connection.State != ConnectionState.Closed)
            {
                trans.Connection.Close();
            }

            trans = null;
        }

        #endregion

        #region ͨ��IDataReaderʵ����ȡModel����.

        
        /// <summary>
        /// ��DataReaderʵ���й���һ��Modelʵ��.
        /// </summary>
        /// <param name="dr">��ָ������¼��DataReaderʵ��(���ѵ���dr.Read()����).</param>
        /// <returns>Modelʵ��.</returns>
        public abstract TModel BuildModel(IDataReader dr);

        /// <summary>
        /// ͨ��IDataReaderʵ����ȡ���е�Model�����б�.
        /// </summary>
        /// <param name="dr">Data Reader ʵ������.</param>
        /// <returns>Model�����б�.</returns>
        public IList<TModel> GetModels(IDataReader dr)
        {
            return this.GetModels(dr, true);
        }

        /// <summary>
        /// ͨ��IDataReaderʵ����ȡ���е�Model�����б�.
        /// </summary>
        /// <param name="dr">Data Reader ʵ������.</param>
        /// <param name="closeDataReader">��ȡ��Model�����, �Ƿ������ر�Data Readerʵ������.</param>
        /// <returns>Model�����б�.</returns>
        public IList<TModel> GetModels(IDataReader dr, bool closeDataReader)
        {
            List<TModel> lst = new List<TModel>();

            while (dr.Read())
            {
                TModel model = this.BuildModel(dr);
                lst.Add(model);
            }

            if (closeDataReader)
            {
                dr.Close();
                dr = null;
            }

            return lst;
        }

        /// <summary>
        /// ͨ��IDataReaderʵ����ȡ��ǰҳ��Model�����б�.
        /// </summary>
        /// <param name="dr">Data Reader ʵ������.</param>
        /// <param name="pageIndex">ҳ��.</param>
        /// <param name="pageSize">ÿҳ��ʾ�ļ�¼��.</param>
        /// <param name="totalRecords">����ȡ�ļ�¼��.</param>
        /// <returns>��ǰҳ��Model�����б�.</returns>
        public IList<TModel> GetModels(IDataReader dr, int pageIndex, int pageSize)
        {
            return this.GetModels(dr, true, pageIndex, pageSize);
        }

        /// <summary>
        /// ͨ��IDataReaderʵ����ȡ��ǰҳ��Model�����б�.
        /// </summary>
        /// <param name="dr">Data Reader ʵ������.</param>
        /// <param name="closeDataReader">��ȡ��Model�����, �Ƿ������ر�Data Readerʵ������.</param>
        /// <param name="pageIndex">ҳ��,��1��ʼ.</param>
        /// <param name="pageSize">ÿҳ��ʾ�ļ�¼��.</param>
        /// <param name="totalRecords">����ȡ�ļ�¼��.</param>
        /// <returns>��ǰҳ��Model�����б�.</returns>
        public IList<TModel> GetModels(IDataReader dr, bool closeDataReader, int pageIndex, int pageSize)
        {
            List<TModel> lst = new List<TModel>();

            int i = 0;
            int beginRowNumber = (pageIndex - 1) * pageSize;
            int endRowNumber = pageIndex * pageSize - 1;
            while (dr.Read())
            {
                if (i < beginRowNumber)
                {
                    i++;
                    continue;
                }

                i++;
                TModel model = this.BuildModel(dr);
                lst.Add(model);

                if (i > endRowNumber)
                {
                    break;
                }
            }

            if (closeDataReader)
            {
                dr.Close();
                dr = null;
            }

            return lst;
        }



        /// <summary>
        /// ͨ��IDataReaderʵ����ȡ��ǰҳ��Model�����б�.
        /// </summary>
        /// <param name="dr">Data Reader ʵ������.</param>
        /// <param name="pageIndex">ҳ��.</param>
        /// <param name="pageSize">ÿҳ��ʾ�ļ�¼��.</param>
        /// <param name="totalRecords">����ȡ�ļ�¼��.</param>
        /// <returns>��ǰҳ��Model�����б�.</returns>
        public IList<TModel> GetModels(IDataReader dr, int pageIndex, int pageSize, out int totalRecords)
        {
            return this.GetModels(dr, true, pageIndex, pageSize, out totalRecords);
        }

        /// <summary>
        /// ͨ��IDataReaderʵ����ȡ��ǰҳ��Model�����б�.
        /// </summary>
        /// <param name="dr">Data Reader ʵ������.</param>
        /// <param name="closeDataReader">��ȡ��Model�����, �Ƿ������ر�Data Readerʵ������.</param>
        /// <param name="pageIndex">ҳ��,��1��ʼ.</param>
        /// <param name="pageSize">ÿҳ��ʾ�ļ�¼��.</param>
        /// <param name="totalRecords">����ȡ�ļ�¼��.</param>
        /// <returns>��ǰҳ��Model�����б�.</returns>
        public IList<TModel> GetModels(IDataReader dr, bool closeDataReader, int pageIndex, int pageSize, out int totalRecords)
        {
            List<TModel> lst = new List<TModel>();

            int i = 0;
            int beginRowNumber = (pageIndex - 1) * pageSize;
            int endRowNumber = pageIndex * pageSize - 1;
            while (dr.Read())
            {
                if (i < beginRowNumber || i > endRowNumber)
                {
                    i++;
                    continue;
                }

                i++;
                TModel model = this.BuildModel(dr);
                lst.Add(model);
            }

            if (closeDataReader)
            {
                dr.Close();
                dr = null;
            }

            totalRecords = i;
            return lst;
        }

        #endregion
    }
}