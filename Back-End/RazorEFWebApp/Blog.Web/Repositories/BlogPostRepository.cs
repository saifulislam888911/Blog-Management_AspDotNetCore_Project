using Blog.Web.Data;
using Blog.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Blog.Web.Repositories
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly BlogDbContext _blogDbContext;
        public BlogPostRepository(BlogDbContext blogDbContext)
        {
            this._blogDbContext = blogDbContext;
        }


        public async Task<BlogPost> AddAsync(BlogPost blogPost)
        {
            await _blogDbContext.BlogPosts.AddAsync(blogPost);
            await _blogDbContext.SaveChangesAsync();

            return blogPost;
        }


        public async Task<IEnumerable<BlogPost>> GetAllAsync()
        {
            return await _blogDbContext.BlogPosts.ToListAsync();
        }

        public async Task<BlogPost> GetAsync(Guid id)
        {
            return await _blogDbContext.BlogPosts.FindAsync(id);
        }


        public async Task<BlogPost> UpdateAsync(BlogPost blogPost)
        {
            var existingBlogPost = await _blogDbContext.BlogPosts.FindAsync(blogPost.Id);

            if (existingBlogPost != null)
            {
                existingBlogPost.Heading = blogPost.Heading;
                existingBlogPost.PageTitle = blogPost.PageTitle;
                existingBlogPost.Content = blogPost.Content;
                existingBlogPost.ShortDescription = blogPost.ShortDescription;
                existingBlogPost.FeatureImageUrl = blogPost.FeatureImageUrl;
                existingBlogPost.UrlHandle = blogPost.UrlHandle;
                existingBlogPost.PublishedDate = blogPost.PublishedDate;
                existingBlogPost.Author = blogPost.Author;
                existingBlogPost.Visible = blogPost.Visible;
            }

            await _blogDbContext.SaveChangesAsync();

            return existingBlogPost;
        }


        public async Task<bool> DeleteAsync(Guid id)
        {
            var existingBlogPost = await _blogDbContext.BlogPosts.FindAsync(id);

            if (existingBlogPost != null)
            {
                _blogDbContext.BlogPosts.Remove(existingBlogPost);
                await _blogDbContext.SaveChangesAsync();

                return true;
            }

            return false;
        }
    }
}
