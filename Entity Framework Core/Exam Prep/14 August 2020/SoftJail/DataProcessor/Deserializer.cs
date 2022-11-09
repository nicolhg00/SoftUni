namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var departments = JsonConvert.DeserializeObject<ImportDepartmentsDto[]>(jsonString);
            List<Department> departmentList = new List<Department>();

            foreach (var department in departments)
            {
                if (!IsValid(department))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                Department d = new Department()
                {
                    Name = department.Name
                };

                bool isDepValid = true;
                foreach (var cells in department.Cells)
                {
                    if (!IsValid(cells))
                    {
                        isDepValid = false;
                        break;
                    }

                    d.Cells.Add(new Cell()
                    {
                        CellNumber = cells.CellNumber,
                        HasWindow = cells.HasWindow
                    });

                }

                if (!isDepValid)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                if (d.Cells.Count == 0)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                departmentList.Add(d);
                sb.AppendLine($"Imported {d.Name} with {d.Cells.Count} cells");
            }

            context.Departments.AddRange(departmentList);
            context.SaveChanges();

            return sb.ToString();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var prisoners = JsonConvert.DeserializeObject<ImportPrisonerDto[]>(jsonString);
            List<Prisoner> prisonerList = new List<Prisoner>();

            foreach (var prisoner in prisoners)
            {
                if (!IsValid(prisoner))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }
                if (!DateTime.TryParseExact(prisoner.IncarcerationDate, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime incarcertionDate))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                DateTime? releaseDate = null;
                if (!String.IsNullOrEmpty(prisoner.ReleaseDate)) 
                {
                    if (!DateTime.TryParseExact(prisoner.ReleaseDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime releaseDateValue))
                    {
                        sb.AppendLine("Invalid Data");
                        continue;
                    }
                    releaseDate = releaseDateValue;
                }

                Prisoner p = new Prisoner()
                {
                    FullName = prisoner.FullName,
                    Nickname = prisoner.Nickname,
                    Age = prisoner.Age,
                    IncarcerationDate = incarcertionDate,
                    ReleaseDate = releaseDate,
                    Bail = prisoner.Bail,
                    CellId = prisoner.CellId
                };

                bool isMailValid = true;
                foreach (var mails in prisoner.Mails)
                {
                    if (!IsValid(mails))
                    {
                        isMailValid = false;
                        continue;
                    }

                    p.Mails.Add(new Mail()
                    {
                        Description = mails.Description,
                        Sender = mails.Sender,
                        Address = mails.Address
                    });
                }

                if (!isMailValid)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                prisonerList.Add(p);
                sb.AppendLine($"Imported {p.FullName} {p.Age} years old");
            }

            context.Prisoners.AddRange(prisonerList);
            context.SaveChanges();

            return sb.ToString();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            var sb = new StringBuilder();
            XmlRootAttribute root = new XmlRootAttribute("Officers");
            XmlSerializer serializer = new XmlSerializer(typeof(ImportOfficerDto[]), root);

            ImportOfficerDto[] importOfficerDtos;
            List<Officer> dbOfficers = new List<Officer>();

            using (StringReader sr = new StringReader(xmlString))
            {
                importOfficerDtos = (ImportOfficerDto[])serializer.Deserialize(sr);

                foreach (var officer in importOfficerDtos)
                {
                    if (!IsValid(officer))
                    {
                        sb.AppendLine("Invalid Data");
                        continue;
                    }

                    if (!Enum.TryParse(typeof(Position), officer.Position,
                        out object position))
                    {
                        sb.AppendLine("Invalid Data");
                        continue;
                    }

                    if (!Enum.TryParse(typeof(Weapon), officer.Weapon,
                        out object weapon))
                    {
                        sb.AppendLine("Invalid Data");
                        continue;
                    }

                    Officer o = new Officer()
                    {
                        FullName = officer.FullName,
                        Salary = officer.Salary,
                        Position = (Position)position,
                        Weapon = (Weapon)weapon,
                        DepartmentId = officer.DepartmentId,

                    };

                    foreach (ImportPrisonersDto prisoner in officer.Prisoners)
                    {
                        o.OfficerPrisoners.Add(new OfficerPrisoner()
                        {
                            Officer = o,
                            PrisonerId = prisoner.PrisonerId
                        });
                    }

                    dbOfficers.Add(o);
                    sb.AppendLine($"Imported {o.FullName} ({o.OfficerPrisoners.Count} prisoners)");
                }

                context.Officers.AddRange(dbOfficers);
                context.SaveChanges();
            }

            return sb.ToString();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}