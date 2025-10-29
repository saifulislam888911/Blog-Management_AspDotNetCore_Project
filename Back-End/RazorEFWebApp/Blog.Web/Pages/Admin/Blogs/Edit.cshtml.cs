using Blog.Web.Data;
using Blog.Web.Models.Domain;
using Blog.Web.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blog.Web.Pages.Admin.Blogs
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public BlogPost BlogPost { get; set; }

        private readonly IBlogPostRepository _blogPostRepository;

        public EditModel(IBlogPostRepository blogPostRepository)
        {
            _blogPostRepository = blogPostRepository;
        }

        public async Task OnGet(Guid id)
        {
            BlogPost = await _blogPostRepository.GetAsync(id);
        }

        public async Task<IActionResult> OnPostEdit()
        {
            var updatedBlogPost = await _blogPostRepository.UpdateAsync(BlogPost);

            if (updatedBlogPost != null)
            {
                return RedirectToPage("/Admin/Blogs/List");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostDelete()
        {
            var deletedData = await _blogPostRepository.DeleteAsync(BlogPost.Id);

            if (deletedData)
            {
                return RedirectToPage("/Admin/Blogs/List");
            }

            return Page();
        }
    }
}
