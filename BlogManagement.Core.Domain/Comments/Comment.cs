using Golrang.Framework.Domain;

namespace BlogManagement.Core.Domain.Comments
{
    public class Comment: BaseEntity
    {
        public int PostId { get; set; }
        public string Author { get; set; }
        public string Text { get; set; }
    }
}
