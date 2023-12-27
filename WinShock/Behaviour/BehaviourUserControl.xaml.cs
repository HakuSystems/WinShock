using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using Wpf.Ui.Common;

namespace WinShock.Behaviour;

public partial class BehaviourUserControl : UserControl
{
    public BehaviourUserControl()
    {
        InitializeComponent();
    }

    private void BehaviourUserControl_OnLoaded(object sender, RoutedEventArgs e)
    {
        var mainWindow = (MainWindow)Application.Current.MainWindow;
        mainWindow.BehaviorBtn.Appearance = ControlAppearance.Success;
    }

    private bool IsUserInput = true;

    private void DurationStepTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        if (IsUserInput)
        {
            IsUserInput = false;

            DurationStepTextBox.Text = new string(DurationStepTextBox.Text.Where(char.IsDigit).ToArray());
            var currentFullNumber = int.TryParse(DurationStepTextBox.Text, out var number) ? number : 0;
            var currentNumber = currentFullNumber;

            //Change SecondsCounter for better readability for example 1000 -> 1 Seconds and 10000 -> 10 Seconds or 1001 -> 1 Seconds and 1 Millisecond
            var timeCounters = new int[8];
            string[] timeUnits =
            {
                "Milliseconds",
                "Seconds",
                "Minutes",
                "Hours",
                "Days",
                "Weeks",
                "Months",
                "Years"
            };
            var sb = new StringBuilder();

            for (var i = 0; i < timeCounters.Length; i++)
            {
                timeCounters[i] = currentNumber % 1000;
                currentNumber /= 1000;

                if (timeCounters[i] != 0) sb.Insert(0, timeCounters[i] + " " + timeUnits[i] + " ");

                if (currentNumber == 0) break;
            }

            if (SecondsCounter != null) SecondsCounter.Text = sb.ToString().Trim();
            DurationStepTextBox.Text = currentFullNumber.ToString();

            IsUserInput = true;
        }
    }
}