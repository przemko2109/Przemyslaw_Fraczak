using Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Presentation.Models
{
    public class Catalog
    { 
        public Catalog(int id)
        {
            BookId = id;
            Title = DataService.getCatalogBook(id).title;
            AuthorName = DataService.getCatalogBook(id).author_name;
            Genre = DataService.getCatalogBook(id).genre;
        }
        public Catalog(int id, string title, string author_name, string genre)
        {
            BookId = id;
            Title = title;
            AuthorName = author_name;
            Genre = genre;
        }
        public String Title { get; set; }
        public int BookId { get; set; }
        public String AuthorName { get; set; }
        public string Genre { get; set; }
    }
}
