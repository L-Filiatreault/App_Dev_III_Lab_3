using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text.Json;
using MauiSocial.Models;

namespace MauiSocial.DataRepo
{
    /// <summary>
    /// Simple repo model containing a list of posts and managing CRUD operations 
    /// while notifying observers. 
    /// </summary>
    public class PostsRepo : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Post> posts;
        private string JsonFile;
        public ObservableCollection<Post> Posts 
        {
            get
            {
                return posts;
            }
            
            private set
            {
                if(value!=null)
                {
                    posts = value;
                }

            }
        
        }
        public PostsRepo(string path) 
        {
            Posts= new ObservableCollection<Post>();
            JsonFile = path;
            Verify();
            if (Posts.Count == 0)
            {
                AddTestData();
            }
        }


        private void Verify()
        {
            if (Posts.Count==0)
            {
                return;
            }

            try
            {
                LoadPosts();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error! Read the message: \n {e.Message}");
            }
        }

        private void AddTestData()
        {
            for(int i=0; i < 6; i++)
            {
                var img = $"{500 + i}/{500 +i}";
                Posts.Add(new Post
                {
                    Id = $"Post{i + 1}",
                    ContentUri = new Uri($"https://picsum.photos/{img}.jpg"),
                    Likes= i%4,
                    PostTime = DateTime.Now.AddDays(-i),
                    Comments = new ObservableCollection<Comment>()
                });
            }
        }
        
        /// Crud operations

        ///<summary>
        /// Reads the Post given a unique id
        ///</summary>
        public Post GetPost(string id)
        {
            try
            {
                return Posts.First(x => x.Id == id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        ///<summary>
        /// Retruns the index of a post given its index.
        ///</summary>
        public int GetPostIndex(string id)
        {
            int postIndex = Posts.IndexOf(GetPost(id));
            return postIndex;
        }
        /// <summary>
        /// Creates and adds a new post to the repo 
        /// </summary>
        public void AddPost(string postLink)
        {
            try
            {
                Posts.Add(new Post
                {
                    Id = $"Post{Posts.Count + 1}",
                    ContentUri = new Uri(postLink),
                    PostTime = DateTime.Now,
                    Comments = new ObservableCollection<Comment>(),
                    Likes = 0
                });
                SavePosts();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

        }
        /// <summary>
        /// Deletes a post given the post Id
        /// </summary>
        /// <param name="post"></param>
        public void RemovePost(string id)
        {
            try
            {
                var postToremove = GetPost(id);
                if (postToremove != null)
                {
                    Posts.Remove(postToremove);
                    SavePosts();
                }
                
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            
        }
        /// <summary>
        /// Update operation on post given new post attributes. 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="post"></param>
        public void UpdatePost(string id, Post post)
        {
            try
            {
                int postIndex = GetPostIndex(id);
            
                if(postIndex > -1)
                {
                    Posts[postIndex] = post;
                    SavePosts();
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

        }

        /// <summary>
        /// Serializes the Posts data structure to a json file 
        /// </summary>
        public void SavePosts()
        {
            ///\TODO: Complete this part by saving the posts to the Json file
            ///
            try
            {
                string postsToSave = JsonSerializer.Serialize(posts);

                File.WriteAllText(JsonFile, postsToSave);
            }
            catch (Exception error)
            {
                Console.WriteLine($"ERROR! Couldn't save the data to the collection. {error.Message}");
            }
            
        }

        /// <summary>
        /// Deserializes the Posts data structure from a json file
        /// </summary>
        public void LoadPosts()
        {
            ///\ TODO: Complete this part by loading the Json file

            try
            {
                if(File.Exists(JsonFile))
                {
                    using(FileStream streamer = File.OpenRead(JsonFile))
                    {
                        posts = JsonSerializer.Deserialize<ObservableCollection<Post>>(streamer);   
                    }
                }


            }
            catch (Exception error)
            {
                Console.WriteLine($"ERROR! Couldn't load data from the collection. {error.Message}");
            }
        }
    }
}
