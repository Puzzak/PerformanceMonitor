using System;
using System.Diagnostics;
using System.Threading;
using System.Net;
using System.IO;
using System.Net.NetworkInformation;
using System.Management;


//Here is code for Performance Monitor
//by Puzzak
//See more @ https://github.com/Puzzak/PerformanceMonitor/new/master


namespace PerformanceMonitor
{
    class Program
    {
        static void Main(string[] args)
        {
            string GetMacAddress()
            {
                string macAddresses = string.Empty;

                foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
                {
                    if (nic.OperationalStatus == OperationalStatus.Up)
                    {
                        macAddresses += nic.GetPhysicalAddress().ToString();
                        break;
                    }
                }

                return macAddresses;
            }
            PerformanceCounter cpuCounter;
            PerformanceCounter ramCounter;

            cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            ramCounter = new PerformanceCounter("Memory", "Available MBytes");

            string Query = "SELECT Capacity FROM Win32_PhysicalMemory";
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(Query);

            UInt64 Capacity = 0;
            foreach (ManagementObject WniPART in searcher.Get())
            {
                Capacity += Convert.ToUInt64(WniPART.Properties["Capacity"].Value);
            }


            Console.WriteLine("Mac: "+GetMacAddress());
            Console.SetWindowSize(20, 1);
            Console.SetCursorPosition(0, 0);
            int i = 0;
            while (true) {
                string a = "cpu=" + (int)cpuCounter.NextValue() + "&freeram=" + (int)ramCounter.NextValue()+"&mac="+GetMacAddress()+"&totalram="+Capacity;
                    string link = "https://projects.HumanZ.space/PM/in.php?" + a;
                    i++;
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(link);
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    Stream resStream = response.GetResponseStream();
                    Console.Clear();
                    Console.WriteLine("Mac: " + GetMacAddress());
                    Console.WriteLine("Connections: " + i + ".");
                    Console.SetWindowSize(20, 2);
                    Console.SetCursorPosition(0, 0);
                
                Thread.Sleep(1000);

            }
            Console.ReadLine();
        }
    }
}
