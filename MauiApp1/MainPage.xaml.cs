using Microsoft.Maui.Controls.Shapes;
using System;
using System.Diagnostics;

namespace MauiApp1;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        AppContext context = new();
        NodeEditor editor = new(context);
        Content = context.RootLayout;
    }
}