using System;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace XinYu.WCF.Service
{
    public class ServiceHostHelper
    {
        public static void OpenBasicHttpHost<S, C>(
               string serviceName, string ip, int port, ref ServiceHost serviceHost) where S : class, C, new()
        {
            var baseAddress = new Uri(string.Format("http://{0}:{1}", ip, port));
            var metaUrl = string.Format("http://{0}:{1}/metadata", ip, port + 1);

            serviceHost = new ServiceHost(typeof(S), baseAddress);

            var basicBinding = new BasicHttpBinding
            {
                CloseTimeout = TimeSpan.MaxValue,
                OpenTimeout = TimeSpan.MaxValue,
                ReceiveTimeout = TimeSpan.MaxValue,
                SendTimeout = TimeSpan.MaxValue,

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
                },
                Security = { Mode = BasicHttpSecurityMode.None }
            };

            serviceHost.AddServiceEndpoint(typeof(C), basicBinding, serviceName);

            var throttlingBehavior = serviceHost.Description.Behaviors.Find<ServiceThrottlingBehavior>();
            if (null == throttlingBehavior)
            {
                throttlingBehavior = new ServiceThrottlingBehavior();
                serviceHost.Description.Behaviors.Add(throttlingBehavior);
            }

            throttlingBehavior.MaxConcurrentCalls = 50;
            throttlingBehavior.MaxConcurrentInstances = 30;
            throttlingBehavior.MaxConcurrentSessions = 20;

            if (serviceHost.Description.Behaviors.Find<ServiceMetadataBehavior>() == null)
            {
                var behavior = new ServiceMetadataBehavior()
                {
                    HttpGetEnabled = true,
                    HttpGetUrl = new Uri(metaUrl)
                };
                serviceHost.Description.Behaviors.Add(behavior);
            }

            //加载MEX元数据结点
            serviceHost.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexHttpBinding(), "MEX");

            if (serviceHost.Description.Behaviors.Find<ServiceDebugBehavior>() == null)
            {
                var behavior = new ServiceDebugBehavior()
                {
                    IncludeExceptionDetailInFaults = true
                };
                serviceHost.Description.Behaviors.Add(behavior);
            }
            else
            {
                var behavior = serviceHost.Description.Behaviors.Find<ServiceDebugBehavior>();
                behavior.IncludeExceptionDetailInFaults = true;
            }

            if (serviceHost.State != CommunicationState.Opened)
            {
                serviceHost.Opened += delegate { };
                serviceHost.Open();
            }
        }

        public static void OpenNetTcpHost<S, C>(
       string serviceName, string ip, int port, ref ServiceHost serviceHost) where S : class, C, new()
        {
            var baseAddress = new Uri(string.Format("net.tcp://{0}:{1}", ip, port));
            var metaUrl = string.Format("http://{0}:{1}/metadata", ip, port + 1);

            serviceHost = new ServiceHost(typeof(S), baseAddress);

            var nettcpBinding = new NetTcpBinding
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
                Security = { Mode = SecurityMode.None },
                PortSharingEnabled = true
            };

            serviceHost.AddServiceEndpoint(typeof(C), nettcpBinding, serviceName);

            var throttlingBehavior = serviceHost.Description.Behaviors.Find<ServiceThrottlingBehavior>();
            if (null == throttlingBehavior)
            {
                throttlingBehavior = new ServiceThrottlingBehavior();
                serviceHost.Description.Behaviors.Add(throttlingBehavior);
            }

            throttlingBehavior.MaxConcurrentCalls = 50;
            throttlingBehavior.MaxConcurrentInstances = 30;
            throttlingBehavior.MaxConcurrentSessions = 20;

            if (serviceHost.Description.Behaviors.Find<ServiceMetadataBehavior>() == null)
            {
                var behavior = new ServiceMetadataBehavior()
                {
                    HttpGetEnabled = true,
                    HttpGetUrl = new Uri(metaUrl)
                };
                serviceHost.Description.Behaviors.Add(behavior);
            }

            //加载MEX元数据结点
            //serviceHost.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexTcpBinding(), "MEX");

            if (serviceHost.Description.Behaviors.Find<ServiceDebugBehavior>() == null)
            {
                var behavior = new ServiceDebugBehavior()
                {
                    IncludeExceptionDetailInFaults = true
                };
                serviceHost.Description.Behaviors.Add(behavior);
            }
            else
            {
                var behavior = serviceHost.Description.Behaviors.Find<ServiceDebugBehavior>();
                behavior.IncludeExceptionDetailInFaults = true;
            }

            if (serviceHost.State != CommunicationState.Opened)
            {
                serviceHost.Opened += delegate { };
                serviceHost.Open();
            }
        }

        private static void ServiceHostBehavior(ServiceHost serviceHost, string metaUrl)
        {
            var throttlingBehavior = serviceHost.Description.Behaviors.Find<ServiceThrottlingBehavior>();
            if (null == throttlingBehavior)
            {
                throttlingBehavior = new ServiceThrottlingBehavior();
                serviceHost.Description.Behaviors.Add(throttlingBehavior);
            }

            throttlingBehavior.MaxConcurrentCalls = 50;
            throttlingBehavior.MaxConcurrentInstances = 30;
            throttlingBehavior.MaxConcurrentSessions = 20;

            if (serviceHost.Description.Behaviors.Find<ServiceMetadataBehavior>() == null)
            {
                var behavior = new ServiceMetadataBehavior()
                {
                    HttpGetEnabled = true,
                    HttpGetUrl = new Uri(metaUrl)
                };
                serviceHost.Description.Behaviors.Add(behavior);
            }

            //加载MEX元数据结点
            serviceHost.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexHttpBinding(), "MEX");

            if (serviceHost.Description.Behaviors.Find<ServiceDebugBehavior>() == null)
            {
                var behavior = new ServiceDebugBehavior()
                {
                    IncludeExceptionDetailInFaults = true
                };
                serviceHost.Description.Behaviors.Add(behavior);
            }
            else
            {
                var behavior = serviceHost.Description.Behaviors.Find<ServiceDebugBehavior>();
                behavior.IncludeExceptionDetailInFaults = true;
            }
        }

        public static void CloseHost(ServiceHost serviceHost)
        {
            if (serviceHost != null && serviceHost.State != CommunicationState.Closed)
            {
                serviceHost.Close();
            }
        }

        public static CommunicationState? WcfServiceState(ServiceHost serviceHost)
        {
            if (serviceHost != null)
            {
                return serviceHost.State;
            }

            return null;
        }
    }
}
