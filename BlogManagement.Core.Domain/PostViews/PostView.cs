using System;
using Golrang.Framework.Domain;

namespace BlogManagement.Core.Domain.PostViews
{
    public class PostView : BaseEntity
    {
        public int PostId { get; set; }
        public DateTime ViewDate { get; set; }
    }
}