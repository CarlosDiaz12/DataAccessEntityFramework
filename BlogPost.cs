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

    public class MetricaLinea
    {
        public int MetricaId { get; set; }
        public Metrica Metrica { get; set; }
        public int LineaId { get; set; }
        public Linea Linea { get; set; }
        public string Meta { get; set; }
    }

    public class Linea
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public ICollection<Metrica> Metricas { get; set; }
        public List<MetricaLinea> MetricaLineas { get; set; }
    }

    public class Metrica
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public ICollection<Linea> Lineas { get; set; }
        public List<MetricaLinea> MetricaLineas { get; set; }
    }
}