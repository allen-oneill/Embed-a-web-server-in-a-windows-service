using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

using Nancy;
using Nancy.Hosting.Self;
using System.Net.Sockets;
using System.Net;


namespace NancyWinForm
{
    public class MainMod : NancyModule
    {

        public MainMod(ConfigManager mgr)
        {

            Get["/"] = x =>
            {
                return View["views/skirts.html"];
            };

            Post["/NiceNancy"] = y =>
            {
                if (Request.Form["HowNice"].HasValue)
                {
                    if (Request.Form["HowNice"] == "1")
                    { return View["views/nice.html"]; }
                    else if (Request.Form["HowNice"] == "2")
                    { return View["views/very.html"]; }
                    else return View["views/skirts.html"];
                }
                else return View["views/skirts.html"];
            };

            Get["/config"] = x =>
            {
               //return mgr.config.DateFormat;
                return View["views/config.html",mgr.config];
            };

        }

    }


    public partial class Main : Form
    {

        NancyHost host;

        public Main()
        {
            InitializeComponent();
            int port = 8080;
            // this forces ACL to create network rules for new ports if not already exist
            var hostConfiguration = new HostConfiguration
            {
                UrlReservations = new UrlReservations() { CreateAutomatically = true }
            };
            host = new NancyHost(hostConfiguration, GetUriParams(port));
            host.Start();
        }

        // taken from:  https://groups.google.com/forum/#!topic/nancy-web-framework/GeNBmiDSoME
        private Uri[] GetUriParams(int port)
        {
            var uriParams = new List<Uri>();
            string hostName = Dns.GetHostName();

            // Host name URI
            string hostNameUri = string.Format("http://{0}:{1}", Dns.GetHostName(), port);
            uriParams.Add(new Uri(hostNameUri));

            // Host address URI(s)
            var hostEntry = Dns.GetHostEntry(hostName);
            foreach (var ipAddress in hostEntry.AddressList)
            {
                if (ipAddress.AddressFamily == AddressFamily.InterNetwork)  // IPv4 addresses only
                {
                    var addrBytes = ipAddress.GetAddressBytes();
                    string hostAddressUri = string.Format("http://{0}.{1}.{2}.{3}:{4}", addrBytes[0], addrBytes[1], addrBytes[2], addrBytes[3], port);
                    uriParams.Add(new Uri(hostAddressUri));
                }
            }

            // Localhost URI
            uriParams.Add(new Uri(string.Format("http://localhost:{0}", port)));
            return uriParams.ToArray();
        }


    }


 
}


