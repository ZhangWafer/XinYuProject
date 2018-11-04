using System.Collections.Generic;
using System.Data;

namespace XinYu.Framework.Library.Utility.DAL
{
    /// <summary>
    /// 数据库访问基类接口.
    /// 该接口主要用于定义数据库访问类必须共同尊循的基本访问协议.
    /// </summary>
    /// <typeparam name="TModel">将要操作的Model类.</typeparam>
    public interface IDAL<TModel>
            where TModel : class
    {

        #region 数据库事务处理操作方法.

        /// <summary>
        /// 开始一个事务的执行.
        /// </summary>
        /// <param name="connectionString">数据库连接字符串.</param>
        /// <returns></returns>
        IDbTransaction BeginTransaction(string connectionString);

        /// <summary>
        /// 开始一个事务的执行.
        /// </summary>
        /// <param name="connectionString">数据库连接字符串.</param>
        /// <returns>事务对象.</returns>
        IDbTransaction BeginTransaction(string connectionString, IsolationLevel isolationLevel);

        /// <summary>
        /// 开始一个事务的执行.
        /// </summary>
        /// <param name="conn">数据库连接对象.</param>
        /// <returns></returns>
        IDbTransaction BeginTransaction(IDbConnection conn);

        /// <summary>
        ///  开始一个事务的执行.
        /// </summary>
        /// <param name="isolationLevel"></param>
        /// <returns></returns>
        IDbTransaction BeginTransaction(IDbConnection conn, IsolationLevel isolationLevel);

        /// <summary>
        /// 提交事务执行.
        /// </summary>
        /// <param name="trans">事务对象.</param>
        void CommitTransaction(IDbTransaction trans);

        /// <summary>
        /// 提交事务执行.
        /// </summary>
        /// <param name="trans">事务对象.</param>
        /// <param name="closeConnection">是否主动关闭数据库连接.</param>
        void CommitTransaction(IDbTransaction trans, bool closeConnection);

        /// <summary>
        /// 回滚事务执行.
        /// </summary>
        /// <param name="trans">事务对象.</param>
        void RollbackTransaction(IDbTransaction trans);

        /// <summary>
        /// 回滚事务执行.
        /// </summary>
        /// <param name="trans">事务对象.</param>
        /// <param name="closeConnection">是否主动关闭数据库连接.</param>
        void RollbackTransaction(IDbTransaction trans, bool closeConnection);

        #endregion

        #region 通过IDataReader实例获取Model对象.

        /// <summary>
        /// 从DataReader实例中构造一个Model实例.
        /// </summary>
        /// <param name="dr">DataReader实例.</param>
        /// <returns>Model实例.</returns>
        TModel BuildModel(IDataReader dr);

        /// <summary>
        /// 通过IDataReader实例获取所有的Model对象列表.
        /// </summary>
        /// <param name="dr">Data Reader 实例对象.</param>
        /// <returns>Model对象列表.</returns>
        IList<TModel> GetModels(IDataReader dr);


           /// <summary>
        /// 通过IDataReader实例获取所有的Model对象列表.
        /// </summary>
        /// <param name="dr">Data Reader 实例对象.</param>
        /// <param name="closeDataReader">读取完Model对象后, 是否主动关闭Data Reader实例对象.</param>
        /// <returns>Model对象列表.</returns>
         IList<TModel> GetModels(IDataReader dr, bool closeDataReader);

        /// <summary>
        /// 通过IDataReader实例获取当前页的Model对象列表.
        /// </summary>
        /// <param name="dr">Data Reader 实例对象.</param>
        /// <param name="pageIndex">页码.</param>
        /// <param name="pageSize">每页显示的记录数.</param>
        /// <param name="totalRecords">共获取的记录数.</param>
        /// <returns>当前页的Model对象列表.</returns>
        IList<TModel> GetModels(IDataReader dr, int pageIndex, int pageSize, out int totalRecords);

        /// <summary>
        /// 通过IDataReader实例获取当前页的Model对象列表.
        /// </summary>
        /// <param name="dr">Data Reader 实例对象.</param>
        /// <param name="closeDataReader">读取完Model对象后, 是否主动关闭Data Reader实例对象.</param>
        /// <param name="pageIndex">页码.</param>
        /// <param name="pageSize">每页显示的记录数.</param>
        /// <param name="totalRecords">共获取的记录数.</param>
        /// <returns>当前页的Model对象列表.</returns>
        IList<TModel> GetModels(IDataReader dr, bool closeDataReader, int pageIndex, int pageSize, out int totalRecords);

        #endregion
    }
}
