using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Maps
{

    public class Map : IMap
    {
        private IRacer racer;
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (racerOne.IsAvailable() && racerTwo.IsAvailable())
            {
                racerOne.Race();
                racerTwo.Race();

                double firstRacerWinning = ChanceOfWinning(racerOne);
                double secondRacerWinning = ChanceOfWinning(racerTwo);

                if (firstRacerWinning > secondRacerWinning)
                {
                    return string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, racerOne.Username);
                }
                else
                {
                    return string.Format(OutputMessages.RacerWinsRace, racerTwo.Username, racerOne.Username, racerTwo.Username);
                }
            }
            else if (racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerOne.Username, racerTwo.Username);
            }
            else if (!racerOne.IsAvailable() && racerTwo.IsAvailable())
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerTwo.Username, racerOne.Username);
            }
            else
            {
                return OutputMessages.RaceCannotBeCompleted;
            }
            
        }

        private double ChanceOfWinning(IRacer racer)
        {
            double racingBehavior = 0;
            if (racer.RacingBehavior == "strict")
            {
                racingBehavior = 1.2;
            }
            else
            {
                racingBehavior = 1.1;
            }
           return racer.Car.HorsePower * racer.DrivingExperience * racingBehavior;

        }
    }
}
