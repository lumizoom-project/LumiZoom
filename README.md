<p align="center">
  <img src="lumizoom-logo-horizontal.svg" alt="LumiZoom" width="520">
</p>

# LumiZoom

[Polski](README.pl.md) · **English**

LumiZoom is a free, open-source live screen magnifier for Windows. It is designed primarily for people with low vision and older computer users who need a simple, comfortable way to magnify the whole desktop without a permanent magnifier window.

## Highlights

- smooth full-screen zoom in and zoom out;
- configurable fixed zoom level;
- mouse pointer tracking with optional centre lock;
- configurable tracking speed and animation duration;
- optional coloured cursor highlight with adjustable colour and opacity;
- configurable global keyboard shortcut;
- light, dark and system themes;
- three interface font sizes;
- multilingual interface;
- tray icon operation and Windows startup enabled by default;
- emergency `Esc` key to leave magnification;
- single-instance protection.

## Screenshots

The screenshots show the English settings window; they focus on the app itself, not the full desktop.

<p align="center">
  <img src="store-listing/en-US/1366px/01-main.png" alt="Main magnification settings" width="48%">
  <img src="store-listing/en-US/1366px/02-cursor.png" alt="Cursor highlighting settings" width="48%">
</p>
<p align="center">
  <img src="store-listing/en-US/1366px/03-program.png" alt="Startup and program settings" width="48%">
  <img src="store-listing/en-US/1366px/04-appearance.png" alt="Appearance settings" width="48%">
</p>
<p align="center">
  <img src="store-listing/en-US/1366px/05-about.png" alt="About LumiZoom" width="48%">
</p>

## Download

### [Download LumiZoom 1.0 RC2 for Windows 10/11 (64-bit)](https://github.com/lumizoom-project/LumiZoom/raw/refs/heads/main/dist/LumiZoom-1.0-RC2-Setup.exe)

The recommended installer is self-contained and does not require .NET to be installed separately.

- [RC2 installer — EXE](https://github.com/lumizoom-project/LumiZoom/raw/refs/heads/main/dist/LumiZoom-1.0-RC2-Setup.exe)
- [RC2 package — ZIP](https://github.com/lumizoom-project/LumiZoom/raw/refs/heads/main/dist/LumiZoom-1.0-RC2-Setup.zip)
- [All releases and older versions](https://github.com/lumizoom-project/LumiZoom/releases)
- [SHA-256 checksums](dist/SHA256SUMS.txt)

Windows may display a warning for early unsigned/publicly untrusted releases. The RC installer creates a local trusted certificate required by Windows UIAccess so mouse clicks remain correctly mapped while zoomed.

## System requirements

- Windows 10 or Windows 11, 64-bit;
- administrator permission during installation.

The installer is self-contained and does not require a separate .NET installation.

Windows 7 is not supported by the current application platform and magnification input API.

## Default shortcut

`Ctrl + Alt + Shift + 9`

You can change it in **Settings → Main**.

## Building

1. Install the .NET 8 SDK.
2. Run `dotnet publish LumiZoom.csproj -c Release -r win-x64 --self-contained true`.
3. To build the Windows installer, install Inno Setup 6 and compile `LumiZoom.iss`.

## Privacy

LumiZoom has no telemetry, analytics, advertisements or online account requirement. See [Privacy](PRIVACY.md).

## Author and contact

Created by **Łukasz Kuczek**.  
Contact: [lumizoom.project@gmail.com](mailto:lumizoom.project@gmail.com)

## License

LumiZoom is released under the [MIT License](LICENSE).
