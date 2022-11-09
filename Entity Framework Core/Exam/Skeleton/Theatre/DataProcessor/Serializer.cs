namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            var theaters = context
                 .Theatres
                 .ToArray()
                 .Where(t => t.NumberOfHalls >= numbersOfHalls && t.Tickets.Count >= 20)
                 .Select(t => new
                 {
                     Name = t.Name,
                     Halls = t.NumberOfHalls,
                     TotalIncome = t.Tickets
                     .ToArray()
                     .Where(t => t.RowNumber <= 5)
                     .Sum(tp => tp.Price),
                     Tickets = t.Tickets
                     .ToArray()
                     .Where(t => t.RowNumber <= 5)
                     .Select(tk => new
                     {
                         Price = tk.Price,
                         RowNumber = tk.RowNumber
                     })
                     .OrderByDescending(tk => tk.Price)
                 })
                 .OrderByDescending(t => t.Halls)
                 .ThenBy(t => t.Name)

                 .ToArray();
            return JsonConvert.SerializeObject(theaters, Formatting.Indented);
        }

        public static string ExportPlays(TheatreContext context, double rating)
        {
            StringBuilder sb = new StringBuilder();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportPlaysDtos[]),
                new XmlRootAttribute("Plays"));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            ExportPlaysDtos[] playsDtos = context
                .Plays
                .ToArray()
                .Where(p => p.Rating <= rating)
                .Select(p => new ExportPlaysDtos
                {
                    Title = p.Title,
                    Duration = p.Duration.ToString("c", CultureInfo.CurrentCulture),
                    Rating = p.Rating == 0  ? "Premier" : p.Rating.ToString(),
                    Genre = p.Genre.ToString(),
                    Actors = p.Casts
                    .ToArray()
                    .Where(a => a.IsMainCharacter == true)
                    .Select(a => new ExportActorsDtos
                    {
                        FullName = a.FullName,
                        MainCharacter = $"Plays main character in '{p.Title}'."

                    })
                    .OrderByDescending(a => a.FullName)
                    .ToArray()
                })
                .OrderBy(p => p.Title)
                .ThenByDescending(p => p.Genre)
                .ToArray();

            using (StringWriter sw = new StringWriter(sb))
            {
                xmlSerializer.Serialize(sw, playsDtos, namespaces);
            }

            return sb.ToString();

        }
    }
}
