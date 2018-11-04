using System.Collections.Generic;

namespace XinYu.Framework.Membership.BLL
{
    /// <summary>
    /// Tree class.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Tree<T>
    {
        T item;
        IDictionary<int, Tree<T>> subList;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="subList"></param>
        public Tree(T item, IDictionary<int, Tree<T>> subList)
        {
            this.item = item;
            this.subList = subList;
        }

        public T Item
        {
            get { return this.item; }
        }

        public IDictionary<int, Tree<T>> SubList
        {
            get { return this.subList; }
        }
    }
}
