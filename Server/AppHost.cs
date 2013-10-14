using ServiceStack.WebHost.Endpoints;
using SimpleServiceStack.Models;
using Funq;
using ServiceStack.Razor;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.SqlServer;
using ServiceStack.CacheAccess;
using ServiceStack.CacheAccess.Providers;
using ServiceStack.Logging;
using ServiceStack.Logging.NLogger;
using PetaPoco;
using System;

namespace SimpleServiceStack
{
    public class AppHost : AppHostBase
    {
        private static ILog logger;

        /// <summary>
        /// Initializes a new instance of your ServiceStack application, with the specified name and assembly containing the services.
        /// </summary>
        public AppHost() : base("Player Web Service", typeof(PlayerService).Assembly) 
        {
            LogManager.LogFactory = new NLogFactory();
            logger = LogManager.GetLogger(typeof(AppHost));
        }

        /// <summary>
        /// Configure the container with the necessary routes for your ServiceStack application.
        /// </summary>
        /// <param name="container">The built-in IoC used with ServiceStack.</param>
        public override void Configure(Container container)
        {
            //loading Razor plugin to load the client/index.html file as the main file
            Plugins.Add(new RazorFormat());

            container.Register<Database>(new Database("sqlServer"));

            //The MemoryCacheClient is a great way to get started with caching; nothing external to setup.
            container.Register<ICacheClient>(c => new MemoryCacheClient());

            logger.InfoFormat("AppHost Configured: {0}", DateTime.Now);
        }
    }
}