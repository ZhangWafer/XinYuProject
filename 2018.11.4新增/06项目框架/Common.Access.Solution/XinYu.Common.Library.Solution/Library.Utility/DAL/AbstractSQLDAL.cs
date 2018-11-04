using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Spotmau.Framework.Library.Utility.DAL;

namespace XinYu.Framework.Library.Utility.DAL
{
    /// <summary>
    /// 数据库访问基类.
    /// </summary>
    /// <typeparam name="TModel">将要操作的Model类.</typeparam>
    public abstract class AbstractSQLDAL<TModel> : IDAL<TModel>
        where TModel : class
    {

        #region 数据库事务处理操作方法.

        /// <summary>
        /// 开始一个事务的执行.
        /// </summary>
        /// <param name="connectionString">数据库连接字符串.</param>
        /// <returns></returns>
        public IDbTransaction BeginTransaction(string connectionString)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            return this.BeginTransaction(conn);
        }

        /// <summary>
        /// 开始一个事务的执行.
        /// </summary>
        /// <param name="connectionString">数据库连接字符串.</param>
        /// <returns>事务对象.</returns>
        public IDbTransaction BeginTransaction(string connectionString, IsolationLevel isolationLevel)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            return this.BeginTransaction(conn, isolationLevel);
        }

        /// <summary>
        /// 开始一个事务的执行.
        /// </summary>
        /// <param name="conn">数据库连接对象.</param>
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
        ///  开始一个事务的执行.
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
        /// 提交事务执行.
        /// </summary>
        /// <param name="trans">事务对象.</param>
        public void CommitTransaction(IDbTransaction trans)
        {
            this.CommitTransaction(trans, true);
        }

        /// <summary>
        /// 提交事务执行.
        /// </summary>
        /// <param name="trans">事务对象.</param>
        /// <param name="closeConnection">是否主动关闭数据库连接.</param>
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
        /// 回滚事务执行.
        /// </summary>
        /// <param name="trans">事务对象.</param>
        public void RollbackTransaction(IDbTransaction trans)
        {
            this.RollbackTransaction(trans, true);
        }

        /// <summary>
        /// 回滚事务执行.
        /// </summary>
        /// <param name="trans">事务对象.</param>
        /// <param name="closeConnection">是否主动关闭数据库连接.</param>
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

        #region 通过IDataReader实例获取Model对象.

        
        /// <summary>
        /// 从DataReader实例中构造一个Model实例.
        /// </summary>
        /// <param name="dr">已指向具体记录的DataReader实例(既已调用dr.Read()方法).</param>
        /// <returns>Model实例.</returns>
        public abstract TModel BuildModel(IDataReader dr);

        /// <summary>
        /// 通过IDataReader实例获取所有的Model对象列表.
        /// </summary>
        /// <param name="dr">Data Reader 实例对象.</param>
        /// <returns>Model对象列表.</returns>
        public IList<TModel> GetModels(IDataReader dr)
        {
            return this.GetModels(dr, true);
        }

        /// <summary>
        /// 通过IDataReader实例获取所有的Model对象列表.
        /// </summary>
        /// <param name="dr">Data Reader 实例对象.</param>
        /// <param name="closeDataReader">读取完Model对象后, 是否主动关闭Data Reader实例对象.</param>
        /// <returns>Model对象列表.</returns>
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
        /// 通过IDataReader实例获取当前页的Model对象列表.
        /// </summary>
        /// <param name="dr">Data Reader 实例对象.</param>
        /// <param name="pageIndex">页码.</param>
        /// <param name="pageSize">每页显示的记录数.</param>
        /// <param name="totalRecords">共获取的记录数.</param>
        /// <returns>当前页的Model对象列表.</returns>
        public IList<TModel> GetModels(IDataReader dr, int pageIndex, int pageSize)
        {
            return this.GetModels(dr, true, pageIndex, pageSize);
        }

        /// <summary>
        /// 通过IDataReader实例获取当前页的Model对象列表.
        /// </summary>
        /// <param name="dr">Data Reader 实例对象.</param>
        /// <param name="closeDataReader">读取完Model对象后, 是否主动关闭Data Reader实例对象.</param>
        /// <param name="pageIndex">页码,从1开始.</param>
        /// <param name="pageSize">每页显示的记录数.</param>
        /// <param name="totalRecords">共获取的记录数.</param>
        /// <returns>当前页的Model对象列表.</returns>
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
        /// 通过IDataReader实例获取当前页的Model对象列表.
        /// </summary>
        /// <param name="dr">Data Reader 实例对象.</param>
        /// <param name="pageIndex">页码.</param>
        /// <param name="pageSize">每页显示的记录数.</param>
        /// <param name="totalRecords">共获取的记录数.</param>
        /// <returns>当前页的Model对象列表.</returns>
        public IList<TModel> GetModels(IDataReader dr, int pageIndex, int pageSize, out int totalRecords)
        {
            return this.GetModels(dr, true, pageIndex, pageSize, out totalRecords);
        }

        /// <summary>
        /// 通过IDataReader实例获取当前页的Model对象列表.
        /// </summary>
        /// <param name="dr">Data Reader 实例对象.</param>
        /// <param name="closeDataReader">读取完Model对象后, 是否主动关闭Data Reader实例对象.</param>
        /// <param name="pageIndex">页码,从1开始.</param>
        /// <param name="pageSize">每页显示的记录数.</param>
        /// <param name="totalRecords">共获取的记录数.</param>
        /// <returns>当前页的Model对象列表.</returns>
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