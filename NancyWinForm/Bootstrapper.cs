using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy;
using Nancy.Session;
using Nancy.Bootstrapper;
using Nancy.Conventions;
using System.Web.Routing;
using Nancy.TinyIoc;

namespace NancyWinForm
{ 
    public class Bootstrapper : DefaultNancyBootstrapper
    {

        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);
            ConfigManager mgr;
            mgr = new ConfigManager();
            mgr.LoadConfig();
            container.Register<ConfigManager>(mgr);
        }

        protected override Nancy.Bootstrapper.NancyInternalConfiguration InternalConfiguration
        {
            get
            {
                return Nancy.Bootstrapper.NancyInternalConfiguration.Default;
            }
        }

        protected override void ConfigureConventions(NancyConventions nancyConventions)
        {
            base.ConfigureConventions(nancyConventions);

            nancyConventions.StaticContentsConventions.Clear();

            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("css", "/content/css"));
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("js", "/content/js"));
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("images", "/content/img"));
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("fonts", "/content/fonts"));
        }


    }
}
