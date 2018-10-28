// ============================================================================
// Author:         赵劼
// Create Date:    2018-05-08
// Description:    企业库邮件发送接口
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
        /// 同步发送email.
        /// </summary>
        /// <param name="from">发件人, 不能为空.</param>
        /// <param name="to">收件人, 必须有一个以上的收件人.</param>
        /// <param name="subject">邮件标题.</param>
        /// <param name="body">邮件主体.</param>
        void SyncSend(string from, string[] to, string subject, string body);

        /// <summary>
        /// 同步发送email.
        /// </summary>
        /// <param name="from">发件人, 不能为空.</param>
        /// <param name="to">收件人, 必须有一个以上的收件人.</param>
        /// <param name="subject">邮件标题.</param>
        /// <param name="body">邮件主体.</param>
        /// <param name="isBodyHtml">邮件主体是否为了HTML格式.</param>
        void SyncSend(string from, string[] to, string subject, string body, bool isBodyHtml);

        /// <summary>
        /// 同步发送email.
        /// </summary>
        /// <param name="from">发件人, 不能为空.</param>
        /// <param name="to">收件人, 必须有一个以上的收件人.</param>
        /// <param name="subject">邮件标题.</param>
        /// <param name="body">邮件主体.</param>
        /// <param name="isBodyHtml">邮件主体是否为了HTML格式.</param>
        /// <param name="attachedFilePaths">所绑定的附件路径. 如果所提交的附件路径不存在, 将被过滤.</param>
        void SyncSend(string from, string[] to, string subject, string body, bool isBodyHtml, string[] attachedFilePaths);

        /// <summary>
        /// 同步发送email.
        /// </summary>
        /// <param name="from">发件人, 不能为空.</param>
        /// <param name="to">收件人, 必须有一个以上的收件人.</param>
        /// <param name="cc">抄送人.</param>
        /// <param name="bcc">密送人.</param>
        /// <param name="subject">邮件标题.</param>
        /// <param name="body">邮件主体.</param>
        void SyncSend(string from, string[] to, string[] cc, string[] bcc, string subject, string body);

        /// <summary>
        /// 同步发送email.
        /// </summary>
        /// <param name="from">发件人, 不能为空.</param>
        /// <param name="to">收件人, 必须有一个以上的收件人.</param>
        /// <param name="cc">抄送人.</param>
        /// <param name="bcc">密送人.</param>
        /// <param name="subject">邮件标题.</param>
        /// <param name="body">邮件主体.</param>
        /// <param name="isBodyHtml">邮件主体是否为了HTML格式.</param>
        void SyncSend(string from, string[] to, string[] cc, string[] bcc, string subject, string body, bool isBodyHtml);

        /// <summary>
        /// 同步发送email.
        /// </summary>
        /// <param name="from">发件人, 不能为空.</param>
        /// <param name="to">收件人, 必须有一个以上的收件人.</param>
        /// <param name="cc">抄送人.</param>
        /// <param name="bcc">密送人.</param>
        /// <param name="subject">邮件标题.</param>
        /// <param name="body">邮件主体.</param>
        /// <param name="isBodyHtml">邮件主体是否为了HTML格式.</param>
        /// <param name="attachedFilePaths">所绑定的附件路径. 如果所提交的附件路径不存在, 将被过滤.</param>
        void SyncSend(string from, string[] to, string[] cc, string[] bcc, string subject, string body, bool isBodyHtml, string[] attachedFilePaths);
        
        /// <summary>
        /// 同步发送email.
        /// </summary>
        /// <param name="from">发件人, 不能为空.</param>
        /// <param name="to">收件人, 必须有一个以上的收件人.</param>
        /// <param name="cc">抄送人.</param>
        /// <param name="bcc">密送人.</param>
        /// <param name="subject">邮件标题.</param>
        /// <param name="subjectEncoding">邮件标题使用的编码方式.</param>
        /// <param name="body">邮件主体.</param>
        /// <param name="bodyEncoding">邮件主体所使用的编码方式.</param>
        /// <param name="isBodyHtml">邮件主体是否为了HTML格式.</param>
        /// <param name="attachedFilePaths">所绑定的附件路径. 如果所提交的附件路径不存在, 将被过滤.</param>
        void SyncSend(string from, string[] to, string[] cc, string[] bcc,
            string subject, Encoding subjectEncoding, string body, Encoding bodyEncoding, 
            bool isBodyHtml, string[] attachedFilePaths);


        /// <summary>
        /// 异步发送email.
        /// </summary>
        /// <param name="from">发件人, 不能为空.</param>
        /// <param name="to">收件人, 必须有一个以上的收件人.</param>
        /// <param name="subject">邮件标题.</param>
        /// <param name="body">邮件主体.</param>
        void AsyncSend(string from, string[] to, string subject, string body);

        /// <summary>
        /// 异步发送email.
        /// </summary>
        /// <param name="from">发件人, 不能为空.</param>
        /// <param name="to">收件人, 必须有一个以上的收件人.</param>
        /// <param name="subject">邮件标题.</param>
        /// <param name="body">邮件主体.</param>
        /// <param name="isBodyHtml">邮件主体是否为了HTML格式.</param>
        void AsyncSend(string from, string[] to, string subject, string body, bool isBodyHtml);

        /// <summary>
        /// 异步发送email.
        /// </summary>
        /// <param name="from">发件人, 不能为空.</param>
        /// <param name="to">收件人, 必须有一个以上的收件人.</param>
        /// <param name="subject">邮件标题.</param>
        /// <param name="body">邮件主体.</param>
        /// <param name="isBodyHtml">邮件主体是否为了HTML格式.</param>
        /// <param name="attachedFilePaths">所绑定的附件路径. 如果所提交的附件路径不存在, 将被过滤.</param>
        void AsyncSend(string from, string[] to, string subject, string body, bool isBodyHtml, string[] attachedFilePaths);

        /// <summary>
        /// 异步发送email.
        /// </summary>
        /// <param name="from">发件人, 不能为空.</param>
        /// <param name="to">收件人, 必须有一个以上的收件人.</param>
        /// <param name="subject">邮件标题.</param>
        /// <param name="body">邮件主体.</param>
        /// <param name="isBodyHtml">邮件主体是否为了HTML格式.</param>
        /// <param name="attachedFilePaths">所绑定的附件路径. 如果所提交的附件路径不存在, 将被过滤.</param>
        /// <param name="callbackEventHandler">邮件发送完成后的触发的回调事件代理.</param>
        void AsyncSend(string from, string[] to, string subject, string body, bool isBodyHtml, string[] attachedFilePaths,
            SendEmailCompletedEventHandler callbackEventHandler);

        /// <summary>
        /// 异步发送email.
        /// </summary>
        /// <param name="from">发件人, 不能为空.</param>
        /// <param name="to">收件人, 必须有一个以上的收件人.</param>
        /// <param name="cc">抄送人.</param>
        /// <param name="bcc">密送人.</param>
        /// <param name="subject">邮件标题.</param>
        /// <param name="body">邮件主体.</param>
        void AsyncSend(string from, string[] to, string[] cc, string[] bcc, string subject, string body);

        /// <summary>
        /// 异步发送email.
        /// </summary>
        /// <param name="from">发件人, 不能为空.</param>
        /// <param name="to">收件人, 必须有一个以上的收件人.</param>
        /// <param name="cc">抄送人.</param>
        /// <param name="bcc">密送人.</param>
        /// <param name="subject">邮件标题.</param>
        /// <param name="body">邮件主体.</param>
        /// <param name="isBodyHtml">邮件主体是否为了HTML格式.</param>
        void AsyncSend(string from, string[] to, string[] cc, string[] bcc, string subject, string body, bool isBodyHtml);
        
        /// <summary>
        /// 异步发送email.
        /// </summary>
        /// <param name="from">发件人, 不能为空.</param>
        /// <param name="to">收件人, 必须有一个以上的收件人.</param>
        /// <param name="cc">抄送人.</param>
        /// <param name="bcc">密送人.</param>
        /// <param name="subject">邮件标题.</param>
        /// <param name="body">邮件主体.</param>
        /// <param name="isBodyHtml">邮件主体是否为了HTML格式.</param>
        /// <param name="attachedFilePaths">所绑定的附件路径. 如果所提交的附件路径不存在, 将被过滤.</param>
        void AsyncSend(string from, string[] to, string[] cc, string[] bcc, string subject, string body, bool isBodyHtml,
            string[] attachedFilePaths);

        /// <summary>
        /// 异步发送email.
        /// </summary>
        /// <param name="from">发件人, 不能为空.</param>
        /// <param name="to">收件人, 必须有一个以上的收件人.</param>
        /// <param name="cc">抄送人.</param>
        /// <param name="bcc">密送人.</param>
        /// <param name="subject">邮件标题.</param>
        /// <param name="body">邮件主体.</param>
        /// <param name="isBodyHtml">邮件主体是否为了HTML格式.</param>
        /// <param name="attachedFilePaths">所绑定的附件路径. 如果所提交的附件路径不存在, 将被过滤.</param>
        /// <param name="callbackEventHandler">邮件发送完成后的触发的回调事件代理.</param>
        void AsyncSend(string from, string[] to, string[] cc, string[] bcc, string subject, string body, bool isBodyHtml,
            string[] attachedFilePaths, SendEmailCompletedEventHandler callbackEventHandler);

        /// <summary>
        /// 异步发送email.
        /// </summary>
        /// <param name="from">发件人, 不能为空.</param>
        /// <param name="to">收件人, 必须有一个以上的收件人.</param>
        /// <param name="cc">抄送人.</param>
        /// <param name="bcc">密送人.</param>
        /// <param name="subject">邮件标题.</param>
        /// <param name="subjectEncoding">邮件标题使用的编码方式.</param>
        /// <param name="body">邮件主体.</param>
        /// <param name="bodyEncoding">邮件主体所使用的编码方式.</param>
        /// <param name="isBodyHtml">邮件主体是否为了HTML格式.</param>
        /// <param name="attachedFilePaths">所绑定的附件路径. 如果所提交的附件路径不存在, 将被过滤.</param>
        /// <param name="callbackEventHandler">邮件发送完成后的触发的回调事件代理.</param>
        void AsyncSend(string from, string[] to, string[] cc, string[] bcc,
            string subject, Encoding subjectEncoding, string body, Encoding bodyEncoding, bool isBodyHtml,
            string[] attachedFilePaths, SendEmailCompletedEventHandler callbackEventHandler);
    }
}
