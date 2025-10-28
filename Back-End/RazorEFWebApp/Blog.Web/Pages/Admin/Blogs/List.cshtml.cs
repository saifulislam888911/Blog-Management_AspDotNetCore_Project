using Blog.Web.Data;
using Blog.Web.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blog.Web.Pages.Admin.Blogs
{
    public class ListModel : PageModel
    {
        public List<BlogPost> BlogPosts { get; set; }

        private readonly BlogDbContext _blogDbContext;
        public ListModel(BlogDbContext blogDbContext)
        {
            this._blogDbContext = blogDbContext;
        }

        public void OnGet()
        {
            BlogPosts = _blogDbContext.BlogPosts.ToList();
        }
    }
}
