using MauiSocial.Services;
using Microsoft.Maui.Media;
using System.Net;

namespace MauiSocial.Views;

public partial class PostPage : ContentPage
{
    FileResult photoFile;
    
	public PostPage(FileResult photo)
	{
		InitializeComponent();

        if (photo != null )
        {
            photoFile = photo;
            LoadPicture();
        }


		BindingContext = this;
	}
 
    private async void LoadPicture()
    {
        var stream = await photoFile.OpenReadAsync();
        ImageSource imgSource = ImageSource.FromStream(() => stream);
        ContentImg.Source = imgSource;
    }
    private async void Btn_Cancel_Clicked(object sender, EventArgs e)
    {
        var answer = await DisplayAlert("Discard post?", "If you go back now, you'll loose all progress", "Keep writing", "Discard");

        if (!answer)
        {
            await Navigation.PopAsync();
        }
    }

    private async void Btn_Save_Clicked(object sender, EventArgs e)
    {
        if (MediaPicker.Default.IsCaptureSupported)
        {
            FileResult photo = await MediaPicker.Default.CapturePhotoAsync();

            if (photo != null)
            {
                // save the file into local storage
                string localFilePath = Path.Combine(FileSystem.AppDataDirectory, photo.FileName);

                using Stream sourceStream = await photo.OpenReadAsync();
                using FileStream localFileStream = File.OpenWrite(localFilePath);

                await sourceStream.CopyToAsync(localFileStream);
            }
        }



        //await DisplayAlert("Not working", "This method needs to be implemented", "OK");
        ///\ TODO: save the file into local storage


        ///\ TODO: upload the image on the cloud.

        /// \BONUS: Save to Gallery: https://github.com/jamesmontemagno/MediaPlugin

        ///\ TODO: Navigation remove page from stack
    }

}