﻿using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Widget;

namespace MauiApp1;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    protected override void OnCreate(Bundle? savedInstanceState)
    {
        Android.Graphics.Color uiFrameColor = new(61, 61, 61, 255);
        base.OnCreate(savedInstanceState);
        Window.SetStatusBarColor(uiFrameColor);
        Window.SetNavigationBarColor(uiFrameColor);
        //var toolbar = FindViewById<Android.Widget.Toolbar>(Resource.Id.toolbar);
        //toolbar.SetBackgroundColor(uiFrameColor);
    }
}
