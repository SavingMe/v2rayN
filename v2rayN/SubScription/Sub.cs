using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;

namespace SubScription
{
    public class Sub
    {
        public static string GetAndPrintIPv6Addresses(string netInterfaceName = "ETH0", string perfix = "2409")
        {
            Console.WriteLine($"Fetching IP addresses at {DateTime.Now}:");

            foreach (NetworkInterface netInterface in NetworkInterface.GetAllNetworkInterfaces())
            {
                // 检查网络接口是否处于活动状态
                if (netInterface.OperationalStatus == OperationalStatus.Up)
                {
                    // 获取所有的IP地址信息
                    IPInterfaceProperties properties = netInterface.GetIPProperties();
                    foreach (UnicastIPAddressInformation ipInfo in properties.UnicastAddresses)
                    {
                        // 筛选出IPv6地址
                        if (ipInfo.Address.AddressFamily == AddressFamily.InterNetworkV6)
                        {
                            Console.WriteLine($"Interface {netInterface.Name}: {ipInfo.Address}");
                            if (netInterface.Name.Contains(netInterfaceName) && ipInfo.Address.ToString().StartsWith(perfix))
                            {
                                return ipInfo.Address.ToString();
                            }
                        }
                    }
                }
            }
            return null;
        }
    }
}
