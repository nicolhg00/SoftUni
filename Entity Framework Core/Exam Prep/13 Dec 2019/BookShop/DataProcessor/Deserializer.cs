namespace BookShop.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using BookShop.Data.Models;
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedBook
            = "Successfully imported book {0} for {1:F2}.";

        private const string SuccessfullyImportedAuthor
            = "Successfully imported author - {0} with {1} books.";

        public static string ImportBooks(BookShopContext context, string xmlString)
        {
            var sb = new StringBuilder();
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Books");
            XmlSerializer serializer = new XmlSerializer(typeof(ImportBooksDto[]), xmlRoot);

            ImportBooksDto[] importBooksDtos;
            List<Book> dbBooks = new List<Book>();

            using (StringReader sr = new StringReader(xmlString))
            {
                importBooksDtos = (ImportBooksDto[])serializer.Deserialize(sr);

                foreach (var book in importBooksDtos)
                {
                    if (!IsValid(book))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (!DateTime.TryParseExact(book.PublishedOn, "MM/dd/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime publishedOn))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Book b = new Book()
                    {
                        Name = book.Name,
                        Genre = (Genre)book.Genre,
                        Price = book.Price,
                        Pages = book.Pages,
                        PublishedOn = publishedOn
                    };

                    dbBooks.Add(b);
                    sb.AppendLine(String.Format(SuccessfullyImportedBook, b.Name, b.Price));
                }

                context.Books.AddRange(dbBooks);
                context.SaveChanges();
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportAuthors(BookShopContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var authors = JsonConvert.DeserializeObject<ImportAuthorsDto[]>(jsonString);
            List<Author> authorsList = new List<Author>();

            foreach (var author in authors)
            {
                if (!IsValid(author))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool doesEmailExists = authorsList
                    .FirstOrDefault(x => x.Email == author.Email) != null;
                if (doesEmailExists)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Author a = new Author()
                {
                    FirstName = author.FirstName,
                    LastName = author.LastName,
                    Phone = author.Phone,
                    Email = author.Email
                };

               
                foreach (var book in author.Books)
                {
                    var books = context.Books.Find(book.Id);

                    if (books == null)
                    {
                        continue;
                    }

                    a.AuthorsBooks.Add(new AuthorBook()
                    {
                        Author = a,
                        Book = books
                    });
                }

                if (a.AuthorsBooks.Count == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                authorsList.Add(a);
                sb.AppendLine(String.Format(SuccessfullyImportedAuthor, (a.FirstName + " " + a.LastName), a.AuthorsBooks.Count));
            }

            context.Authors.AddRange(authorsList);
            context.SaveChanges();

            return sb.ToString();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}