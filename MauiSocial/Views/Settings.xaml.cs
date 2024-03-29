using Microsoft.Maui.ApplicationModel;

namespace MauiSocial.Views;


public partial class Settings : ContentPage
{

    bool appTheme = false;

	public Settings()
	{
		InitializeComponent();
        LoadPreferences();

    }
    private void LoadPreferences()
    {
        ///\ TODO: Load the preferences and set the entries and switch button
        string name = Preferences.Default.Get("username", "unknown");
        UsernameEntry.Text = name;
        string uri = Preferences.Default.Get("profileuri", "unknown");
        PhotoUriEntry.Text = uri;
        appTheme = Preferences.Get("apptheme", appTheme);
        ThemeSwitch.On = appTheme;
    }
    private void UsernameEntry_Completed(object sender, EventArgs e)
    {
       
        Preferences.Set("username", UsernameEntry.Text);
        
    }

    private void PhotoUriEntry_Completed(object sender, EventArgs e)
    {
        ///\ TODO: set the profileuri preference
       
        Preferences.Set("profileuri", PhotoUriEntry.Text);
    }

    private void ThemeSwitch_OnChanged(object sender, ToggledEventArgs e)
    {
        ///\TODO: set the theme preference.

        Preferences.Set("apptheme", ThemeSwitch.On);
        App.Current.UserAppTheme = ThemeSwitch.On? AppTheme.Light : AppTheme.Dark;
            
    }
       

        
    
}