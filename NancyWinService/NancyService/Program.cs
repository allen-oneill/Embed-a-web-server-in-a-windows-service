using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Nancy;
using Nancy.Hosting.Self;
using System.Net.Sockets;
using System.Net;

namespace NancyService
{
    static class Program
    {       
        static void Main()
        {
            NancyHost host;
            string URL = "http://localhost:8080";
            host = new NancyHost(new Uri(URL));
            host.Start();

            //Debug code
            if (!Environment.UserInteractive)
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[] 
            { 
                new Service1() 
            };
                ServiceBase.Run(ServicesToRun);
            }
            else
            {
                Service1 service = new Service1();
                System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);  // forces debug to keep VS running while we debug the service  
            }
        }


    }
}




