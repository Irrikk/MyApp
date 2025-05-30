using MauiApp1.Models;
using MauiApp1.Services;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using System.Collections.ObjectModel;

namespace MauiApp1;

public class AppDesign : TabbedPage
{
    private readonly ObservableCollection<ProjectModel> projects;
    private readonly CollectionView myProjectsCollectionView;
    private readonly ContentPage homePage;

    public AppDesign()
    {
        // настройка внешнего вида TabbedPage
        this.BarBackgroundColor = Color.FromArgb("#1E1E1E");
        this.BarTextColor = Colors.White;
        this.UnselectedTabColor = Colors.Gray;
        this.SelectedTabColor = Color.FromArgb("#87CEFA");

        // загрузка проектов
        var loadedProjects = ProjectStorage.LoadProjects() ?? new List<ProjectModel>();
        projects = new ObservableCollection<ProjectModel>(loadedProjects);



        // создание главной страницы
        homePage = CreateHomePage();

        myProjectsCollectionView = new CollectionView
        {
            ItemsSource = projects,
            SelectionMode = SelectionMode.Single,
            ItemTemplate = new DataTemplate(CreateProjectTemplate),
            BackgroundColor = Colors.Transparent,
            Margin = new Thickness(10)
        };

        myProjectsCollectionView.SelectionChanged += OnProjectSelected;
        
        // создание страницы с проектами
        var projectsPage = CreateProjectsPage();

        var navHomePage = new NavigationPage(homePage) { 
            Title = "Главная",
            BarBackgroundColor = Colors.Transparent,
            BarTextColor = Colors.Transparent
        };
        NavigationPage.SetHasNavigationBar(navHomePage, false);

        var navProjectsPage = new NavigationPage(projectsPage) { 
            Title = "Мои проекты",
            BarBackgroundColor = Colors.Transparent,
            BarTextColor = Colors.Transparent
        };
        NavigationPage.SetHasNavigationBar(navProjectsPage, false);

        Children.Add(navHomePage);
        Children.Add(navProjectsPage);
    }

    private ContentPage CreateHomePage()
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

        var logoContainer = new Frame
        {
            Content = new Label
            {
                Text = "✧", 
                FontSize = 60,
                TextColor = Color.FromArgb("#87CEFA"),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            },
            BackgroundColor = Colors.Transparent,
            BorderColor = Colors.Transparent,
            CornerRadius = 60,
            WidthRequest = 120,
            HeightRequest = 120,
            HorizontalOptions = LayoutOptions.Center,
            Margin = new Thickness(0, 40, 0, 20),
            Opacity = 0
        };

        var welcomeLabel = new Label
        {
            Text = "Добро пожаловать в InterCode",
            FontSize = 28,
            FontAttributes = FontAttributes.Bold,
            TextColor = Colors.White,
            HorizontalOptions = LayoutOptions.Center,
            Margin = new Thickness(20, 0, 20, 30),
            Opacity = 0
        };

        var descriptionLabel = new Label
        {
            Text = "Создавайте, редактируйте и запускайте код прямо на вашем устройстве",
            FontSize = 16,
            TextColor = Colors.LightGray,
            HorizontalOptions = LayoutOptions.Center,
            HorizontalTextAlignment = TextAlignment.Center,
            Margin = new Thickness(30, 0, 30, 40),
            Opacity = 0
        };

        var createButton = new Button
        {
            Text = "Создать проект",
            BackgroundColor = Color.FromArgb("#87CEFA"),
            TextColor = Colors.White,
            CornerRadius = 25,
            Padding = new Thickness(20, 15),
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
            WidthRequest = 200,
            FontSize = 18,
            FontAttributes = FontAttributes.Bold,
            Opacity = 0
        };

        if (DeviceInfo.Platform == DevicePlatform.Android || DeviceInfo.Platform == DevicePlatform.WinUI)
        {
            createButton.Shadow = new Shadow
            {
                Brush = Color.FromArgb("#5087CEFA"),
                Offset = new Point(0, 5),
                Radius = 10,
                Opacity = 0.8f
            };
        }

        createButton.Clicked += async (s, e) =>
        {
            // анимация нажатия
            await createButton.ScaleTo(0.95, 100, Easing.SinInOut);
            await createButton.ScaleTo(1.05, 100, Easing.SinInOut);
            await createButton.ScaleTo(1.0, 100, Easing.SinInOut);

            await CreateNewProject();
        };

        Device.BeginInvokeOnMainThread(async () =>
        {
            await Task.Delay(300);
            await logoContainer.FadeTo(1, 1000, Easing.SinInOut);
            await welcomeLabel.FadeTo(1, 800, Easing.SinInOut);
            await welcomeLabel.TranslateTo(0, -10, 800, Easing.SinInOut);
            await descriptionLabel.FadeTo(1, 1000, Easing.SinInOut);
            await createButton.FadeTo(1, 1200, Easing.SinInOut);
        });

        var grid = new Grid
        {
            RowDefinitions =
            {
                new RowDefinition { Height = GridLength.Auto },
                new RowDefinition { Height = GridLength.Auto },
                new RowDefinition { Height = GridLength.Auto },
                new RowDefinition { Height = GridLength.Star }
            },
            Children = { logoContainer, welcomeLabel, descriptionLabel, createButton },
            Background = background
        };

