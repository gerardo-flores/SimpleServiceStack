using ServiceStack.WebHost.Endpoints;
using SimpleServiceStack.Models;
using Funq;
using ServiceStack.Razor;

namespace SimpleServiceStack
{
    public class AppHost : AppHostBase
    {
        /// <summary>
        /// Initializes a new instance of your ServiceStack application, with the specified name and assembly containing the services.
        /// </summary>
        public AppHost() : base("Player Web Service", typeof(PlayerService).Assembly) { }

        /// <summary>
        /// Configure the container with the necessary routes for your ServiceStack application.
        /// </summary>
        /// <param name="container">The built-in IoC used with ServiceStack.</param>
        public override void Configure(Container container)
        {
            //loading Razor plugin to load the client/index.html file as the main file
            Plugins.Add(new RazorFormat());
        }
    }
}