﻿using System;
using System.IO;
using System.Windows;
using System.Windows.Input;
using Wpf.Ui.Common;

namespace WinShock;

/// <summary>
///     Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public bool IsConfigUserControlActive = false;

    public MainWindow()
    {
        InitializeComponent();
    }

    private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
    {
        UpdateContentsBtn();
        ResetBtnAppearance();
    }
    public void UpdateContentsBtn()
    {
        ContentsBtn.IsEnabled = !IsConfigUserControlActive;
    }

    private void MainWindow_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.ChangedButton == MouseButton.Left)
            DragMove();
    }

    private void OSCBtn_OnClick(object sender, RoutedEventArgs e)
    {
        NavFrame.Navigate(new Uri("OSC/OSCUsercontrol.xaml", UriKind.Relative));
        ResetBtnAppearance();
        OSCBtn.Appearance = ControlAppearance.Success;
    }

    private void ResetBtnAppearance()
    {
        OSCBtn.Appearance = ControlAppearance.Secondary;
        BehaviorBtn.Appearance = ControlAppearance.Secondary;
        ChatboxBtn.Appearance = ControlAppearance.Secondary;
        ShockLinkBtn.Appearance = ControlAppearance.Secondary;
    }


    private void BehaviorBtn_OnClick(object sender, RoutedEventArgs e)
    {
        NavFrame.Navigate(new Uri("Behaviour/BehaviourUserControl.xaml", UriKind.Relative));
        ResetBtnAppearance();
        BehaviorBtn.Appearance = ControlAppearance.Success;
    }
}