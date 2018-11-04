// ============================================================================
// Author:         �Ԅ�
// Create Date:    2018-05-08
// Description:    ��ҵ���ʼ����ͽӿ�
// Modify History: 
// ============================================================================

using System.ComponentModel;
using System.Text;

namespace XinYu.Framework.Library.Interface
{
    public delegate void SendEmailCompletedEventHandler(object sender, AsyncCompletedEventArgs e);

    /// <summary>
    /// Represents a email sender.
    /// </summary>
    public interface IEmailSender
    {
        /// <summary>
        /// ͬ������email.
        /// </summary>
        /// <param name="from">������, ����Ϊ��.</param>
        /// <param name="to">�ռ���, ������һ�����ϵ��ռ���.</param>
        /// <param name="subject">�ʼ�����.</param>
        /// <param name="body">�ʼ�����.</param>
        void SyncSend(string from, string[] to, string subject, string body);

        /// <summary>
        /// ͬ������email.
        /// </summary>
        /// <param name="from">������, ����Ϊ��.</param>
        /// <param name="to">�ռ���, ������һ�����ϵ��ռ���.</param>
        /// <param name="subject">�ʼ�����.</param>
        /// <param name="body">�ʼ�����.</param>
        /// <param name="isBodyHtml">�ʼ������Ƿ�Ϊ��HTML��ʽ.</param>
        void SyncSend(string from, string[] to, string subject, string body, bool isBodyHtml);

        /// <summary>
        /// ͬ������email.
        /// </summary>
        /// <param name="from">������, ����Ϊ��.</param>
        /// <param name="to">�ռ���, ������һ�����ϵ��ռ���.</param>
        /// <param name="subject">�ʼ�����.</param>
        /// <param name="body">�ʼ�����.</param>
        /// <param name="isBodyHtml">�ʼ������Ƿ�Ϊ��HTML��ʽ.</param>
        /// <param name="attachedFilePaths">���󶨵ĸ���·��. ������ύ�ĸ���·��������, ��������.</param>
        void SyncSend(string from, string[] to, string subject, string body, bool isBodyHtml, string[] attachedFilePaths);

        /// <summary>
        /// ͬ������email.
        /// </summary>
        /// <param name="from">������, ����Ϊ��.</param>
        /// <param name="to">�ռ���, ������һ�����ϵ��ռ���.</param>
        /// <param name="cc">������.</param>
        /// <param name="bcc">������.</param>
        /// <param name="subject">�ʼ�����.</param>
        /// <param name="body">�ʼ�����.</param>
        void SyncSend(string from, string[] to, string[] cc, string[] bcc, string subject, string body);

        /// <summary>
        /// ͬ������email.
        /// </summary>
        /// <param name="from">������, ����Ϊ��.</param>
        /// <param name="to">�ռ���, ������һ�����ϵ��ռ���.</param>
        /// <param name="cc">������.</param>
        /// <param name="bcc">������.</param>
        /// <param name="subject">�ʼ�����.</param>
        /// <param name="body">�ʼ�����.</param>
        /// <param name="isBodyHtml">�ʼ������Ƿ�Ϊ��HTML��ʽ.</param>
        void SyncSend(string from, string[] to, string[] cc, string[] bcc, string subject, string body, bool isBodyHtml);

        /// <summary>
        /// ͬ������email.
        /// </summary>
        /// <param name="from">������, ����Ϊ��.</param>
        /// <param name="to">�ռ���, ������һ�����ϵ��ռ���.</param>
        /// <param name="cc">������.</param>
        /// <param name="bcc">������.</param>
        /// <param name="subject">�ʼ�����.</param>
        /// <param name="body">�ʼ�����.</param>
        /// <param name="isBodyHtml">�ʼ������Ƿ�Ϊ��HTML��ʽ.</param>
        /// <param name="attachedFilePaths">���󶨵ĸ���·��. ������ύ�ĸ���·��������, ��������.</param>
        void SyncSend(string from, string[] to, string[] cc, string[] bcc, string subject, string body, bool isBodyHtml, string[] attachedFilePaths);
        
