using System;
using System.Collections.Generic;
using System.Text;

namespace EF_Core01
{
    public class Author
    {
        public int Id { get; set; }                      // PK by convention
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Biography { get; set; }           // optional
        public DateTime DateOfBirth { get; set; }
        public List<Book> Books { get; set; } = new();
    }
}
