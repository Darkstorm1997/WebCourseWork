using System;

namespace TecReview.Models
{
    public class Comment
    {
        public int CommentId { get; set; }

        public string Author { get; set; }

        public string Content { get; set; }

        public int Sequence { get; set; }

        public DateTime DatePosted { get; set; }

        public int ItemId { get; set; }

        public virtual Item Item{ get; set; }
    }
}