        /// <summary>
        /// ͬ������email.
        /// </summary>
        /// <param name="from">������, ����Ϊ��.</param>
        /// <param name="to">�ռ���, ������һ�����ϵ��ռ���.</param>
        /// <param name="cc">������.</param>
        /// <param name="bcc">������.</param>
        /// <param name="subject">�ʼ�����.</param>
        /// <param name="subjectEncoding">�ʼ�����ʹ�õı��뷽ʽ.</param>
        /// <param name="body">�ʼ�����.</param>
        /// <param name="bodyEncoding">�ʼ�������ʹ�õı��뷽ʽ.</param>
        /// <param name="isBodyHtml">�ʼ������Ƿ�Ϊ��HTML��ʽ.</param>
        /// <param name="attachedFilePaths">���󶨵ĸ���·��. ������ύ�ĸ���·��������, ��������.</param>
        void SyncSend(string from, string[] to, string[] cc, string[] bcc,
            string subject, Encoding subjectEncoding, string body, Encoding bodyEncoding, 
            bool isBodyHtml, string[] attachedFilePaths);


        /// <summary>
        /// �첽����email.
        /// </summary>
        /// <param name="from">������, ����Ϊ��.</param>
        /// <param name="to">�ռ���, ������һ�����ϵ��ռ���.</param>
        /// <param name="subject">�ʼ�����.</param>
        /// <param name="body">�ʼ�����.</param>
        void AsyncSend(string from, string[] to, string subject, string body);

        /// <summary>
        /// �첽����email.
        /// </summary>
        /// <param name="from">������, ����Ϊ��.</param>
        /// <param name="to">�ռ���, ������һ�����ϵ��ռ���.</param>
        /// <param name="subject">�ʼ�����.</param>
        /// <param name="body">�ʼ�����.</param>
        /// <param name="isBodyHtml">�ʼ������Ƿ�Ϊ��HTML��ʽ.</param>
        void AsyncSend(string from, string[] to, string subject, string body, bool isBodyHtml);

        /// <summary>
        /// �첽����email.
        /// </summary>
        /// <param name="from">������, ����Ϊ��.</param>
        /// <param name="to">�ռ���, ������һ�����ϵ��ռ���.</param>
        /// <param name="subject">�ʼ�����.</param>
        /// <param name="body">�ʼ�����.</param>
        /// <param name="isBodyHtml">�ʼ������Ƿ�Ϊ��HTML��ʽ.</param>
        /// <param name="attachedFilePaths">���󶨵ĸ���·��. ������ύ�ĸ���·��������, ��������.</param>
        void AsyncSend(string from, string[] to, string subject, string body, bool isBodyHtml, string[] attachedFilePaths);

        /// <summary>
        /// �첽����email.
        /// </summary>
        /// <param name="from">������, ����Ϊ��.</param>
        /// <param name="to">�ռ���, ������һ�����ϵ��ռ���.</param>
        /// <param name="subject">�ʼ�����.</param>
        /// <param name="body">�ʼ�����.</param>
        /// <param name="isBodyHtml">�ʼ������Ƿ�Ϊ��HTML��ʽ.</param>
        /// <param name="attachedFilePaths">���󶨵ĸ���·��. ������ύ�ĸ���·��������, ��������.</param>
        /// <param name="callbackEventHandler">�ʼ�������ɺ�Ĵ����Ļص��¼�����.</param>
        void AsyncSend(string from, string[] to, string subject, string body, bool isBodyHtml, string[] attachedFilePaths,
            SendEmailCompletedEventHandler callbackEventHandler);

        /// <summary>
        /// �첽����email.
        /// </summary>
        /// <param name="from">������, ����Ϊ��.</param>
        /// <param name="to">�ռ���, ������һ�����ϵ��ռ���.</param>
        /// <param name="cc">������.</param>
        /// <param name="bcc">������.</param>
        /// <param name="subject">�ʼ�����.</param>
        /// <param name="body">�ʼ�����.</param>
        void AsyncSend(string from, string[] to, string[] cc, string[] bcc, string subject, string body);

