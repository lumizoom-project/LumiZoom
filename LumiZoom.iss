#define MyAppName "LumiZoom"
#define MyAppVersion "1.0.0 RC1"
#define MyAppPublisher "Łukasz Kuczek"
#define MyAppExeName "LumiZoom.exe"

[Setup]
AppId={{93BA52B9-3AE3-4FBF-BB1D-B87C1C789BE9}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL=https://github.com/lumizoom-project/LumiZoom
AppSupportURL=https://github.com/lumizoom-project/LumiZoom/issues
DefaultDirName={autopf}\LumiZoom
DefaultGroupName=LumiZoom
DisableProgramGroupPage=yes
PrivilegesRequired=admin
ArchitecturesAllowed=x64compatible
ArchitecturesInstallIn64BitMode=x64compatible
OutputDir=..\..\outputs\LUMIZOOM-RC1-FINAL
OutputBaseFilename=LumiZoom-1.0-RC1-Setup-STANDARD-v6
SetupIconFile=..\LumiZoom\assets\LumiZoom.ico
UninstallDisplayIcon={app}\LumiZoom.ico
Compression=lzma2/max
SolidCompression=yes
WizardStyle=modern
CloseApplications=yes
CloseApplicationsFilter=LumiZoom.exe
AppMutex=Local\LumiZoom.SingleInstance
VersionInfoVersion=1.0.0.0
VersionInfoCompany={#MyAppPublisher}
VersionInfoDescription=LumiZoom — instalator
VersionInfoProductName={#MyAppName}
VersionInfoProductVersion=1.0.0.0

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"
Name: "polish"; MessagesFile: "compiler:Languages\Polish.isl"

[CustomMessages]
english.AppRunning=LumiZoom is currently running. Close it from the tray icon menu and run the installer again.
polish.AppRunning=LumiZoom jest obecnie uruchomiony. Zamknij go z menu ikony w zasobniku i ponownie uruchom instalator.
english.AlreadyInstalled=LumiZoom version %1 is already installed.%n%nDo you want to update or repair it?
polish.AlreadyInstalled=LumiZoom w wersji %1 jest już zainstalowany.%n%nCzy chcesz go zaktualizować lub naprawić?

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"

[Files]
Source: "..\LumiZoom\bin\Release\net8.0-windows\LumiZoom.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\LumiZoom\bin\Release\net8.0-windows\LumiZoom.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\LumiZoom\bin\Release\net8.0-windows\LumiZoom.deps.json"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\LumiZoom\bin\Release\net8.0-windows\LumiZoom.runtimeconfig.json"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\LumiZoom\assets\LumiZoom.ico"; DestDir: "{app}"; Flags: ignoreversion
Source: "Prepare-LumiZoom.ps1"; DestDir: "{app}"; Flags: ignoreversion

[InstallDelete]
Type: files; Name: "{userdesktop}\LumiZoom.lnk"
Type: files; Name: "{commondesktop}\LumiZoom.lnk"

[Icons]
Name: "{autoprograms}\LumiZoom"; Filename: "{app}\{#MyAppExeName}"; WorkingDir: "{app}"; IconFilename: "{app}\LumiZoom.ico"
Name: "{commondesktop}\LumiZoom"; Filename: "{app}\{#MyAppExeName}"; WorkingDir: "{app}"; IconFilename: "{app}\LumiZoom.ico"; Tasks: desktopicon

[Run]
Filename: "{sys}\WindowsPowerShell\v1.0\powershell.exe"; Parameters: "-NoProfile -ExecutionPolicy Bypass -File ""{app}\Prepare-LumiZoom.ps1"""; StatusMsg: "Przygotowywanie LumiZoom do bezpiecznego działania..."; Flags: runhidden waituntilterminated
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,LumiZoom}"; Flags: shellexec nowait postinstall skipifsilent runasoriginaluser

[UninstallRun]
Filename: "{sys}\taskkill.exe"; Parameters: "/IM LumiZoom.exe /F"; Flags: runhidden; RunOnceId: "StopLumiZoom"

[UninstallDelete]
Type: files; Name: "{app}\Prepare-LumiZoom.ps1"

[Code]
function InitializeSetup(): Boolean;
var
  InstalledVersion: String;
  UninstallKey: String;
begin
  Result := False;

  if CheckForMutexes('Local\LumiZoom.SingleInstance') then
  begin
    MsgBox(ExpandConstant('{cm:AppRunning}'), mbError, MB_OK);
    Exit;
  end;

  UninstallKey := 'Software\Microsoft\Windows\CurrentVersion\Uninstall\{93BA52B9-3AE3-4FBF-BB1D-B87C1C789BE9}_is1';
  if RegQueryStringValue(HKLM64, UninstallKey, 'DisplayVersion', InstalledVersion) then
  begin
    if not WizardSilent then
    begin
      if MsgBox(FmtMessage(ExpandConstant('{cm:AlreadyInstalled}'), [InstalledVersion]),
        mbConfirmation, MB_YESNO) <> IDYES then
        Exit;
    end;
  end;

  Result := True;
end;
