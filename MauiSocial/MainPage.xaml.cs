using MauiSocial.Views;
using MauiSocial.Models;
namespace MauiSocial
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            PostsView.ItemsSource = App.Repo.Posts;
        }

        private async void Btn_Comments_Clicked(object sender, EventArgs e)
        {
            //var postId = (sender as ImageButton).CommandParameter.ToString();
            //Post post = App.Repo.GetPost(postId);
            var post = (sender as ImageButton).CommandParameter as Post;
            await Navigation.PushAsync(new CommentPage(post));
        }

        private void Btn_Like_Clicked(object sender, EventArgs e)
        {
            //var postId = (sender as ImageButton).CommandParameter.ToString();
            //Post post = App.Repo.GetPost(postId);
            var post = (sender as ImageButton).CommandParameter as Post;
            post.Likes++;
            App.Repo.UpdatePost(post.Id, post);
        }

        private async  void Btn_Share_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Post shared", "", "OK");

            
        }
    }

}
