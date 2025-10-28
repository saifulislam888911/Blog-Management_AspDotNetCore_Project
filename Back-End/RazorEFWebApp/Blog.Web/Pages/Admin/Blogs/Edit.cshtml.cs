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

<<<<<<< HEAD

        public void OnGet(Guid id)
=======
        public async Task OnGet(Guid id)
>>>>>>> remotes/origin/DevWithNotes-02
        {
            BlogPost = await _blogDbContext.BlogPosts.FindAsync(id);
        }

<<<<<<< HEAD

        public IActionResult OnPostEdit()
=======
        public async Task<IActionResult> OnPostEdit()
>>>>>>> remotes/origin/DevWithNotes-02
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

<<<<<<< HEAD

        public IActionResult OnPostDelete()
=======
        public async Task<IActionResult> OnPostDelete()
>>>>>>> remotes/origin/DevWithNotes-02
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
