namespace MauiApp1;

public partial class MainPage : ContentPage
{
	

	public MainPage()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		  DisplayAlert("Title", "Some new info", "Oki");
    }

    private void Entry_TextChanged(object sender, TextChangedEventArgs e)
    {
		  Outputlabel.Text = "Вы ввели: " + e.NewTextValue;
		
		if(e.NewTextValue == "Font")
			Outputlabel.FontSize = 30;
    }

    private void Switch_Toggled(object sender, ToggledEventArgs e)
    {
      SwitchLabel.Text = e.Value ? "Switch on" : "Switch off";
    }

    private void MyPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
      PickerLabel.Text = MyPicker.SelectedItem.ToString();
    }

}

