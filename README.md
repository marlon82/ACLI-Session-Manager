<p align="center">
  <img src="docs/images/netops-workspace.png" alt="NetOps Workspace" width="112">
</p>

<h1 align="center">NetOps Workspace</h1>

<p align="center">
  A unified Windows workspace for network sessions, terminal access, monitoring, remote desktops and secure file transfers.
</p>

<p align="center">
  <a href="../../releases/latest">Download</a> ·
  <a href="../../issues">Report an issue</a> ·
  <a href="https://github.com/lgastevens/ACLI-terminal">ACLI Terminal</a>
</p>

## What is NetOps Workspace?

NetOps Workspace is a Windows desktop application for network administrators who manage many switches, routers, servers and remote systems. It combines session organization, device inventory, terminal access and operational tools in one searchable interface.

Sessions can be organized in a hierarchical tree, enriched with device metadata, edited in bulk and launched through SSH, Telnet, RDP, serial or web-based access. Integrated workspaces for terminal sessions, ping monitoring, Remote Desktop and secure file transfer reduce the need to switch between separate utilities.

NetOps Workspace is the successor to **ACLI Session Manager**. Existing installations and data remain supported through the built-in migration and compatibility update process.

## Key features

| Area | Capabilities |
| --- | --- |
| **Session management** | Organize thousands of sessions in folders, search by multiple attributes, use multi-selection, drag and drop, clone sessions and perform bulk edits. |
| **Integrated terminal** | Open multiple ACLI sessions in tabs, create adjustable split views, search terminal output, customize syntax highlighting and use programmable command buttons. |
| **Ping Monitor** | Monitor multiple hosts with live latency graphs, packet-loss statistics, time ranges, history navigation, configurable intervals and optional CSV recording. |
| **RDP workspace** | Open multiple Remote Desktop sessions as tabs in a dedicated window and adapt them to the available workspace. |
| **File Transfer** | Browse local and remote files using SFTP/SCP, manage transfer queues and perform multi-device uploads or structured bulk downloads. |
| **Inventory views** | Display device type, software version, uptime, location, address, protocol and port information in tree tooltips and detail tables. |
| **Imports and synchronization** | Import and synchronize devices from XIQ-SE and FabricNavigator, or migrate existing SecureCRT sessions. |
| **Profiles and credentials** | Reuse protected connection profiles, migrate legacy credentials and create encrypted packages for transfer to another Windows user. |
| **Automation-friendly tools** | Assign sequential ports, run actions against multiple devices and collect logs, configurations, archives and Fabric Engine fulltech files. |

## Session and inventory management

- Hierarchical folder tree for sites, buildings, networks or teams
- SSH, Telnet, RDP, serial, HTTPS and related operational actions
- Fast search by name, IP address, device type, software version and location
- Boolean-style search combinations for narrowing or combining results
- Multi-selection from the tree, search results and detail tables
- Bulk editing of protocol, address, port, profile, credentials, sockets, interactive mode, device type and containing window
- Sequential port assignment for selected sessions
- Drag-and-drop moves with a confirmation preview
- Sortable detail and inventory tables
- Folder summaries for sessions, subfolders, device types and software versions

## Integrated terminal

The integrated terminal provides an alternative to ConsoleZ while retaining ConsoleZ as a selectable option.

- Multiple terminal tabs and separately named terminal windows
- Horizontal and vertical split views with adjustable dividers
- Renameable and reorderable tabs
- Search across the active terminal or split view
- Match-case and whole-word search options
- Configurable dark- and light-mode syntax colors
- Editable syntax-highlighting rules and ACLI aliases
- Custom command buttons displayed at the bottom of the terminal
- Terminal zoom, scrollback and controllable output following
- Clipboard copy on selection and paste by right-click
- Optional prompt removal when pasting copied command output
- Activity indication for background tabs

