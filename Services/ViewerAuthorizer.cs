using Gizmo.RemoteControl.Server.Abstractions;

using Microsoft.AspNetCore.Mvc.Filters;

namespace Gizmo.RemoteControl.Server.Services;

public class ViewerAuthorizer : IViewerAuthorizer
{
    public string UnauthorizedRedirectUrl => "/Error";

    public Task<bool> IsAuthorized(AuthorizationFilterContext context)
    {
        return Task.FromResult(true);
    }
}
