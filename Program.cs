using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace DAEntity
{
    class Program
    {
        static void Main(string[] args)
        {
            var ctx = new AppDbContext();
            var temp = ctx.Lineas.First();

            var query = ctx.Posts.Include(x => x.Tags).First();
            // var authors = ctx.Authors.ToList();
            var tag = ctx.Tags.First();
            query.Tags.Add(tag);

            // var newTag = new Tag()
            // {
            //     Name = "Wakanda 4 ever"
            // };
            // ctx.Tags.Add(newTag);

            ctx.SaveChanges();

            // var blogPostTags = 

            // var newAuthor = new Author()
            // {
            //     Name = "Carlos Diaz",
            //     EmailAddress = "c.diaz@gmail.com"
            // };

            // ctx.Authors.Add(newAuthor);

            // var post = ctx.Posts.Find(1);
            // post.Author = newAuthor;
            // ctx.SaveChanges();

            // var query = ctx.Posts
            //                 .AsNoTracking()
            //                 .OrderByDescending(b => b.PublishedUtc)
            //                 .Take(5)
            //                 .ToList();

            // query.ForEach(x => Console.WriteLine(x.Title));
            /*
            var post = new BlogPost()
            {
                Title = "My first post.",
                Content = "This is my first blog post.",
                PublishedUtc = DateTime.UtcNow
            };

            ctx.Posts.Add(post);
            ctx.SaveChanges();
            */
        }
    }
}
