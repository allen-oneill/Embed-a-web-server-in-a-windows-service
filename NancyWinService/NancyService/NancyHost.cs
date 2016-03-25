using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy;
using Nancy.Hosting.Self;
using System.Net.Sockets;
using System.Net;

namespace NancyService
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
                return View["views/config.html", mgr.config];
            };

        }

    }
}