        /// <summary>
        /// �첽����email.
        /// </summary>
        /// <param name="from">������, ����Ϊ��.</param>
        /// <param name="to">�ռ���, ������һ�����ϵ��ռ���.</param>
        /// <param name="cc">������.</param>
        /// <param name="bcc">������.</param>
        /// <param name="subject">�ʼ�����.</param>
        /// <param name="body">�ʼ�����.</param>
        /// <param name="isBodyHtml">�ʼ������Ƿ�Ϊ��HTML��ʽ.</param>
        void AsyncSend(string from, string[] to, string[] cc, string[] bcc, string subject, string body, bool isBodyHtml);
        
        /// <summary>
        /// �첽����email.
        /// </summary>
        /// <param name="from">������, ����Ϊ��.</param>
        /// <param name="to">�ռ���, ������һ�����ϵ��ռ���.</param>
        /// <param name="cc">������.</param>
        /// <param name="bcc">������.</param>
        /// <param name="subject">�ʼ�����.</param>
        /// <param name="body">�ʼ�����.</param>
        /// <param name="isBodyHtml">�ʼ������Ƿ�Ϊ��HTML��ʽ.</param>
        /// <param name="attachedFilePaths">���󶨵ĸ���·��. ������ύ�ĸ���·��������, ��������.</param>
        void AsyncSend(string from, string[] to, string[] cc, string[] bcc, string subject, string body, bool isBodyHtml,
            string[] attachedFilePaths);

        /// <summary>
        /// �첽����email.
        /// </summary>
        /// <param name="from">������, ����Ϊ��.</param>
        /// <param name="to">�ռ���, ������һ�����ϵ��ռ���.</param>
        /// <param name="cc">������.</param>
        /// <param name="bcc">������.</param>
        /// <param name="subject">�ʼ�����.</param>
        /// <param name="body">�ʼ�����.</param>
        /// <param name="isBodyHtml">�ʼ������Ƿ�Ϊ��HTML��ʽ.</param>
        /// <param name="attachedFilePaths">���󶨵ĸ���·��. ������ύ�ĸ���·��������, ��������.</param>
        /// <param name="callbackEventHandler">�ʼ�������ɺ�Ĵ����Ļص��¼�����.</param>
        void AsyncSend(string from, string[] to, string[] cc, string[] bcc, string subject, string body, bool isBodyHtml,
            string[] attachedFilePaths, SendEmailCompletedEventHandler callbackEventHandler);

        /// <summary>
        /// �첽����email.
        /// </summary>
        /// <param name="from">������, ����Ϊ��.</param>
        /// <param name="to">�ռ���, ������һ�����ϵ��ռ���.</param>
        /// <param name="cc">������.</param>
        /// <param name="bcc">������.</param>
        /// <param name="subject">�ʼ�����.</param>
        /// <param name="subjectEncoding">�ʼ�����ʹ�õı��뷽ʽ.</param>
        /// <param name="body">�ʼ�����.</param>
        /// <param name="bodyEncoding">�ʼ�������ʹ�õı��뷽ʽ.</param>
        /// <param name="isBodyHtml">�ʼ������Ƿ�Ϊ��HTML��ʽ.</param>
        /// <param name="attachedFilePaths">���󶨵ĸ���·��. ������ύ�ĸ���·��������, ��������.</param>
        /// <param name="callbackEventHandler">�ʼ�������ɺ�Ĵ����Ļص��¼�����.</param>
        void AsyncSend(string from, string[] to, string[] cc, string[] bcc,
            string subject, Encoding subjectEncoding, string body, Encoding bodyEncoding, bool isBodyHtml,
            string[] attachedFilePaths, SendEmailCompletedEventHandler callbackEventHandler);
    }
}
