using System;
using System.Collections.Generic;

namespace DAEntity
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }

        public ICollection<BlogPost> BlogPosts { get; set; }
    }
}