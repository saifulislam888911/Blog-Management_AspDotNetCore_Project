using Blog.Web.Data;
using Blog.Web.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blog.Web.Pages.Admin.Blogs
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public BlogPost BlogPost { get; set; }

        private readonly BlogDbContext _blogDbContext;
        public EditModel(BlogDbContext blogDbContext)
        {
            this._blogDbContext = blogDbContext;
        }

        public void OnGet(Guid id)
        {
            BlogPost = _blogDbContext.BlogPosts.Find(id);
        }

        public IActionResult OnPostEdit()
        {
            var existingBlogPost = _blogDbContext.BlogPosts.Find(BlogPost.Id);

            if (existingBlogPost != null)
            {
                existingBlogPost.Heading = BlogPost.Heading;
                existingBlogPost.PageTitle = BlogPost.PageTitle;
                existingBlogPost.Content = BlogPost.Content;
                existingBlogPost.ShortDescription = BlogPost.ShortDescription;
                existingBlogPost.FeatureImageUrl = BlogPost.FeatureImageUrl;
                existingBlogPost.UrlHandle = BlogPost.UrlHandle;
                existingBlogPost.PublishedDate = BlogPost.PublishedDate;
                existingBlogPost.Author = BlogPost.Author;
                existingBlogPost.Visible = BlogPost.Visible;
            }

            _blogDbContext.SaveChanges();

            return RedirectToPage("/Admin/Blogs/List");
        }

        public IActionResult OnPostDelete()
        {
            var existingBlogPost = _blogDbContext.BlogPosts.Find(BlogPost.Id);

            if (existingBlogPost != null)
            {
                _blogDbContext.BlogPosts.Remove(existingBlogPost);
                _blogDbContext.SaveChanges();

                return RedirectToPage("/Admin/Blogs/List");
            }

            return Page();
        }
    }
}
