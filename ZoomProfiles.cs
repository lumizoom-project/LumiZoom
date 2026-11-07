using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Win32;

namespace LumiZoom
{
 sealed partial class TrayContext
 {
  const string ProfileSettingsPath = @"Software\TrayLiveZoom\ZoomProfiles";

  string ProfileText(string polish, string english) => languageMode == 1 ? polish : english;


  void AddZoomProfilesMenu()
  {
   var entries = new System.Collections.Generic.List<ToolStripItem>();
   trayMenu.Opening += delegate
   {
    foreach (var entry in entries) entry.Dispose();
    entries.Clear();
    foreach (string name in ProfileNames())
    {
     int? percent = ReadZoomProfile(name);
     if (!percent.HasValue) continue;
     if (entries.Count == 0)
     {
      var separator = new ToolStripSeparator();
      entries.Add(separator);
      trayMenu.Items.Add(separator);
     }
     var entry = new ToolStripMenuItem(name.Replace("&", "&&") + $" — {percent}%", null, delegate { UseZoomProfile(name); })
     {
      Enabled = optionsForm == null || optionsForm.IsDisposed,
      BackColor = trayMenu.BackColor, ForeColor = trayMenu.ForeColor
     };
     entries.Add(entry);
     trayMenu.Items.Add(entry);
    }
   };
  }

  string[] ProfileNames()
  {
   try
   {
    using var key = Registry.CurrentUser.OpenSubKey(ProfileSettingsPath);
    return (key?.GetValueNames() ?? Array.Empty<string>())
     .Where(name => name.Length > 0).OrderBy(name => name, StringComparer.CurrentCultureIgnoreCase).ToArray();
   }
   catch (Exception ex) when (IsProfileStorageError(ex)) { return Array.Empty<string>(); }
  }

