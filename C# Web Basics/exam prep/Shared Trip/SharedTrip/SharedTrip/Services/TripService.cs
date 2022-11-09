using SharedTrip.Contracts;
using SharedTrip.Data.Common;
using SharedTrip.Data.Models;
using SharedTrip.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.Services
{
    public class TripService : ITripService
    {
        private readonly IRepository repo;
        public TripService(IRepository _repo)
        {
            repo = _repo;
        }
        public void AddTrip(TripViewModel model)
        {
            Trip trip = new Trip()
            {
                Description = model.Description,
                EndPoint = model.EndPoint,
                StartPoint = model.StartPoint,
                Seats = model.Seats,
                ImagePath = model.ImagePath
            };
            DateTime date;
            DateTime.TryParseExact(model.DepartureTime, "dd.MM.yyyy HH:mm",
                CultureInfo.InvariantCulture, DateTimeStyles.None, out date);

            trip.DepartureTime = date;

            repo.Add(trip);
            repo.SaveChanges();
        }

        public void AddUserToTrip(string tripId, string id)
        {
           var user =repo.All<User>()
                .FirstOrDefault(u => u.Id == id);
            var trip = repo.All<Trip>()
                .FirstOrDefault(t => t.Id == tripId);

            if (user == null || trip == null)
            {
                throw new ArgumentException("User or trip not found");
            }

            user.UserTrips.Add(new UserTrip()
            {
                TripId = tripId,
                Trip = trip,
                User = user,
                UserId = id
            });

            repo.SaveChanges();
        }

        public IEnumerable<TripListViewModel> GetAllTrips()
        {
            return repo.All<Trip>()
                .Select(t => new TripListViewModel()
                {
                    DepartureTime = t.DepartureTime.ToString("dd.MM.yyyy HH:mm"),
                    EndPoind = t.EndPoint,
                    Seats = t.Seats,
                    Id = t.Id,
                    StartPoint = t.StartPoint
                });
        }

        public TripDetailsViewModel GetTripDetails(string tripId)
        {
            return repo.All<Trip>()
                 .Where(t => t.Id == tripId)
                 .Select(t => new TripDetailsViewModel()
                 {
                     DepartureTime = t.DepartureTime.ToString("dd.MM.yyyy HH:mm"),
                     EndPoint = t.EndPoint,
                     Description = t.Description,
                     Id = t.Id,
                     ImagePath = t.ImagePath,
                     Seats = t.Seats,
                     StartPoint = t.StartPoint
                 }).FirstOrDefault();

        }

        public (bool isValid, IEnumerable<ErrorViewModel> errors)
            ValidateModel(TripViewModel model)
        {
            bool isValid = false;
            List<ErrorViewModel> errors = new List<ErrorViewModel>();
            DateTime date;

            if (string.IsNullOrWhiteSpace(model.StartPoint))
            {
                isValid = true;
                errors.Add(new ErrorViewModel("StartPoint is required"));
            }
            if (string.IsNullOrWhiteSpace(model.EndPoint))
            {
                isValid = true;
                errors.Add(new ErrorViewModel("EndPoint is required"));
            }
            if (string.IsNullOrWhiteSpace(model.Description)
                || model.Description.Length > 80)
            {
                isValid = true;
                errors.Add(new ErrorViewModel("Description is required and " +
                    "must not be more than 80 characters long"));
            }
            if (model.Seats < 2 || model.Seats > 6)
            {
                isValid = true;
                errors.Add(new ErrorViewModel("Seats must be between 2 and 6"));
            }
            if (!DateTime.TryParseExact(model.DepartureTime, "dd.MM.yyyy HH:mm",
                CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
            {
                isValid = true;
                errors.Add(new ErrorViewModel("Seats must be between 2 and 6"));
            }
            return (isValid, errors);
        }
    }
}
