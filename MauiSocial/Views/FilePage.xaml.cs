namespace MauiSocial.Views;

public partial class FilePage : ContentPage
{
	public FilePage()
	{
		InitializeComponent();
	}

    private async void Btn_TakePhoto_Clicked(object sender, EventArgs e)
    {

        FileResult photo = await MediaPicker.Default.CapturePhotoAsync();
        if (photo == null)
        {
            return;
        }

        await Navigation.PushAsync(new PostPage(photo));
    }

    private async void Btn_SelectPhoto_Clicked(object sender, EventArgs e)
    {

        var photo = await FilePicker.PickAsync(new PickOptions()
        {
            FileTypes = FilePickerFileType.Images
        });

        if(photo == null)
        {
            return;
        }


        await Navigation.PushAsync(new PostPage(photo));

    }

    private async void Btb_Cancel_Clicked(object sender, EventArgs e)
    {
        
        await Shell.Current.GoToAsync("//Home/MainPage");

    }
}