using Blog.Web.Data;
using Blog.Web.Models.Domain;
using Blog.Web.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Blog.Web.Pages.Admin.Blogs
{
    public class ListModel : PageModel
    {
        public List<BlogPost> BlogPosts { get; set; }

        private readonly IBlogPostRepository _blogPostRepository;

        public ListModel(IBlogPostRepository blogPostRepository)
        {
            _blogPostRepository = blogPostRepository;
        }

        public async Task OnGet()
        {
            BlogPosts = (await _blogPostRepository.GetAllAsync()).ToList();
        }
    }
}
