using Blog.Web.Data;
using Blog.Web.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

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

<<<<<<< HEAD

        public void OnGet()
=======
        public async Task OnGet()
>>>>>>> remotes/origin/DevWithNotes-02
        {
             BlogPosts = await _blogDbContext.BlogPosts.ToListAsync();
        }
    }
}
