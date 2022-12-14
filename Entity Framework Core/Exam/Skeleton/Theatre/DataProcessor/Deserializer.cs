namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.Data.Models;
    using Theatre.Data.Models.Enums;
    using Theatre.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";

        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            var sb = new StringBuilder();
            XmlRootAttribute root = new XmlRootAttribute("Plays");
            XmlSerializer serializer = new XmlSerializer(typeof(ImportPlaysDto[]), root);
            ImportPlaysDto[] plays;
            List<Play> playList = new List<Play>();

            using (StringReader sr = new StringReader(xmlString))
            {
                plays = (ImportPlaysDto[])serializer.Deserialize(sr);

                foreach (var playDto in plays)
                {
                    if (!IsValid(playDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }


                    if (!TimeSpan.TryParseExact(playDto.Duration, "c",
                        CultureInfo.InvariantCulture, TimeSpanStyles.None,
                        out TimeSpan duration))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    if (duration.Hours < 1)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    if (!Enum.TryParse(typeof(Genre), playDto.Genre, out object genre))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Play p = new Play()
                    {
                        Title = playDto.Title,
                        Duration = duration,
                        Rating = playDto.Rating,
                        Genre = (Genre)genre,
                        Description = playDto.Description,
                        Screenwriter = playDto.Screenwriter
                    };

                    playList.Add(p);
                    sb.AppendLine(String.Format(SuccessfulImportPlay, p.Title, p.Genre, p.Rating));
                }

                context.Plays.AddRange(playList);
                context.SaveChanges();
            }

            return sb.ToString();
        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            var sb = new StringBuilder();
            XmlRootAttribute root = new XmlRootAttribute("Casts");
            XmlSerializer serializer = new XmlSerializer(typeof(ImportCastDto[]), root);
            ImportCastDto[] casts;
            List<Cast> castList = new List<Cast>();

            using (StringReader sr = new StringReader(xmlString))
            {
                casts = (ImportCastDto[])serializer.Deserialize(sr);
                foreach (var castsDto in casts)
                {
                    if (!IsValid(castsDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Cast c = new Cast()
                    {
                        FullName = castsDto.FullName,
                        IsMainCharacter = castsDto.IsMainCharacter,
                        PhoneNumber = castsDto.PhoneNumber,
                        PlayId = castsDto.PlayId
                    };

                    castList.Add(c);
                    if (c.IsMainCharacter == true)
                    {
                        sb.AppendLine(String.Format(SuccessfulImportActor, c.FullName, "main"));
                    }
                    else
                    {
                        sb.AppendLine(String.Format(SuccessfulImportActor, c.FullName, "lesser"));
                    }

                }
                context.Casts.AddRange(castList);
                context.SaveChanges();
            }
            return sb.ToString();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var theatres = JsonConvert.DeserializeObject<ImportTheatreDtos[]>(jsonString);
            List<Theatre> theatreList = new List<Theatre>();

            foreach (var theatre in theatres)
            {
                if (!IsValid(theatre))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Theatre t = new Theatre()
                {
                    Name = theatre.Name,
                    NumberOfHalls = theatre.NumberOfHalls,
                    Director = theatre.Director
                };

                
                foreach (var ticket in theatre.Tickets)
                {
                    if (!IsValid(ticket))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    t.Tickets.Add(new Ticket()
                    {
                        Price = ticket.Price,
                        RowNumber = ticket.RowNumber,
                        PlayId = ticket.PlayId
                    });
                }
                theatreList.Add(t);
                sb.AppendLine(String.Format(SuccessfulImportTheatre, t.Name, t.Tickets.Count));
            }
            context.Theatres.AddRange(theatreList);
            context.SaveChanges();

            return sb.ToString();
        }


        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
