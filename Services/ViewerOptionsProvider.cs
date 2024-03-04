using Gizmo.RemoteControl.Server.Abstractions;
using Gizmo.RemoteControl.Server.Models;
using Gizmo.RemoteControl.Shared.Models;

using Microsoft.Extensions.Options;

namespace Gizmo.RemoteControl.Server.Services;

public class ViewerOptionsProvider : IViewerOptionsProvider
{
    private readonly IOptionsMonitor<AppSettingsOptions> _appSettings;

    public ViewerOptionsProvider(IOptionsMonitor<AppSettingsOptions> appSettings)
    {
        _appSettings = appSettings;
    }

    public Task<RemoteControlViewerOptions> GetViewerOptions()
    {
        var options = new RemoteControlViewerOptions()
        {
            ShouldRecordSession = _appSettings.CurrentValue.ShouldRecordSessions
        };

        return Task.FromResult(options);
    }
}