  void AddProfileControls(Form owner, Control page, NumericUpDown magnification)
  {
   var panel = new FlowLayoutPanel { Left = 18, Top = 137, Width = 490,
    Height = 77,
    FlowDirection = FlowDirection.TopDown, WrapContents = false };
   var firstRow = new FlowLayoutPanel { AutoSize = true, WrapContents = false, Margin = Padding.Empty };
   var secondRow = new FlowLayoutPanel { AutoSize = true, WrapContents = false, Margin = Padding.Empty };
   var save = new Button { AutoSize = true };
   var choice = new ComboBox { Width = 230, DropDownStyle = ComboBoxStyle.DropDownList };
   var delete = new Button { AutoSize = true };
   string[] names = Array.Empty<string>();
   void RefreshChoices()
   {
    names = ProfileNames();
    choice.Items.Clear();
    choice.Items.AddRange(names);
    if (names.Length > 0) choice.SelectedIndex = 0;
    delete.Enabled = choice.SelectedIndex >= 0;
   }
   void UpdateLabels()
   {
    save.Text = ProfileText("Zapisz profil…", "Save profile…");
    delete.Text = ProfileText("Usuń profil", "Delete profile");
    choice.AccessibleName = ProfileText("Profil do usunięcia", "Profile to delete");
   }
   save.Click += delegate { PromptForProfileName(owner, (int)magnification.Value); RefreshChoices(); };
   delete.Click += delegate
   {
    if (choice.SelectedIndex < 0) return;
    string name = names[choice.SelectedIndex];
    if (MessageBox.Show(owner, ProfileText($"Usunąć profil „{name}”?", $"Delete profile “{name}”?"),
      "LumiZoom", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes) return;
    try
    {
     using var key = Registry.CurrentUser.OpenSubKey(ProfileSettingsPath, true);
     key?.DeleteValue(name, false);
     RefreshChoices();
    }
    catch (Exception ex) when (IsProfileStorageError(ex))
    {
     MessageBox.Show(owner, ProfileText("Nie udało się usunąć profilu.", "Could not delete the profile."), "LumiZoom");
    }
   };
   owner.FontChanged += delegate { UpdateLabels(); };
   firstRow.Controls.Add(save);
   secondRow.Controls.AddRange(new Control[] { choice, delete });
   panel.Controls.AddRange(new Control[] { firstRow, secondRow });
   page.Controls.Add(panel);
   UpdateLabels();
   RefreshChoices();
  }

  void PromptForProfileName(Form owner, int percent)
  {
   using var dialog = new Form { Text = ProfileText("Zapisz profil", "Save profile"), AutoSize = true,
    AutoSizeMode = AutoSizeMode.GrowAndShrink, FormBorderStyle = FormBorderStyle.FixedDialog,
    MaximizeBox = false, MinimizeBox = false, StartPosition = FormStartPosition.CenterScreen,
    Font = trayMenu.Font, AutoScaleMode = AutoScaleMode.Dpi };
   var layout = new FlowLayoutPanel { Dock = DockStyle.Fill, AutoSize = true, WrapContents = false,
    FlowDirection = FlowDirection.TopDown, Padding = new Padding(12) };
   var label = new Label { AutoSize = true, Text = ProfileText("Nazwa profilu:", "Profile name:") };
   var nameField = new TextBox { Width = 320, MaxLength = 40, AccessibleName = label.Text };
   var buttons = new FlowLayoutPanel { AutoSize = true, WrapContents = false };
   var save = new Button { AutoSize = true, Text = ProfileText("Zapisz", "Save"), Enabled = false };
   var cancel = new Button { AutoSize = true, Text = ProfileText("Anuluj", "Cancel"), DialogResult = DialogResult.Cancel };
   nameField.TextChanged += delegate
   {
    string name = nameField.Text.Trim();
    save.Enabled = name.Length > 0;
   };
   save.Click += delegate
   {
    string name = nameField.Text.Trim();
    if (ReadZoomProfile(name).HasValue && MessageBox.Show(dialog,
      ProfileText("Zastąpić zapisane powiększenie w tym profilu?", "Replace the magnification saved in this profile?"),
      dialog.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes) return;
    if (SaveZoomProfile(name, percent)) dialog.DialogResult = DialogResult.OK;
   };
   buttons.Controls.AddRange(new Control[] { save, cancel });
   layout.Controls.AddRange(new Control[] { label, nameField, buttons });
   dialog.Controls.Add(layout);
   dialog.AcceptButton = save;
   dialog.CancelButton = cancel;
   dialog.ActiveControl = nameField;
   ApplyTheme(dialog);
   dialog.ShowDialog(owner);
  }

  int? ReadZoomProfile(string name)
  {
   try
   {
    using var key = Registry.CurrentUser.OpenSubKey(ProfileSettingsPath);
    if (key?.GetValue(name) is int percent && percent >= 100 && percent <= 1000)
     return percent;
   }
   catch (Exception ex) when (IsProfileStorageError(ex)) { }
   return null;
  }

  static bool IsProfileStorageError(Exception ex) =>
   ex is UnauthorizedAccessException || ex is System.Security.SecurityException || ex is System.IO.IOException;

  bool SaveZoomProfile(string name, int percent)
  {
   try
   {
    using var key = Registry.CurrentUser.CreateSubKey(ProfileSettingsPath);
    key.SetValue(name, percent, RegistryValueKind.DWord);
    return true;
   }
   catch (Exception ex) when (IsProfileStorageError(ex))
   {
    MessageBox.Show(ProfileText("Nie udało się zapisać profilu.", "Could not save the zoom profile."), "LumiZoom");
    return false;
   }
  }

  void UseZoomProfile(string name)
  {
   int? percent = ReadZoomProfile(name);
   if (!percent.HasValue) return;
   try
   {
    using var key = Registry.CurrentUser.CreateSubKey(@"Software\TrayLiveZoom");
    key.SetValue("ZoomPercent", percent.Value, RegistryValueKind.DWord);
   }
   catch (Exception ex) when (IsProfileStorageError(ex))
   {
    MessageBox.Show(ProfileText("Nie udało się zastosować profilu.", "Could not apply the zoom profile."), "LumiZoom");
    return;
   }
   zoom = percent.Value;
   if (!enabled)
   {
    Toggle();
    return;
   }
   fromLevel = level;
   toLevel = zoom / 100f;
   animationStart = DateTime.UtcNow;
   animating = true;
   timer.Start();
   tray.Text = $"LumiZoom — {name} {zoom}%";
  }
 }
}
