namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.Data.Models;
    using TeisterMask.Data.Models.Enums;
    using TeisterMask.DataProcessor.ImportDto;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Projects");
            XmlSerializer serializer = new XmlSerializer(typeof(ImportProjectsDto[]), xmlRoot);

            using StringReader sr = new StringReader(xmlString);

            ImportProjectsDto[] projectsDtos = (ImportProjectsDto[])serializer.Deserialize(sr);

            HashSet<Project> projects = new HashSet<Project>();

            foreach (var project in projectsDtos)
            {
                if (!IsValid(project))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (!DateTime.TryParseExact(project.OpenDate, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime openDate))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime? dueDate = null;
                if (!String.IsNullOrWhiteSpace(project.DueDate))
                {
                    if (!DateTime.TryParseExact(project.DueDate, "dd/MM/yyyy",
                   CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dueDateValue))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    dueDate = dueDateValue;
                }

                Project p = new Project()
                {
                    Name = project.Name,
                    OpenDate = openDate,
                    DueDate = dueDate
                };

                HashSet<Task> projectTasks = new HashSet<Task>();
                foreach (var task in project.Tasks)
                {
                    if (!IsValid(task))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (!DateTime.TryParseExact(task.OpenDate, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, 
                    out DateTime taskOpenDate))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (!DateTime.TryParseExact(task.DueDate, "dd/MM/yyyy",
                   CultureInfo.InvariantCulture, DateTimeStyles.None, 
                   out DateTime taskDueTime))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    if (taskOpenDate < p.OpenDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    if (p.DueDate.HasValue && taskDueTime > p.DueDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Task t = new Task()
                    {
                        Name = task.Name,
                        OpenDate = taskOpenDate,
                        DueDate = taskDueTime,
                        ExecutionType = (ExecutionType)task.ExecutionType,
                        LabelType = (LabelType)task.LabelType
                    };

                    projectTasks.Add(t);
                }
                p.Tasks = projectTasks;
                projects.Add(p);

                sb.AppendLine(String.Format(SuccessfullyImportedProject, p.Name, projectTasks.Count));
            }

            context.Projects.AddRange(projects);
            context.SaveChanges();

            return sb.ToString().TrimEnd();

        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var employee = JsonConvert.DeserializeObject<ImportEmployeeDto[]>(jsonString);

            List<Employee> employeeList = new List<Employee>();

            foreach (var employees in employee)
            {
                if (!IsValid(employees))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Employee e = new Employee()
                {
                    Username = employees.Username,
                    Email = employees.Email,
                    Phone = employees.Phone
                };

                
                foreach (var taskId in employees.Tasks.Distinct())
                {
                    Task task = context
                        .Tasks
                        .Find(taskId);

                    if (task == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    e.EmployeesTasks.Add(new EmployeeTask()
                    {
                        TaskId = taskId
                    });
                }

                employeeList.Add(e);
                sb.AppendLine(String.Format(SuccessfullyImportedEmployee, e.Username, e.EmployeesTasks.Count));

            }

            context.Employees.AddRange(employeeList);
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