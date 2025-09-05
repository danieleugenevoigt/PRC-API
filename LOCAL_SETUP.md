# Local Development Setup

This document explains how to set up the PRC API for local development on any machine.

## Prerequisites

- .NET 8.0 SDK
- PostgreSQL access (local or remote)
- VS Code with C# extension

## Configuration Setup

### Step 1: Create Local Configuration

Create a file called `appsettings.Local.json` in the `PRC.Api` folder with your specific settings:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "ConnectionStrings": {
    "DefaultConnection": "Host=YOUR_DB_HOST;Database=prc;Username=YOUR_DB_USER;Password=YOUR_DB_PASSWORD;Port=5432;Timeout=30;CommandTimeout=30;Pooling=true;"
  }
}
```

**Replace the following values:**
- `YOUR_DB_HOST`: IP address of your database server (e.g., `192.168.12.95`)
- `YOUR_DB_USER`: Database username (e.g., `postgres`)
- `YOUR_DB_PASSWORD`: Database password

### Step 2: Create VS Code Launch Configuration (Optional)

If you want to use F5 debugging in VS Code, create `.vscode/launch.json`:

```json
{
  "version": "0.2.0",
  "configurations": [
    {
      "name": ".NET Core Launch (web)",
      "type": "coreclr",
      "request": "launch",
      "preLaunchTask": "build",
      "program": "${workspaceFolder}/PRC.Api/bin/Debug/net8.0/PRC.Api.dll",
      "args": [],
      "cwd": "${workspaceFolder}/PRC.Api",
      "stopAtEntry": false,
      "serverReadyAction": {
        "action": "openExternally",
        "pattern": "\\\\bNow listening on:\\\\s+(http://localhost:\\\\d+)",
        "uriFormat": "%s/swagger"
      },
      "env": {
        "ASPNETCORE_ENVIRONMENT": "Development",
        "ASPNETCORE_LAUNCH_PROFILE": "http"
      }
    }
  ]
}
```

## Running the API

### Option 1: Using VS Code (F5)
1. Open the project folder in VS Code
2. Press F5 to build and run with debugging

### Option 2: Using Terminal
```bash
cd PRC.Api
dotnet run --launch-profile http
```

### Option 3: Using VS Code Tasks
- **Ctrl+Shift+P** → "Tasks: Run Task" → Choose:
  - `build` - Build the project
  - `run-http` - Run with HTTP profile
  - `watch` - Run with hot-reload

## Configuration Priority

The application loads configuration in this order (later files override earlier ones):

1. `appsettings.json` (base configuration)
2. `appsettings.Development.json` (environment-specific)
3. `appsettings.Local.json` (your local settings) ✅
4. Environment variables

## Important Notes

- **Never commit `appsettings.Local.json`** - It contains your local database credentials
- **Never commit `.vscode/launch.json`** - It contains machine-specific paths
- The `tasks.json` file can be shared since it uses generic workspace variables
- The API will run on `http://localhost:5124` by default
- Swagger documentation is available at `http://localhost:5124/swagger`

## Troubleshooting

### Port Already in Use
```bash
# Kill any existing dotnet processes
pkill -f dotnet
```

### Database Connection Issues
- Verify your database server is running and accessible
- Check the connection string in `appsettings.Local.json`
- Ensure firewall allows connections on port 5432
- Test connection with `psql` or another database client

### HTTPS Certificate Issues
- We use HTTP profile to avoid SSL certificate problems in development
- If you need HTTPS, run: `dotnet dev-certs https --trust`

## Network Setup

For multi-machine development:
1. Each developer creates their own `appsettings.Local.json`
2. Update `DB_HOST` to point to the shared database server
3. Ensure all machines can access the database server on port 5432
4. Consider using VPN or network shares for consistent access

## Git Workflow

Safe files to commit:
- ✅ `appsettings.json` (contains defaults, no secrets)
- ✅ `appsettings.Development.json`
- ✅ `.vscode/tasks.json`
- ✅ `launchSettings.json` (contains only localhost URLs)

Never commit:
- ❌ `appsettings.Local.json`
- ❌ `.vscode/launch.json`
- ❌ `.vscode/settings.json`
