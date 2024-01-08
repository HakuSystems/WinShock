using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using Newtonsoft.Json;
using Wpf.Ui.Common;

namespace WinShock.Behaviour;

public partial class BehaviourUserControl : UserControl
{
    public bool RandomIntensity { get; set; }
    public bool RandomDuration { get; set; }
    public int RandomDurationStep { get; set; }
    public Range DurationRange { get; set; }
    public Range IntensityRange { get; set; }
    public int FixedIntensity { get; set; }
    public int FixedDuration { get; set; }
    public int HoldTime { get; set; }
    public int CooldownTime { get; set; }
    public string WhileBoneHeld { get; set; }
    public bool DisableWhileAfk { get; set; }
    public bool ForceUnmute { get; set; }
    
    public BehaviourUserControl()
    {
        InitializeComponent();
    }

    private void BehaviourUserControl_OnLoaded(object sender, RoutedEventArgs e)
    {
        var mainWindow = (MainWindow)Application.Current.MainWindow;
        mainWindow.BehaviorBtn.Appearance = ControlAppearance.Success;
        UpdateConfig();
    }

    private void UpdateConfig()
    {
        var config = new BehaviourConfig
        {
            RandomIntensity = RandomIntensity,
            RandomDuration = RandomDuration,
            RandomDurationStep = RandomDurationStep,
            DurationRange = DurationRange,
            IntensityRange = IntensityRange,
            FixedIntensity = FixedIntensity,
            FixedDuration = FixedDuration,
            HoldTime = HoldTime,
            CooldownTime = CooldownTime,
            WhileBoneHeld = WhileBoneHeld,
            DisableWhileAfk = DisableWhileAfk,
            ForceUnmute = ForceUnmute
        };
        ConfigManager.Instance.UpdateBehaviour(config);
    }
    private void RandomIntensityCheckbox_OnChecked(object sender, RoutedEventArgs e)
    {
        IntensityRangeSlider.IsEnabled = true;
        FixedIntensityTextBox.IsEnabled = false;
        RandomIntensity = true;
        UpdateConfig();
    }

    private void RandomIntensityCheckbox_OnUnchecked(object sender, RoutedEventArgs e)
    {
        IntensityRangeSlider.IsEnabled = false;
        FixedIntensityTextBox.IsEnabled = true;
        RandomIntensity = false;
        UpdateConfig();
    }

    private void RandomDurationStepSlider_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        RandomDurationStep = (int)RandomDurationStepSlider.Value;
        UpdateConfig();
    }

    private void DurationRangeSlider_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        DurationRange = new Range((int)DurationRangeSlider.Value, (int)DurationRangeSlider.Maximum);
        UpdateConfig();
    }

    private void IntensityRangeSlider_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        IntensityRange = new Range((int)IntensityRangeSlider.Value, (int)IntensityRangeSlider.Maximum);
        UpdateConfig();
    }

    private void FixedIntensityTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        FixedIntensity = int.TryParse(FixedIntensityTextBox.Text, out var number) ? number : 0;
        UpdateConfig();
    }

    private void FixedDurationInput_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        FixedDuration = int.TryParse(FixedDurationInput.Text, out var number) ? number : 0;
        UpdateConfig();
    }

    private void HoldTimeSlider_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        HoldTime = (int)HoldTimeSlider.Value;
        UpdateConfig();
    }

    private void CooldownTimeSlider_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        CooldownTime = (int)CooldownTimeSlider.Value;
        UpdateConfig();
    }

    private void DisableWhileAfkCheckbox_OnChecked(object sender, RoutedEventArgs e)
    {
        DisableWhileAfk = true;
        UpdateConfig();
    }

    private void DisableWhileAfkCheckbox_OnUnchecked(object sender, RoutedEventArgs e)
    {
        DisableWhileAfk = false;
        UpdateConfig();
    }

    private void ForceUnmuteCheckbox_OnChecked(object sender, RoutedEventArgs e)
    {
        ForceUnmute = true;
        UpdateConfig();
    }

    private void ForceUnmuteCheckbox_OnUnchecked(object sender, RoutedEventArgs e)
    {
        ForceUnmute = false;
        UpdateConfig();
    }

    private void RandomDurationCheckbox_OnChecked(object sender, RoutedEventArgs e)
    {
        RandomDuration = true;
        FixedDurationInput.IsEnabled = false;
        UpdateConfig();
    }

    private void RandomDurationCheckbox_OnUnchecked(object sender, RoutedEventArgs e)
    {
        RandomDuration = false;
        FixedDurationInput.IsEnabled = true;
        UpdateConfig();
    }
}