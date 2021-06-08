using Golrang.Framework.Domain;

namespace BlogManagement.Core.Domain.Blogs
{
    public class Blog: BaseEntity
    {
        public string Name { get; set; }
        public string EnName { get; set; }
        public string Desciption { get; set; }
    }
}
