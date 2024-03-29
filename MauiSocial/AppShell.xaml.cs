using MauiSocial.Views;
namespace MauiSocial
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            
           ///\ TODO: Set the app theme based on the user preference.
            bool appTheme = Preferences.Get("apptheme", false);
            App.Current.UserAppTheme = appTheme ? AppTheme.Light : AppTheme.Dark;
            Routing.RegisterRoute(nameof(CommentPage), typeof(CommentPage));
        }

        private void Btn_SwitchTheme_Clicked(object sender, EventArgs e)
        {
        }
    }
}
