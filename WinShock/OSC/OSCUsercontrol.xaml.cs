using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Wpf.Ui.Common;
using Newtonsoft.Json;

namespace WinShock.OSC;

public partial class OSCUsercontrol : UserControl
{
    private bool Chatbox;

    private bool Hoscy;
    private string SendPort = "9000";

    private string HoscySendPort = "9001"; //default for hoscy

    public OSCUsercontrol()
    {
        InitializeComponent();
    }

    private void UpdateConfigPart()
    {
        var configPath = Path.Combine(Environment.CurrentDirectory, "config.json");
        var config = JsonConvert.DeserializeObject<ConfigManager.Config>(File.ReadAllText(configPath));
        config.OSC = new OSCConfig
        {
            Chatbox = Chatbox,
            Hoscy = Hoscy,
            SendPort = SendPort,
            HoscySendPort = HoscySendPort
        };
        File.WriteAllText(configPath, JsonConvert.SerializeObject(config, Formatting.Indented));
    }

    private void OSCUsercontrol_OnLoaded(object sender, RoutedEventArgs e)
    {
        var mainWindow = (MainWindow)Application.Current.MainWindow;
        mainWindow.OSCBtn.Appearance = ControlAppearance.Success;
        UpdateConfigPart();
    }

    private void UseHoscyCheckbox_OnChecked(object sender, RoutedEventArgs e)
    {
        SendPortTextBox.Visibility = Visibility.Collapsed;
        NormalPortTxt.Visibility = Visibility.Visible;
        SendPortTextBox.Text = "9001";
        NormalPortTxt.Text = "9001";
        Hoscy = true;
        UpdateConfigPart();
    }

    private void UseHoscyCheckbox_OnUnchecked(object sender, RoutedEventArgs e)
    {
        NormalPortTxt.Visibility = Visibility.Visible;
        SendPortTextBox.Visibility = Visibility.Visible;
        SendPortTextBox.Text = "9000";
        NormalPortTxt.Text = "9000";
        Hoscy = false;
        UpdateConfigPart();
    }

    private void SendPortTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        if (!int.TryParse(SendPortTextBox.Text, out _))
        {
            SendPortTextBox.Text = "9000";
            SendPort = "9000";
            UpdateConfigPart();
        }

        if (SendPortTextBox.Text.Length > 4)
        {
            SendPortTextBox.Text = "9000";
            SendPort = "9000";
            UpdateConfigPart();
        }

        NormalPortTxt.Text = SendPortTextBox.Text;
        SendPort = SendPortTextBox.Text;
        UpdateConfigPart();
    }

    private void ChatboxBoolCheckBox_OnChecked(object sender, RoutedEventArgs e)
    {
        Chatbox = true;
        UpdateConfigPart();
    }

    private void ChatboxBoolCheckBox_OnUnchecked(object sender, RoutedEventArgs e)
    {
        Chatbox = false;
        UpdateConfigPart();
    }
}