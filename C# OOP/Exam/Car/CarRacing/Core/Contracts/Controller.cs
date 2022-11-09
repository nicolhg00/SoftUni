using CarRacing.Models.Cars;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CarRacing.Core.Contracts
{
    public class Controller : IController
    {
        private CarRepository cars;
        private RacerRepository racers;
        private IMap map;

        public Controller()
        {
        }

        public Controller(IMap map)
        {
            cars = new CarRepository();
            racers = new RacerRepository();
            this.map = map;
            
        }

        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            ICar car = null ;
            if (type == "SuperCar")
            {
                car = new SuperCar(make, model, VIN, horsePower);
            }
            else if (type == "TunedCar")
            {
                car = new TunedCar(make, model, VIN, horsePower);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidCarType);
            }
            cars.Add(car);
            return string.Format(OutputMessages.SuccessfullyAddedCar, make, model, VIN);
        }

        public string AddRacer(string type, string username, string carVIN)
        {
            IRacer racer = null;
            if (type == "ProfessionalRacer")
            {
                racer = new ProfessionalRacer(username, racer.Car);
            }
            else if (type == "StreetRacer")
            {
                racer = new StreetRacer(username, racer.Car);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidRacerType);
            }

            if (racer.Car == null)
            {
                throw new ArgumentException(ExceptionMessages.CarCannotBeFound);
            }

            racers.Add(racer);
            return string.Format(OutputMessages.SuccessfullyAddedRacer, username);
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            IRacer racerOne = racers.FindBy(racerOneUsername);
            IRacer racerTwo = racers.FindBy(racerTwoUsername);

            if (racerOne == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RacerCannotBeFound), racerOneUsername);
            }
            else if (racerTwo == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RacerCannotBeFound), racerTwoUsername);
            }
            return map.StartRace(racerOne, racerTwo);
        }

        public string Report()
        {

            StringBuilder sb = new StringBuilder();
            var orderByAlphabetic = racers.Models
                .OrderByDescending(x => x.DrivingExperience)
                .ThenBy(y => y.Username);

            foreach (var item in orderByAlphabetic)
            {
                sb.AppendLine($"{item.GetType().Name}: {item.Username}");
                sb.AppendLine($"--Driving behavior: {item.RacingBehavior}");
                sb.AppendLine($"--Driving experience: {item.DrivingExperience}");
                sb.AppendLine($"--Car: {item.Car.Make} {item.Car.Model} ({item.Car.VIN})");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
