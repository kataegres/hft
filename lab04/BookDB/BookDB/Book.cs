﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookDB
{
    class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public double Price { get; set; }
        public DateTime PublishDate { get; set; }
        public string Description { get; set; }

        public Book()
        {

        }

        public Book(string id, string author, string title, string genre, double price, string publishDate, string description)
        {
            Id = id;
            Author = author;
            Title = title;
            Genre = genre;
            Price = price;
            PublishDate = DateTime.ParseExact(publishDate, "yyyy-MM-dd", CultureInfo.CurrentCulture);
            Description = description;
        }
    }
}
