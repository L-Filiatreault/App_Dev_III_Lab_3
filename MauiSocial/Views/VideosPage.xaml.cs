using System.Collections.ObjectModel;

namespace MauiSocial.Views;

public partial class VideosPage : ContentPage
{
	public VideosPage()
	{
		InitializeComponent();
	}

    private void Btn_Comments_Clicked(object sender, EventArgs e)
    {
        ///\TODO: Navigate to comments page
        Shell.Current.GoToAsync(nameof(CommentPage));


        ///\TODO: Navigate to comments page while passing in data

    }
}