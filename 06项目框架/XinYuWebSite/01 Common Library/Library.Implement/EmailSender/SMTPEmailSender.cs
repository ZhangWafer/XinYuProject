using System;
using System.ComponentModel;
using System.Net;
using System.Net.Mail;
using System.Text;
using XinYu.Framework.Library.Interface;

namespace XinYu.Framework.Library.Implement.EmailSender
{
    /// <summary>
    /// The class is to provide common method to send email.
    /// </summary>
    public class SMTPEmailSender : AbstractEmailSender
    {
        private static SmtpClient mailDispatcher;
        private static object syncMailDispatcher = new object();

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="host">邮件服务器主机IP.</param>
        /// <param name="port">邮件服务器端口.</param>
        public SMTPEmailSender(string host, ushort port)
            : this(host, port, false)
        { }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="host">邮件服务器主机IP.</param>
        /// <param name="port">邮件服务器端口.</param>
        /// <param name="enableSsl">指定邮件发送是否使用SSL加密.</param>
        public SMTPEmailSender(string host, ushort port, bool enableSsl)
            : this(host, port, enableSsl, false, string.Empty, string.Empty)
        { }        

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="host">邮件服务器主机IP.</param>
        /// <param name="port">邮件服务器端口.</param>
        /// <param name="enableSsl">指定邮件发送是否使用SSL加密.</param>
        /// <param name="requiredLogin">指定邮件服务器是否需要进行使用验证.</param>
        /// <param name="loginAccount">邮件服务器验证帐号.</param>
        /// <param name="loginPassword">邮件服务器验证密码.</param>
        public SMTPEmailSender(string host, ushort port, bool enableSsl, bool requiredLogin, string loginAccount, string loginPassword)
        {
            // Build a SMTP instance.
            lock (syncMailDispatcher)
            {
                mailDispatcher = new SmtpClient(host, port);
                mailDispatcher.EnableSsl = enableSsl;
                
                if (requiredLogin)
                    mailDispatcher.Credentials = new NetworkCredential(loginAccount, loginPassword);

                mailDispatcher.SendCompleted += new SendCompletedEventHandler(mailDispatcher_Async_SendCompleted);
             }
        }

        public override void SyncSend(string from, string[] to, string[] cc, string[] bcc, string subject, Encoding subjectEncoding, 
            string body, Encoding bodyEncoding, bool isBodyHtml, string[] attachedFilePaths)
        {
            MailMessage mail = this.assembleMail(MailPriority.Normal, from, to, cc, bcc, subject, subjectEncoding,
                body, bodyEncoding, isBodyHtml, attachedFilePaths);

            mailDispatcher.Send(mail);
        }

        public override void AsyncSend(string from, string[] to, string[] cc, string[] bcc, string subject, Encoding subjectEncoding,
            string body, Encoding bodyEncoding, bool isBodyHtml, string[] attachedFilePaths, 
            SendEmailCompletedEventHandler callbackEventHandler)
        {
            MailMessage mail = this.assembleMail(MailPriority.Normal, from, to, cc, bcc, subject, subjectEncoding,
                body, bodyEncoding, isBodyHtml, attachedFilePaths);

            lock (syncMailDispatcher)
            {
                mailDispatcher.SendAsync(mail, callbackEventHandler);
            }
        }

        #region Private methods.
        
        /// <summary>
        /// Assemble a MailMessage instance.
        /// </summary>
        /// <param name="priority">Mail priority.</param>
        /// <param name="from">From. Not null.</param>
        /// <param name="toes">To. Not null and at least has one recipient.</param>
        /// <param name="cc">CC.</param>
        /// <param name="bcc">Bcc.</param>
        /// <param name="subject">Email subject.</param>
        /// <param name="subjectEncoding"></param>
        /// <param name="body">Email body.</param>
        /// <param name="bodyEncoding"></param>
        /// <param name="isBodyHtml">Indicate the body format is plane text format or HTML format.</param>
        /// <param name="attachedFilePaths">Attachment file name array.</param>
        /// <returns>A MailMessage instance.</returns>
        private MailMessage assembleMail(MailPriority priority, string from, string[] toes, string[] cc, string[] bcc,
            string subject, Encoding subjectEncoding, string body, Encoding bodyEncoding, bool isBodyHtml, string[] attachedFilePaths)
        {
            // Check these parameters.
            if (!System.Enum.IsDefined(typeof(MailPriority), priority))
                throw new ArgumentException(Properties.Resources.InvalidEnumerationValue, "priority");            
            if (string.IsNullOrEmpty(from))
                throw new ArgumentNullException("from");
            if (toes == null || toes.Length == 0)
                throw new ArgumentNullException("toes");

            MailMessage mail = new MailMessage();
            
            // Specify the e-mail from.
            mail.From = new MailAddress(from);
            
            // Set destinations for the e-mail message.
            if (toes != null)
            {
                foreach (string to in toes)
                {
                    if (!string.IsNullOrEmpty(to))
                        mail.To.Add(new MailAddress(to.Trim()));
                }
            }
            
            if (cc != null)
            {
                foreach (string acc in cc)
                {
                    if (!string.IsNullOrEmpty(acc.Trim()))
                        mail.CC.Add(acc.Trim());
                }
            }
            
            if (bcc != null)
            {
                foreach (string abcc in bcc)
                {
                    if (!string.IsNullOrEmpty(abcc))
                        mail.Bcc.Add(abcc.Trim());
                }
            }
            
            // Specify the message content.
            mail.Subject = subject;
            mail.SubjectEncoding = subjectEncoding;
            mail.Body = body;
            mail.BodyEncoding = bodyEncoding;
            mail.IsBodyHtml = isBodyHtml;
            
            // Create the file attachment for this e-mail message.
            if (attachedFilePaths != null)
            {
                foreach (string afp in attachedFilePaths)
                {
                    // Filter invalided attached file.
                    if (!string.IsNullOrEmpty(afp) && System.IO.File.Exists(afp))
                    {
                        Attachment attachmentData = new Attachment(afp);
                        
                        // Add time stamp information for the file.
                        attachmentData.ContentDisposition.CreationDate = System.IO.File.GetCreationTime(afp);
                        attachmentData.ContentDisposition.ModificationDate = System.IO.File.GetLastWriteTime(afp);
                        attachmentData.ContentDisposition.ReadDate = System.IO.File.GetLastAccessTime(afp);
                        
                        // Add the file attachment to this e-mail message.
                        mail.Attachments.Add(attachmentData);
                    }
                }
            }
            
            return mail;
        }

        /// <summary>
        /// Event handler method when a mail has completed sent.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mailDispatcher_Async_SendCompleted(object sender, AsyncCompletedEventArgs e)
        {
            // Get the unique identifier for this asynchronous operation.
            SendEmailCompletedEventHandler callback = e.UserState as SendEmailCompletedEventHandler;

            if (callback != null)
                callback(this, e);
        }
        #endregion
    }
}