        Grid.SetRow(logoContainer, 0);
        Grid.SetRow(welcomeLabel, 1);
        Grid.SetRow(descriptionLabel, 2);
        Grid.SetRow(createButton, 3);

        return new ContentPage
        {
            Title = "Главная",
            Content = new ScrollView { Content = grid }
        };
    }
    private ContentPage CreateProjectsPage()
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

        var titleLabel = new Label
        {
            Text = "Мои проекты",
            FontSize = 24,
            FontAttributes = FontAttributes.Bold,
            TextColor = Colors.White,
            HorizontalOptions = LayoutOptions.Center,
            Margin = new Thickness(0, 20, 0, 20)
        };

        var stackLayout = new StackLayout
        {
            Children = { titleLabel, myProjectsCollectionView },
            Background = background
        };

        return new ContentPage
        {
            Title = "Мои проекты",
            Content = new ScrollView { Content = stackLayout }
        };
    }

    private View CreateProjectTemplate()
    {

        var mainStack = new StackLayout
        {
            Spacing = 4,
            Padding = new Thickness(15, 10),
            VerticalOptions = LayoutOptions.Center
        };

        // название проекта
        var nameLabel = new Label 
        { 
            TextColor = Colors.White,
            FontSize = 18,
            FontAttributes = FontAttributes.Bold,
            LineBreakMode = LineBreakMode.TailTruncation
        };
        nameLabel.SetBinding(Label.TextProperty, "Name");

        // дата изменения
        var dateLabel = new Label
        {
            TextColor = Colors.LightGray,
            FontSize = 12,
            Margin = new Thickness(0, 4, 0, 0)
        };
        dateLabel.SetBinding(Label.TextProperty, "LastModified", stringFormat: "Изменен: {0:g}");

        mainStack.Children.Add(nameLabel);
        mainStack.Children.Add(dateLabel);

        var deleteButton = new Button
        {
            Text = "🗑️", 
            FontSize = 18,
            TextColor = Colors.Red,
            BackgroundColor = Colors.Transparent,
            Padding = new Thickness(10),
            HorizontalOptions = LayoutOptions.End,
            VerticalOptions = LayoutOptions.Center
        };

        var grid = new Grid
        {
            ColumnDefinitions =
            {
                new ColumnDefinition { Width = GridLength.Star },
                new ColumnDefinition { Width = GridLength.Auto }
            },
            Children = { mainStack, deleteButton }
        };

        Grid.SetColumn(mainStack, 0);
        Grid.SetColumn(deleteButton, 1);

        var frame = new Frame
        {
            BackgroundColor = Color.FromArgb("#444444"),
            CornerRadius = 15,
            Margin = new Thickness(5),
            Padding = new Thickness(0),
            HasShadow = true,
            Content = grid
        };

        // обработчик нажатия на проект 
        var tapRecognizer = new TapGestureRecognizer();
        tapRecognizer.Tapped += async (s, e) => 
        {
            if (frame.BindingContext is ProjectModel project)
            {
                await frame.ScaleTo(0.95, 100, Easing.SinInOut);
                await frame.ScaleTo(1.0, 100, Easing.SinInOut);
                await Navigation.PushAsync(new ViewMainPage(project.Name));
            }
        };
        frame.GestureRecognizers.Add(tapRecognizer);

        // обработчик нажатия на кнопку удаления
        deleteButton.Clicked += async (s, e) => 
        {
            
            if (frame.BindingContext is ProjectModel project)
            {
                
                await Task.Delay(100);
                
                bool confirm = await Application.Current.MainPage.DisplayAlert(
                    "Удаление проекта",
                    $"Вы уверены, что хотите удалить проект '{project.Name}'?",
                    "Да", "Нет");
                
                if (confirm)
                {
                    projects.Remove(project);
                    ProjectStorage.SaveAllProjects(projects.ToList());
                }
            }
        };

        frame.SetBinding(BindableObject.BindingContextProperty, new Binding("."));

        return frame;

    }

    private async Task CreateNewProject()
    {
        string name = await homePage.DisplayPromptAsync(
            "Новый проект",
            "Введите название проекта",
            "Создать",
            "Отмена",
            "Название проекта",
            maxLength: 30,
            keyboard: Keyboard.Text);

        if (!string.IsNullOrWhiteSpace(name))
        {
            var project = new ProjectModel
            {
                Name = name,
                Content = "",
                LastModified = DateTime.Now
            };

            projects.Add(project);
            ProjectStorage.SaveProject(project);

            await homePage.Navigation.PushAsync(new ViewMainPage(project.Name));
        }
    }
    private async void OnProjectSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is ProjectModel selectedProject)
        {
            myProjectsCollectionView.SelectedItem = null;
            await Navigation.PushAsync(new ViewMainPage(selectedProject.Name));
        }
    }

    private async void OnDeleteProjectInvoked(object sender, EventArgs e)
    {
        if (sender is SwipeItem swipeItem && 
            swipeItem.BindingContext is ProjectModel project)
        {
            bool confirm = await homePage.DisplayAlert(
                "Подтверждение", 
                $"Удалить проект '{project.Name}'?", 
                "Да", "Нет");
            
            if (confirm)
            {
                projects.Remove(project);
                ProjectStorage.SaveAllProjects(projects.ToList());
            }
        }
    }
}