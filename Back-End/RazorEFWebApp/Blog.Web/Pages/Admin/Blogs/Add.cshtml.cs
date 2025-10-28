using Blog.Web.Data;
using Blog.Web.Models.Domain;
using Blog.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blog.Web.Pages.Admin.Blogs
{
    public class AddModel : PageModel
    {
        [BindProperty]
        public AddBlogPost AddBlogPostRequest { get; set; }

        private readonly BlogDbContext _blogDbContext;
        public AddModel(BlogDbContext blogDbContext)
        {
            this._blogDbContext = blogDbContext;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            var blogPost = new BlogPost()
            {
                Heading = AddBlogPostRequest.Heading,
                PageTitle = AddBlogPostRequest.PageTitle,
                Content = AddBlogPostRequest.Content,
                ShortDescription = AddBlogPostRequest.ShortDescription,
                FeatureImageUrl = AddBlogPostRequest.FeatureImageUrl,
                UrlHandle = AddBlogPostRequest.UrlHandle,
                PublishedDate = AddBlogPostRequest.PublishedDate,
                Author = AddBlogPostRequest.Author,
                Visible = AddBlogPostRequest.Visible
            };
            
            _blogDbContext.BlogPosts.Add(blogPost);
            _blogDbContext.SaveChanges();

            return RedirectToPage("/Admin/Blogs/List");
        }
    }
}