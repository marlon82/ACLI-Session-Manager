# ACLI Session Manager

ACLI Session Manager is a modern Windows desktop application for organizing and launching network-device sessions with ACLI. It provides a central, searchable workspace for SSH, Telnet, RDP, and serial connections and is designed for administrators who manage large network environments.

Instead of maintaining connection details in separate files or repeatedly entering addresses and credentials, sessions can be arranged in a folder tree, enriched with device metadata, edited in bulk, and launched into named ACLI container windows.

> **Required:** ACLI Session Manager is a graphical session-management frontend and does not include the ACLI terminal itself. Install [lgastevens/ACLI-terminal](https://github.com/lgastevens/ACLI-terminal) before using ACLI Session Manager.

## Highlights

- Organize thousands of sessions in a hierarchical folder tree
- Launch SSH, Telnet, RDP, and serial connections
- Open multiple sessions sequentially in the same ACLI container window
- Search sessions by name, address, device type, software version, or location
- Select and manage multiple sessions at once
- Edit protocol, port, credentials, profile, interactive mode, sockets, and device description in bulk
- Assign sequential ports to selected sessions
- Move sessions and folders using drag and drop with a confirmation preview
- Display device details such as IP address, model, software version, uptime, location, and port
- Use reusable connection profiles with protected credentials
- Switch between light and dark themes
- Use the interface in English, German, French, or Spanish

## Imports and integrations

### FabricNavigator

ACLI Session Manager can import assigned SSH sessions directly from the secure FabricNavigator API. Imported data can include:

- Device name and IP address
- SSH port and credentials
- Device type and detected platform
- Software version
- SNMP `sysLocation`
- System description

The FabricNavigator API uses a bearer token. Saved API connections and tokens are protected for the current Windows user.

Learn more about FabricNavigator at [github.com/marlon82/FabricNavigator](https://github.com/marlon82/FabricNavigator).

### XIQ-SE

Devices and connection profiles can be imported from XIQ-SE. Linked folders can be synchronized again directly from the session tree. Moving a linked folder also updates the corresponding XIQ-SE profile path.

### SecureCRT

Existing SecureCRT sessions can be converted into the ACLI session hierarchy. SSH, Telnet, and RDP sessions are supported.

## Quick Connect

Quick Connect starts temporary connections without creating permanent session entries. It accepts:

- A single host: `192.168.1.10`
- A comma-separated list: `192.168.1.10,192.168.1.20`
- A range: `192.168.1.1-10`
- Combined ranges and addresses: `192.168.1.203-204,197`

For usability and load control, the application warns before launching more than 20 connections in one ACLI window.

## Serial Port Launcher

The integrated serial launcher detects available Windows COM ports in the background and displays available device information such as port name, device type, and manufacturer. Standard and custom baud rates are supported.

## Credential security

Session passwords, reusable profiles, XIQ-SE profiles, and saved FabricNavigator API tokens are protected with Windows Data Protection API (DPAPI). Protected values are tied to the Windows user account that created them.

When legacy password formats are detected, ACLI Session Manager:

1. Creates a ZIP backup of the complete Sessions folder.
2. Migrates supported session and profile credentials.
3. Verifies the migrated data.
4. Shows the migration result to the user.

For transferring sessions and passwords to another person, use the built-in secure export function. It creates a password-protected transfer package that can be imported and re-protected for the receiving Windows account.

> Do not distribute ordinary session files as a password-sharing mechanism. DPAPI-protected credentials normally cannot be decrypted by another Windows user.

## Requirements

- Windows 10 or Windows 11, 64-bit
- [ACLI Terminal](https://github.com/lgastevens/ACLI-terminal) installed and configured
- `console.exe` available to launch ACLI container windows

ACLI Terminal is required to establish and host the actual terminal connections. ACLI Session Manager manages session definitions, credentials, metadata, and launch commands but does not replace the terminal application.

The published ACLI Session Manager application is a self-contained, single-file executable. A separate .NET runtime installation is not required for the session manager itself.

## Installation

1. Install and configure [ACLI Terminal](https://github.com/lgastevens/ACLI-terminal).
2. Verify that its `console.exe` launcher is available.
3. Download `ACLI Session Manager.exe` from the latest GitHub release.
4. Place the executable in a writable application folder.
5. Start ACLI Session Manager.
6. Review the settings and confirm the ACLI data location.

By default, user-specific ACLI Session Manager data is stored below:

```text
%USERPROFILE%\.acli\ACLISessionManager
```

The application can also create and maintain a user-specific ACLI configuration at:

```text
%USERPROFILE%\.acli\acli.ini
```

## Updates

ACLI Session Manager can check GitHub for new releases. When an update is accepted, the application downloads the release, closes itself, replaces the executable, and restarts automatically. Release notes are displayed before installation.

## Logs

Application and import information is written to:

```text
%USERPROFILE%\.acli\ACLISessionManager\log.txt
```

Update activity is written to `update.log` in the same directory.

## Typical workflow

1. Import sessions from FabricNavigator, XIQ-SE, or SecureCRT, or create them manually.
2. Arrange sessions in folders that reflect sites, buildings, networks, or teams.
3. Use profiles to reuse credentials without duplicating plaintext passwords.
4. Search or multi-select the required devices.
5. Launch them into an existing or newly named ACLI container window.

## Important security notes

- Treat session exports and FabricNavigator API tokens as sensitive data.
- Enable support for self-signed certificates only for FabricNavigator servers you trust.
- Protect transfer-package passwords through a separate communication channel.
- Back up the ACLI data directory before large imports or administrative changes.

## Related project

- [FabricNavigator](https://github.com/marlon82/FabricNavigator) — network discovery, topology, credential assignment, and secure API integration