> ACLI-based terminal connections require [lgastevens/ACLI-terminal](https://github.com/lgastevens/ACLI-terminal). NetOps Workspace can detect the installation, show component versions and assist with installing or updating ACLI when required.

## Ping Monitor

The Ping Monitor can track multiple targets in one dedicated window.

- Live latency, minimum, maximum and average response times
- Packet-loss and timeout statistics
- Configurable ping interval
- Graph ranges from 60 seconds to 24 hours or the complete history
- Scrollable and Fit All layouts
- Shared history navigation across all visible graphs
- Pause, resume and restart controls per target
- Optional CSV recording for later analysis
- Hostname resolution with the resolved IP address displayed separately

## Integrated RDP workspace

- Open several RDP sessions as tabs in one window
- Reuse the current RDP window size for newly opened sessions
- Resize sessions with the workspace and use full-screen mode
- Launch RDP directly from the session tree, detail view or Quick Connect
- Disable terminal-specific options automatically for RDP connections

## Secure file transfer

The File Transfer workspace uses the credentials already assigned to a session.

- Tabbed SFTP/SCP sessions for multiple devices
- Explorer-style local and remote file browsers
- Upload, download, synchronization and reconnect actions
- Transfer queue with device, direction, paths, progress, speed, ETA and status
- Multi-device upload of one selected file
- Bulk download into a separate folder for each device
- Optional ZIP archive per device
- Collection of logs, configurations, hidden diagnostic files and Fabric Engine fulltech output
- Optional `save config` and complete configuration archive creation on supported Fabric Engine devices

## Imports and synchronization

### XIQ-SE

Import devices and connection data from one or more XIQ-SE systems. Imported folders can be synchronized directly from the session tree. Device metadata can include model, software version, uptime and location.

### FabricNavigator

Import assigned SSH sessions through the secure FabricNavigator API and keep linked folders synchronized. Saved API connections and tokens are protected for the current Windows user.

Learn more at [marlon82/FabricNavigator](https://github.com/marlon82/FabricNavigator).

### SecureCRT

Convert existing SecureCRT SSH, Telnet and RDP sessions into the NetOps Workspace folder structure.

## Quick Connect and serial access

Quick Connect starts temporary sessions without creating permanent entries. It accepts a single host, comma-separated hosts and address ranges:

```text
192.168.1.10
192.168.1.10,192.168.1.20
192.168.1.1-10
192.168.1.203-204,197
```

The Serial Launcher discovers Windows COM ports in the background, displays available device details and supports standard or custom baud rates.

## Credential security

Passwords, connection profiles and saved API credentials are protected with the Windows Data Protection API (DPAPI). Protected values are tied to the Windows user account that created them.

When legacy password data is detected, NetOps Workspace:

1. Creates a ZIP backup of the complete sessions folder.
2. Migrates supported session and profile credentials.
3. Verifies the migrated data.
4. Shows a detailed result to the user.

Use **Export secure package** when sessions and credentials must be transferred to another user. The receiving user imports the protected package and the credentials are secured again for their own Windows account.

## Requirements

- Windows 10 or Windows 11, 64-bit
- No separate .NET installation is required for the published self-contained executable
- [ACLI Terminal](https://github.com/lgastevens/ACLI-terminal) for ACLI-based SSH and Telnet terminal connections
- Network access and suitable credentials for external integrations

## Installation

1. Download `NetOps Workspace.exe` from the latest GitHub release.
2. Place it in a writable application folder.
3. Start the application.
4. If ACLI is missing, use the offered installation assistant or select an existing installation under **Settings > ACLI**.
5. Review the data location, theme, language and terminal preferences.

The application is distributed as a self-contained, single-file executable.

## Updating from ACLI Session Manager

Older installations can update through the compatibility package. The transition build starts under the legacy executable name once, creates `NetOps Workspace.exe` beside it and removes the obsolete executable after a successful restart.

New releases use the JSON-based `NetOpsWorkspace.update` manifest with file-size and SHA-256 verification. Stable and Beta update channels can be selected in the application settings.

## Data and logs

User-specific data remains in the compatibility location:

```text
%USERPROFILE%\.acli\ACLISessionManager
```

The user-specific ACLI configuration is stored at:

```text
%USERPROFILE%\.acli\acli.ini
```

Application activity is written to `log.txt`; update activity is written to `update.log` in the application data directory.

## Languages and appearance

- English
- German
- French
- Spanish
- Light and dark themes

## Security notes

- Treat exported session packages and API tokens as sensitive data.
- Enable self-signed certificate support only for systems you trust.
- Share transfer-package passwords through a separate communication channel.
- Back up the data directory before large imports or administrative changes.
- Review generated diagnostic files before sharing them outside your organization.

## Related projects

- [lgastevens/ACLI-terminal](https://github.com/lgastevens/ACLI-terminal) — terminal engine used for ACLI-based connections
- [marlon82/FabricNavigator](https://github.com/marlon82/FabricNavigator) — network discovery, topology and secure API integration

## Feedback

NetOps Workspace is under active development. Bug reports and feature requests are welcome through the repository's [issue tracker](../../issues).
