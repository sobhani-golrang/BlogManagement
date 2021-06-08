using System;
using System.ComponentModel.DataAnnotations;
using BlogManagement.Core.Domain.Comments;

namespace BlogManagement.Core.ApplicationServices.Comments
{
    public class AddCommentCommand
    {
        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string Author { get; set; }
        [Required]
        [StringLength(500, MinimumLength = 5)]
        public string Text { get; set; }
        [Required]
        public int? PostId { get; set; }

        public Comment ToComment()
        {
            return new Comment
            {
                Author = Author,
                Text = Text,
                PostId = PostId.Value
            };
        }
    }
}