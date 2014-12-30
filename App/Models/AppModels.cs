using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace App
{
    #region Dashboard Models
    public class Vehicle
    {
        public Guid Id { get; set; }

        /// <summary>
        /// Vehicle Make
        /// </summary>
        public string Make { get; set; }

        /// <summary>
        /// Vehicle Model
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Odometer Reading
        /// </summary>
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal Odometer { get; set; }

        /// <summary>
        /// Odometer Units (eg, miles, kilometers)
        /// </summary>
        public string OdometerUnits { get; set; }

        /// <summary>
        /// avg MPG calculation 
        /// </summary>
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal MPG { get; set; }

        /// <summary>
        /// avg MPG Units (eg, MPG, MPL)
        /// </summary>
        public string MPGUnits { get; set; }

        /// <summary>
        /// Cost per mile/kilo, whatever
        /// </summary>
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal CostPer { get; set; }

        /// <summary>
        /// Currency for cost (eg, $)
        /// </summary>
        public string CostPerCurrency { get; set; }

        /// <summary>
        /// Units for cost per (eg, miles, kilos)
        /// </summary>
        public string CostPerUnits { get; set; }

        /// <summary>
        /// Next estimated service date
        /// </summary>
        [DisplayFormat(DataFormatString = "{0:m}")]
        public DateTime EstimatedService { get; set; }

        /// <summary>
        /// Does this vehicle have an alert
        /// </summary>
        public bool HasAlert { get; set; }

        /// <summary>
        /// Picture of this vehicle
        /// </summary>
        public Uri Picture { get; set; }
    }

    public class UserVehicles
    {
        public List<Vehicle> Vehicles { get; set; }
    }

    #endregion

    #region FillupModels
    public class FillupSubmission
    {
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal Odometer { get; set; }

        public decimal Gallons { get; set; }

        public decimal Cost { get; set; }

        public string Octane { get; set; }
        public DateTime FillupDate { get; set; }

        public bool isFull { get; set; }
    }

    public class Fillup
    {
        public string Octane { get; set; }
        public int Number { get; set; }
        [DisplayFormat(DataFormatString="{0:d MMM, yyyy}")]
        public DateTime LastFillup { get; set; }
        [DisplayFormat(DataFormatString = "{0:d MMM, yyyy}")]
        public DateTime ThisFillup { get; set; }
        public bool OnTrip { get; set; }
        public string TripName { get; set; }
        public Guid TripId { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal MPG { get; set; }
        public string MPGUnits { get; set; }

        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal Travelled { get; set; }
        public string TravelledUnits { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal Cost { get; set; }
    }

    public class VehicleFillups
    {
        public List<Fillup> Fillups { get; set; }
    }

    #endregion

    #region mocks
    public static class Mocks
    {
        public static UserVehicles getDashMock()
        {
            var cars = new List<Vehicle>();

            var car = new Vehicle
            {
                CostPer = 0.11M,
                CostPerCurrency = "$",
                CostPerUnits = "mile",
                EstimatedService = new DateTime(2015, 01, 22),
                HasAlert = true,
                Make = "Dodge",
                Model = "Calibur",
                MPG = 22.43M,
                MPGUnits = "MPG",
                Odometer = 97232,
                OdometerUnits = "miles",
                Picture = new Uri("http://4hdwallpapers.com/wp-content/uploads/2013/04/The-Lion-King-Desktop-1024x640.jpg"),
                Id = Guid.NewGuid()
            };

            var otherCar = new Vehicle
            {
                CostPer = 0.03M,
                CostPerCurrency = "$",
                CostPerUnits = "mile",
                EstimatedService = new DateTime(2015, 04, 1),
                HasAlert = false,
                Id = Guid.NewGuid(),
                Make = "Toyota",
                Model = "Prius",
                MPG = 43M,
                MPGUnits = "MPG",
                Odometer = 123532M,
                OdometerUnits = "miles",
                Picture = new Uri("http://4hdwallpapers.com/wp-content/uploads/2013/04/The-Lion-King-Desktop-1024x640.jpg")
            };

            cars.Add(car);
            cars.Add(otherCar);

            var ret = new UserVehicles
            {
                Vehicles = cars
            };

            return ret;
        }

        public static VehicleFillups getFillupMock()
        {
            var fills = new List<Fillup>();

            var f1 = new Fillup
            {
                Cost = 26.32M,
                LastFillup = new DateTime(2014, 11, 28),
                MPG = 24.2311M,
                MPGUnits = "MPG",
                Number = 1,
                Octane = "93 Octane",
                OnTrip = false,
                ThisFillup = new DateTime(2014, 12, 2),
                Travelled = 231,
                TravelledUnits = "Miles"
            };

            var f2 = new Fillup
            {
                Cost = 26.32M,
                LastFillup = new DateTime(2014, 12, 2),
                MPG = 22M,
                MPGUnits = "MPG",
                Number = 2,
                Octane = "93 Octane",
                OnTrip = true,
                ThisFillup = new DateTime(2014, 12, 15),
                Travelled = 200,
                TravelledUnits = "Miles",
                TripId = Guid.NewGuid(),
                TripName = "Christmas 2014"
            };

            fills.Add(f2);
            fills.Add(f1);

            var mock = new VehicleFillups
            {
                Fillups = fills
            };

            return mock;
        }
    }
    #endregion
}
