using System;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace XinYu.WCF.Proxy
{
    public static class ProxyUtil
    {
        #region 服务工厂
        public static T CreateChannelFactory<T>(string url)
        {
            return CreateChannelFactory<T>(url, "basichttpbinding");
        }

        public static T CreateChannelFactory<T>(string url, string bind)
        {
            ChannelFactory<T> channelFactory = null;
            var address = new EndpointAddress(url);
            var binding = CreateBinding(bind);
            try
            {
                channelFactory = new ChannelFactory<T>(binding, address);

            }
            catch (Exception ex)
            {
                if (channelFactory != null)
                    channelFactory.Close();

                return default(T);
            }

            return channelFactory.CreateChannel();
        }
        #endregion

        #region 创建传输协议
        /// <summary>  
        /// 创建传输协议  
        /// </summary>  
        /// <param name="binding">传输协议名称</param>  
        private static Binding CreateBinding(string binding)
        {
            Binding bindInstance = null;
            switch (binding.ToLower())
            {
                case "basichttpbinding":
                    {
                        var bind = new BasicHttpBinding
                        {
                            CloseTimeout = TimeSpan.MaxValue,
                            OpenTimeout = TimeSpan.MaxValue,
                            ReceiveTimeout = TimeSpan.MaxValue,
                            SendTimeout = TimeSpan.MaxValue,
                            Security = { Mode = BasicHttpSecurityMode.None },
                            MaxBufferPoolSize = 2147483647,
                            MaxBufferSize = 2147483647,
                            MaxReceivedMessageSize = 2147483647,
                            ReaderQuotas = new System.Xml.XmlDictionaryReaderQuotas()
                            {
                                MaxStringContentLength = 655360000,
                                MaxArrayLength = 163840,
                                MaxDepth = 320,
                                MaxBytesPerRead = 40960,
                                MaxNameTableCharCount = 163840
                            }
                        };

                        bindInstance = bind;
                    }
                    break;
                case "netnamedpipebinding":
                    {
                        var bind = new NetNamedPipeBinding { MaxReceivedMessageSize = 65535000 };
                        bindInstance = bind;
                    }
                    break;
                case "nettcpbinding":
                    {
                        var bind = new NetTcpBinding
                        {
                            CloseTimeout = TimeSpan.MaxValue,
                            OpenTimeout = TimeSpan.MaxValue,
                            ReceiveTimeout = TimeSpan.MaxValue,
                            SendTimeout = TimeSpan.MaxValue,
                            MaxBufferPoolSize = 2147483647,
                            MaxBufferSize = 2147483647,
                            MaxConnections = 10,
                            MaxReceivedMessageSize = 2147483647,
                            ListenBacklog = 100,
                            ReaderQuotas = new System.Xml.XmlDictionaryReaderQuotas()
                            {
                                MaxStringContentLength = 655360000,
                                MaxArrayLength = 163840,
                                MaxDepth = 320,
                                MaxBytesPerRead = 40960,
                                MaxNameTableCharCount = 163840
                            },
                            Security = { Mode = SecurityMode.None }
                        };

                        bindInstance = bind;
                    }
                    break;
                case "wsfederationhttpbinding":
                    {
                        var bind = new WSFederationHttpBinding { MaxReceivedMessageSize = 65535000 };
                        bindInstance = bind;
                    }
                    break;
                case "wshttpbinding":
                    {
                        var ws = new WSHttpBinding(SecurityMode.None) { MaxReceivedMessageSize = 65535000 };
                        ws.Security.Message.ClientCredentialType = MessageCredentialType.Windows;
                        ws.Security.Transport.ClientCredentialType = HttpClientCredentialType.Windows;
                        bindInstance = ws;
                    }
                    break;
            }
            return bindInstance;

        }
        #endregion

        #region 通信异常关闭
        public static void Using<T>(this T client, Exception ex, string errorMsg)
            where T : ICommunicationObject
        {
            ((ICommunicationObject)client).Abort();
        }
        #endregion
    }
}
