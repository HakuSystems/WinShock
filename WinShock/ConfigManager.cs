using System;
using System.IO;
using Newtonsoft.Json;
using WinShock.OSC;

namespace WinShock;

public class ConfigManager
{
    public class Config
    {
        public OSCConfig OSC { get; set; }
    }
}