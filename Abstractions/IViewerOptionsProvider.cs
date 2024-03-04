using Gizmo.RemoteControl.Shared.Models;

namespace Gizmo.RemoteControl.Server.Abstractions;

/// <summary>
/// Provides options related to how the viewer front-end should behave.
/// </summary>
public interface IViewerOptionsProvider
{
    Task<RemoteControlViewerOptions> GetViewerOptions();
}
