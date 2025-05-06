using System;

namespace MauiApp1;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();

        AbsoluteLayout layout = new()
        {
            BackgroundColor = new(29, 29, 29, 255)
        };

        Event<INode> nodeTouched = new();

        INode n1 = new TestNode(nodeTouched);
        n1.Position = new(100, 50f);
        n1.Title = "First";
        n1.TitleBarColor = new(135, 49, 49, 255);
        layout.Add(n1 as IView);

        INode n2 = new TestNode(nodeTouched);
        n2.Position = new(500, 250f);
        n2.Title = "Second";
        n2.TitleBarColor = new(49, 94, 135, 255);
        layout.Add(n2 as IView);

        Size valueSize = new(50, 20);

        IntChannel inInt = new(valueSize, ValueChannelType.Input);
        layout.Add(inInt);
        inInt.TranslationX = 500;
        inInt.TranslationY = 20;

        IntChannel outInt = new(valueSize, ValueChannelType.Output);
        layout.Add(outInt);
        outInt.TranslationX = 560;
        outInt.TranslationY = 20;

        FloatChannel inFloat = new(valueSize, ValueChannelType.Input);
        layout.Add(inFloat);
        inFloat.TranslationX = 500;
        inFloat.TranslationY = 40;

        FloatChannel outFloat = new(valueSize, ValueChannelType.Output);
        layout.Add(outFloat);
        outFloat.TranslationX = 560;
        outFloat.TranslationY = 40;

        BoolChannel inBool = new(valueSize, ValueChannelType.Input);
        layout.Add(inBool);
        inBool.TranslationX = 500;
        inBool.TranslationY = 60;

        BoolChannel outBool = new(valueSize, ValueChannelType.Output);
        layout.Add(outBool);
        outBool.TranslationX = 560;
        outBool.TranslationY = 60;

        Content = layout;

        NodeSelector nodeSelector = new(nodeTouched);
    }

    private void Button_Clicked(object sender, EventArgs e) // DEL ???
    {
        DisplayAlert("Title", "Some new info", "Oki");
    }

    private void Entry_TextChanged(object sender, TextChangedEventArgs e) // DEL ???
    {
        Outputlabel.Text = "Вы ввели: " + e.NewTextValue;

        if (e.NewTextValue == "Font")
            Outputlabel.FontSize = 30;
    }

    private void Switch_Toggled(object sender, ToggledEventArgs e) // DEL ???
    {
        SwitchLabel.Text = e.Value ? "Switch on" : "Switch off";
    }

    private void MyPicker_SelectedIndexChanged(object sender, EventArgs e) // DEL ???
    {
        PickerLabel.Text = MyPicker.SelectedItem.ToString();
    }

}

