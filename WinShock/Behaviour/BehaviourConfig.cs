using System;

namespace WinShock.Behaviour;

public class BehaviourConfig
{
    /*
     * Behaviour
RandomIntensity: true (Checkbox)
RandomDuration: true (Durations/time measurements are all in milliseconds since v1.0.1.0 - Checkbox)
RandomDurationStep: 100 (Random step, e.g. 1000 would be full seconds - Slider)
DurationRange: (Range Slider)
Min: 300
Max: 5000
IntensityRange: (Intensity percentage range for random/physbone shocks - Range Slider)
Min: 1
Max: 30
FixedIntensity: 50 (If RandomIntensity is false - Number Input)
FixedDuration: 2 (If RandomDuration is false - Number Input)
HoldTime: 250 (Defines how long the parameter needs to be true in milliseconds for the shock to be triggered - Slider)
CooldownTime: 5000 (Cooldown in milliseconds between shocks per shocker - Slider)
WhileBoneHeld: "Vibrate" (Vibrate, Shock, None - defines what happens when a physbone is held in hand - Dropdown)
DisableWhileAfk: true (Disable shocks when AFK (VRChats AFK Detection needs to be turned on for this) - Checkbox)
ForceUnmute: false (Force unmute when shock is triggered - Checkbox)
     */
    public bool RandomIntensity { get; set; } = true;
    public bool RandomDuration { get; set; } = true;
    public int RandomDurationStep { get; set; } = 100;
    public Range DurationRange { get; set; } = new(300, 5000);
    public Range IntensityRange { get; set; } = new(1, 30);
    public int FixedIntensity { get; set; } = 50;
    public int FixedDuration { get; set; } = 2;
    public int HoldTime { get; set; } = 250;
    public int CooldownTime { get; set; } = 5000;
    public string WhileBoneHeld { get; set; } = "Vibrate";
    public bool DisableWhileAfk { get; set; } = true;
    public bool ForceUnmute { get; set; } = false;
}