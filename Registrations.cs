using Gizmo.RemoteControl.Server.Extensions;
using Gizmo.RemoteControl.Server.Hubs;
using Gizmo.RemoteControl.Server.Services;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Gizmo.RemoteControl.Server
{
    public static class Registrations
    {
        public static IServiceCollection AddRemoteControlServer(this IServiceCollection services) => services
            //.AddCors(options => options.AddPolicy("RemoteControlServer", policy =>
            //    policy
            //        .AllowAnyOrigin()
            //        .AllowAnyMethod()
            //        .AllowAnyHeader()
            //        .AllowCredentials()))
            .AddRemoteControlServer(config =>
            {
                config.AddHubEventHandler<HubEventHandler>();
                config.AddViewerAuthorizer<ViewerAuthorizer>();
                config.AddViewerPageDataProvider<ViewerPageDataProvider>();
                config.AddViewerOptionsProvider<ViewerOptionsProvider>();
                config.AddSessionRecordingSink<SessionRecordingSink>();
            });

        /// <summary>
        /// <para>
        ///     Maps Razor pages and SignalR hubs.  The remote control viewer page will be mapped
        ///     to path "/RemoteControl/Viewer", the desktop hub to "/hubs/desktop", and viewer hub
        ///     to "/hubs/viewer".
        /// </para>
        /// <para>
        ///     Important: This must be called after "app.UseRouting()".
        /// </para>
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseRemoteControlServer(this IApplicationBuilder app) => app
            //.UseCors("RemoteControlServer")
            .UseEndpoints(config =>
            {
                config.MapHub<DesktopHub>("/hubs/desktop");
                config.MapHub<ViewerHub>("/hubs/viewer");
            });
    }
}
