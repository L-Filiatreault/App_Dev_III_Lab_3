using MauiSocial.Models;
using System.Collections.ObjectModel;

namespace MauiSocial.Views;

public partial class CommentPage : ContentPage
{
	int userid_ = 4568;
	///\ TODO: Load the profile url from user preferences
	string profilePic_ = "https://devblogs.microsoft.com/dotnet/wp-content/uploads/sites/10/2021/09/dotnet-bot_jetpack-faceing-right.png";

	private Post postRef_;
	public CommentPage(Post post)
	{
		InitializeComponent();
		this.postRef_ = post;
		CommentsList.ItemsSource = post.Comments;
	}

    private void Btn_Send_Clicked(object sender, EventArgs e)
    {
		string comment = CommentEntry.Text;
		if(comment !=null)
		{
			postRef_.Comments.Add(new Comment() { 
				UserId = userid_ ,
				Text = comment, 
				ProfilePic=new Uri(profilePic_)}
			);
			CommentEntry.Text = "";
			App.Repo.UpdatePost(postRef_.Id,postRef_);
		}
    }

    private async void Btn_Back_Clicked(object sender, EventArgs e)
    {
		// removes this page from the navigation stack
		await Navigation.PopAsync();
    }
}