using System.Threading.Tasks;

namespace BlogManagement.Core.Domain.PostViews
{
    public interface PostViewRepository
    {
        Task Add(PostView postView);
    }
}