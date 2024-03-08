# REMOTE CONTROL SERVER

## This is a library for the server part of the remote control system.

`It is a server that listens for commands from the client, executes them on the remote machine, and returns the result as a screencast to the client.`

## How to use

### 1. Add libraries to your project as a git submodule

#### &emsp;1.1. Open a command line in your repository root

#### &emsp;1.2. Run the following commands

```bash
git submodule add https://github.com/GAMP/Gizmo.RemoteControl.Shared.git Submodules/Gizmo.RemoteControl.Shared
git submodule add https://github.com/GAMP/Gizmo.RemoteControl.Server.git Submodules/Gizmo.RemoteControl.Server
```

#### &emsp;1.3. Add the libraries to your project

### 2. In the startup of your ASP NET application

#### &emsp;2.1. Add the following using statement

```csharp
using Gizmo.RemoteControl.Server;
```

#### &emsp;2.2. Add the following code to where you configure your services

#### Note:

- _Using CORS is required for the server to accept requests from the client._

```csharp
services.AddRemoteControlServer();
```

#### &emsp;2.3. Add the following code to where you configure your application.

#### Note:

- _This should be added after the `app.UseRouting();` line._
- _If you use Remote Control Viewer on the same server, you should use this one after `app.UseAntiForgery()` and Viewer's `app.UseEndpoints` lines._

```csharp
app.UseRemoteControlServer();
```
