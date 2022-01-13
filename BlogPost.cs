using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAEntity
{
    public class BlogPost
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublishedUtc { get; set; }

        public Author Author { get; set; }

        public ICollection<Tag> Tags { get; set; }

        public override string ToString()
        {
            return $"({Id}) {Title}";
        }
    }

}