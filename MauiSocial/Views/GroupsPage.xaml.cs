namespace MauiSocial.Views;

public partial class GroupsPage : ContentPage
{
	public GroupsPage()
	{
		InitializeComponent();
	}

    private  void Btn_AddPost_Clicked(object sender, EventArgs e)
    {
		//\ TODO Navigate to the New Post Page
		Shell.Current.GoToAsync("//Home/AddPost");
    }
}