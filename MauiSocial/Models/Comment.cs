using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiSocial.Models
{
    /// <summary>
    /// Simple container class for comment made on social media posts
    /// </summary>
    public class Comment : INotifyPropertyChanged
    {
        public int UserId { get; set; }
        public Uri ProfilePic { get; set; }
        public string Text { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
