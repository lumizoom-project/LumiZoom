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
- tray icon operation and optional Windows startup;
- emergency `Esc` key to leave magnification;
- single-instance protection.

## Download

Download the latest installer from the [Releases](https://github.com/lumizoom-project/LumiZoom/releases) page. Windows may display a warning for early unsigned/publicly untrusted releases. The RC installer creates a local trusted certificate required by Windows UIAccess so mouse clicks remain correctly mapped while zoomed.

## System requirements

- Windows 10 or Windows 11, 64-bit;
- .NET 8 Desktop Runtime;
- administrator permission during installation.

Windows 7 is not supported by the current application platform and magnification input API.

## Default shortcut

`Ctrl + Alt + Shift + 9`

You can change it in **Settings → Main**.

## Building

1. Install the .NET 8 SDK.
2. Run `dotnet build LumiZoom.csproj -c Release`.
3. To build the Windows installer, install Inno Setup 6 and compile `LumiZoom.iss`.

## Privacy

LumiZoom has no telemetry, analytics, advertisements or online account requirement. See [Privacy](PRIVACY.md).

## Author and contact

Created by **Łukasz Kuczek**.  
Contact: [lumizoom.project@gmail.com](mailto:lumizoom.project@gmail.com)

## License

LumiZoom is released under the [MIT License](LICENSE).

