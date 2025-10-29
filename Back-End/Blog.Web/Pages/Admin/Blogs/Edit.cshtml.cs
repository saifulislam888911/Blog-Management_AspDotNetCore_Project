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


        public async Task OnGet(Guid id)
        {
            BlogPost = await _blogDbContext.BlogPosts.FindAsync(id);
        }


        public async Task<IActionResult> OnPostEdit()
        {
            var existingBlogPost = await _blogDbContext.BlogPosts.FindAsync(BlogPost.Id);

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

            await _blogDbContext.SaveChangesAsync();

            return RedirectToPage("/Admin/Blogs/List");
        }


        public async Task<IActionResult> OnPostDelete()
        {
            var existingBlogPost = await _blogDbContext.BlogPosts.FindAsync(BlogPost.Id);

            if (existingBlogPost != null)
            {
                _blogDbContext.BlogPosts.Remove(existingBlogPost);
                await _blogDbContext.SaveChangesAsync();

                return RedirectToPage("/Admin/Blogs/List");
            }

            return Page();
        }
    }
}
