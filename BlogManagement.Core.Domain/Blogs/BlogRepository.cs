using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement.Core.Domain.Blogs
{
    public interface BlogRepository
    {
        void Add(Blog blog);
        void Remove(int blogId);

        Blog Get(int blogId);
        List<Blog> Get();

    }
}
