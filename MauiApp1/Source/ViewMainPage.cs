using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace MauiApp1;

public class ViewMainPage : ContentPage
{
    public ViewMainPage(string projectName)
    {
        NavigationPage.SetHasNavigationBar(this, false); // для скрытия самого верхнего поля

        Title = projectName ?? "Без названия";
        BuildUI();
    }

    private void BuildUI()
    {
        var background = new LinearGradientBrush
        {
            StartPoint = new Point(0, 0),
            EndPoint = new Point(1, 1),
            GradientStops = new GradientStopCollection
            {
                new GradientStop { Color = Color.FromArgb("#1E1E1E"), Offset = 0.0f },
                new GradientStop { Color = Color.FromArgb("#2B2B2B"), Offset = 0.5f },
                new GradientStop { Color = Color.FromArgb("#1E1E1E"), Offset = 1.0f }
            }
        };

        var backButton = new Button 
        {
            Text = "←",
            FontSize = 24,
            TextColor = Colors.White,
            BackgroundColor = Colors.Transparent,
            WidthRequest = 50,
            CornerRadius = 25,
            Padding = 0
        };
        
        backButton.Clicked += async (s, e) => 
        {
            await backButton.ScaleTo(0.8, 100, Easing.SinInOut);
            await backButton.ScaleTo(1.0, 100, Easing.SinInOut);
            
            if (Navigation != null && Navigation.NavigationStack?.Count > 1)
                await Navigation.PopAsync();
        };

        var titleLabel = new Label
        {
            Text = Title,
            FontSize = 20,
            FontAttributes = FontAttributes.Bold,
            TextColor = Colors.White,
            VerticalOptions = LayoutOptions.Center,
            HorizontalOptions = LayoutOptions.Start, 
            Margin = new Thickness(10, 0, 0, 0) 
        };

        var topBar = new Grid
        {
            HeightRequest = 60,
            BackgroundColor = Color.FromArgb("#252525"),
            ColumnDefinitions =
            {
                new ColumnDefinition { Width = GridLength.Auto }, // кнопка назад 
                new ColumnDefinition { Width = GridLength.Star }  // заголовок
            },
            Children = { backButton, titleLabel }
        };

        Grid.SetColumn(backButton, 0);
        Grid.SetColumn(titleLabel, 1);

        var leftPanel = new Frame
        {
            WidthRequest = 160,
            CornerRadius = 0,
            Padding = 15,
            Margin = 0,
            BackgroundColor = Color.FromArgb("#252525"),
            HasShadow = false,
            Content = new StackLayout
            {
                Spacing = 15,
                Children =
                {
                    CreateCategoryButton("ВСЕ", Color.FromArgb("#87CEFA")),
                    CreateCategoryButton("ЛОГИКА", Color.FromArgb("#6A5ACD")),
                    CreateCategoryButton("ДЕЙСТВИЯ", Color.FromArgb("#32CD32")),
                    CreateCategoryButton("МАТЕМАТИКА", Color.FromArgb("#FF8C00")),
                    CreateCategoryButton("ПЕРЕМЕННЫЕ", Color.FromArgb("#BA55D3")),
            
                }
            }
        };

        // рабочая область
        var workspace = new Frame
        {
            CornerRadius = 15,
            Margin = new Thickness(15),
            Padding = 20,
            BackgroundColor = Color.FromArgb("#444444"),
            HasShadow = true,
            Content = new Label
            {
                TextColor = Colors.LightGray,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                FontSize = 18
            }
        };

        // основной макет
        var mainGrid = new Grid
        {
            RowDefinitions =
            {
                new RowDefinition { Height = GridLength.Auto },
                new RowDefinition { Height = GridLength.Star }
            },
            ColumnDefinitions =
            {
                new ColumnDefinition { Width = GridLength.Auto },
                new ColumnDefinition { Width = GridLength.Star }
            },
            Background = background
        };

        mainGrid.Children.Add(topBar);
        Grid.SetRow(topBar, 0);
        Grid.SetColumnSpan(topBar, 2);

        mainGrid.Children.Add(leftPanel);
        Grid.SetRow(leftPanel, 1);
        Grid.SetColumn(leftPanel, 0);

        mainGrid.Children.Add(workspace);
        Grid.SetRow(workspace, 1);
        Grid.SetColumn(workspace, 1);

        // жесты для скрытия/показа панели
        var swipeRight = new SwipeGestureRecognizer { Direction = SwipeDirection.Right };
        swipeRight.Swiped += (s, e) => leftPanel.IsVisible = true;
        workspace.GestureRecognizers.Add(swipeRight);

        var swipeLeft = new SwipeGestureRecognizer { Direction = SwipeDirection.Left };
        swipeLeft.Swiped += (s, e) => leftPanel.IsVisible = false;
        leftPanel.GestureRecognizers.Add(swipeLeft);

        // кнопка для скрытия/показа панели 
        var togglePanelButton = new Button
        {
            Text = "≡",
            FontSize = 24,
            TextColor = Colors.White,
            BackgroundColor = Color.FromArgb("#444444"),
            WidthRequest = 40,
            HeightRequest = 40,
            CornerRadius = 20,
            HorizontalOptions = LayoutOptions.Start,
            VerticalOptions = LayoutOptions.Start,
            Margin = new Thickness(5)
        };

        togglePanelButton.Clicked += (s, e) => leftPanel.IsVisible = !leftPanel.IsVisible;
        mainGrid.Children.Add(togglePanelButton);
        Grid.SetRow(togglePanelButton, 1);
        Grid.SetColumn(togglePanelButton, 1);

        Content = mainGrid;
    }
    private Button CreateCategoryButton(string text, Color color) => new Button
    {
        Text = text,
        BackgroundColor = color.MultiplyAlpha(0.7f),
        TextColor = Colors.White,
        CornerRadius = 10,
        FontSize = 14,
        FontAttributes = FontAttributes.Bold,
        Padding = new Thickness(10, 8),
        Margin = new Thickness(0, 0, 0, 5),
        HeightRequest = 50
    };
}