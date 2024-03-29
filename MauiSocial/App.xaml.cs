using MauiSocial.Services;
using MauiSocial.Models;
using System.Collections.ObjectModel;
using MauiSocial.DataRepo;

 

namespace MauiSocial
{
    public partial class App : Application
    {
        public static CloudinaryService CloudinaryService { get; set; } = new CloudinaryService();

        static string DataFile = Path.Combine(FileSystem.AppDataDirectory, "posts.json");


        public static PostsRepo Repo { get; set; } = new PostsRepo(DataFile);

        
        public App()
        {
            InitializeComponent();
            
            MainPage = new AppShell();

            
        }
    }
}
