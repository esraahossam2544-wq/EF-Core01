// See https://aka.ms/new-console-template for more information
using EF_Core01;
using Microsoft.EntityFrameworkCore;

using var db = new BookstoreContext();
db.Database.EnsureDeleted();
db.Database.EnsureCreated();
Console.WriteLine("Database created.\n");

var author = new Author
{
    FirstName = "George",
    LastName = "Orwell",
    Email = "george@example.com",
    Biography = "English novelist and essayist.",
    DateOfBirth = new DateTime(1903, 6, 25)
};
var category = new Category { Name = "Fiction", Description = "Novels and stories", IsActive = true };

db.Books.Add(new Book
{
    Title = "1984",
    Isbn = "9780451524935",
    Price = 9.99m,
    Pages = 328,
    PublishedYear = 1949,
    InStock = true,
    Author = author,
    Category = category
});
db.SaveChanges();

// Prove data + relationships
foreach (var b in db.Books.Include(b => b.Author).Include(b => b.Category))
    Console.WriteLine($"{b.Title} by {b.Author.FirstName} {b.Author.LastName} [{b.Category.Name}]");

// Prove the schema
Console.WriteLine("\n--- Schema ---");
var conn = db.Database.GetDbConnection();
conn.Open();
using var cmd = conn.CreateCommand();
cmd.CommandText = @"SELECT TABLE_NAME, COLUMN_NAME, DATA_TYPE, IS_NULLABLE
                    FROM INFORMATION_SCHEMA.COLUMNS ORDER BY TABLE_NAME, ORDINAL_POSITION";
using var r = cmd.ExecuteReader();
while (r.Read())
    Console.WriteLine($"{r[0],-12}{r[1],-15}{r[2],-10}nullable: {r[3]}");
