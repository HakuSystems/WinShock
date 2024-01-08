using System;
using System.IO;
using System.Windows;
using Newtonsoft.Json;
using WinShock.Behaviour;
using WinShock.OSC;

namespace WinShock;

public sealed class ConfigManager
{
    private const string CONFIG_FILE_NAME = "config.json";
    private static readonly Lazy<ConfigManager> _instance = new(() => new ConfigManager());

    public static ConfigManager Instance => _instance.Value;

    public Config AppConfig { get; private set; }

    private ConfigManager()
    {
        LoadConfig();
    }

    public sealed class Config
    {
        public OSCConfig OSC { get; set; }
        public BehaviourConfig Behaviour { get; set; }
        public string LastIgnoredVersion { get; set; } = null;
    }

    private void LoadConfig()
    {
        try
        {
            var configPath = Path.Combine(Environment.CurrentDirectory, CONFIG_FILE_NAME);
            if (!File.Exists(configPath))
            {
                AppConfig = new Config
                {
                    OSC = new OSCConfig(),
                    Behaviour = new BehaviourConfig()
                };
                File.WriteAllText(configPath, JsonConvert.SerializeObject(AppConfig, Formatting.Indented));
            }
            else
            {
                AppConfig = JsonConvert.DeserializeObject<Config>(File.ReadAllText(configPath));
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error while loading config: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            throw;
        }
    }
    public void UpdateOSC(OSCConfig oscConfig)
    {
        AppConfig.OSC = oscConfig;
        SaveChanges();
    }
    public void UpdateBehaviour(BehaviourConfig newConfig)
    {
        AppConfig.Behaviour = newConfig;
        SaveChanges();
    }
    private void SaveChanges()
    {
        var path = Path.Combine(Environment.CurrentDirectory, CONFIG_FILE_NAME);
        var jsonData = JsonConvert.SerializeObject(AppConfig, Formatting.Indented);
        File.WriteAllText(path, jsonData);
    }
}