using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MauiSocial.Models
{
    /// <summary>
    /// Simple container class for social media post
    /// </summary>
    public class Post : INotifyPropertyChanged
    {
        public string Id { get; set; }
        public Uri ContentUri { get; set; }
        public DateTime PostTime { get; set; }
        public ObservableCollection<Comment> Comments { get; set; }

        public int Likes { get; set; } = 0;

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
