// ============================================================================
// Author:         赵劼
// Create Date:    2018-05-08
// Description:    企业库队列处理接口
// Modify History: 
// ============================================================================

using System.Messaging;

namespace XinYu.Framework.Library.Interface
{
    /// <summary>
    /// Represents a message queue.
    /// </summary>
    public interface IMessageQueue
    {
        /// <summary>
        /// Receive message from Message Queue Instance.
        /// </summary>
        Message Receive();

        /// <summary>
        /// Receive message from Message Queue Instance.
        /// </summary>
        /// <typeparam name="TObject">Type of return value.</typeparam>
        /// <returns>Received message object.</returns>
        TObject Receive<TObject>();

        /// <summary>
        /// Derived classes may call this from their own Send methods that
        /// accept meaningful objects.
        /// </summary>
        void Send(object msg);
    }
}
