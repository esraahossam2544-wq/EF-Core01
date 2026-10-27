using System;
using System.Collections.Generic;
using System.Text;

namespace EF_Core01
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public List<Book> Books { get; set; } = new();
    }
}
