using System;
using System.Net.Sockets;
using System.ServiceModel;

namespace XinYu.WCF.Proxy
{
    public static class ProxyUtilEx
    {
        public static string FaultMessage = "获取数据服务失败...";

        public static void Using<T>(this T client, Action<T> work)
            where T : ICommunicationObject
        {
            try
            {
                work(client);
                client.Close();
            }
            catch (EndpointNotFoundException ex)
            {
                client.Abort();
            }
            catch (CommunicationException ex)
            {
                client.Abort();
            }
            catch (TimeoutException ex)
            {
                client.Abort();
            }
            catch (SocketException ex)
            {
                client.Abort();
            }
            catch (Exception ex)
            {
                client.Abort();
            }
        }


        public static void Invoke<TContract>(TContract proxy, Action<TContract> action)
        {
            var comObj = proxy as ICommunicationObject;
            if (comObj == null) return;
            try
            {
                action(proxy);
                comObj.Close();
            }
            catch (EndpointNotFoundException ex)
            {
                comObj.Abort();
            }
            catch (CommunicationException ex)
            {
                comObj.Abort();
            }
            catch (TimeoutException ex)
            {
                comObj.Abort();
            }
            catch (SocketException ex)
            {
                comObj.Abort();
            }
            catch (Exception ex)
            {
                comObj.Abort();
            }
        }

        public static TReturn Invoke<TContract, TReturn>(TContract proxy, Func<TContract, TReturn> func)
        {
            var returnValue = default(TReturn);

            var comObj = proxy as ICommunicationObject;
            if (comObj != null)
            {
                try
                {
                    returnValue = func(proxy);
                    comObj.Close();
                }
                catch (EndpointNotFoundException ex)
                {
                    comObj.Abort();
                }
                catch (CommunicationException ex)
                {
                    comObj.Abort();
                }
                catch (TimeoutException ex)
                {
                    comObj.Abort();
                }
                catch (SocketException ex)
                {
                    comObj.Abort();
                }
                catch (Exception ex)
                {
                    comObj.Abort();
                }
            }

            return returnValue;
        }
    }
}
