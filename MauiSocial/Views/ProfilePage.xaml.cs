
namespace MauiSocial.Views;

public partial class ProfilePage : ContentPage
{
    ///\ TODO: Update this to use user preferences
    public string ProfileName { get; set; } = "DOT NET BOT"; 
	
	///\ TODO: Update this to use user preferences
	public string ProfileUrl { get; set; } = "https://devblogs.microsoft.com/dotnet/wp-content/uploads/sites/10/2021/09/dotnet-bot_jetpack-faceing-right.png";  
	public ProfilePage()
	{
		InitializeComponent();
        BindingContext = this;

        ProfileName = Preferences.Get("username", ProfileName);
        ProfileUrl =  Preferences.Get("profileuri", ProfileUrl);
    }

}