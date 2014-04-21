using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Eksamen {
    class CarPrivate : Car {
        public bool IsoFix {
            get;
            set;
        }

        public CarPrivate(string inputName, string inputRegNumber, int inputYear,
                          LicenceType inputLicence, FuelType inputFuel, decimal inputMinPrice)
            : base(inputName, inputRegNumber, inputYear, inputLicence, inputFuel, inputMinPrice) {
        }

        public override int NoOfSeats{
            get {
                return _noOfSeats;
            }
            set {
                if(value > 1 && value < 8)
                    _noOfSeats = value;
                else
                    throw new ArgumentOutOfRangeException("Number of seats", value, "The number of seats is not valid for the vehicle type.");
            }
        }

        public override string ToString() {
            string output = "------------------------------";

            output += string.Format("\nPrivate car: {0}, {1}", RegNumber, Name);

            if(this.Year != 0)
                output += string.Format("\n  Made in " + Year);
            if(this.InitPrice != 0)
                output += string.Format("\n  Initial price: " + InitPrice);
            if(this.EngineSize != 0)
                output += string.Format("\n  Engine size: " + EngineSize);
            if(this.Km != 0)
                output += string.Format("\n  Mileage: " + Km + " km");
            if(this.KmPrLiter != 0)
                output += string.Format("\n  Km/L: " + KmPrLiter);
            if(this.NoOfSeats != 0)
                output += string.Format("\n  Number of seats: " + NoOfSeats);
            if(this.TrunkDimensions[0] != 0 && this.TrunkDimensions[1] != 0 && this.TrunkDimensions[2] != 0)
                output += string.Format("\n  Trunk dimentions: {0} m x {1} m x {2} m", TrunkDimensions[0], TrunkDimensions[1], TrunkDimensions[2]);

            output += string.Format("\n  Energy class: " + EnergyClass);
            output += string.Format("\n  Licence required: " + Licence);
            output += string.Format("\n  Fuel: " + Fuel);
            output += string.Format("\n  Has towbar: " + TowBar);
            output += string.Format("\n  Has isofix: " + IsoFix);

            if(this.MinPrice != 0)
                output += string.Format("\n  Minimum price: {0:C}", MinPrice);

            output += "\n------------------------------";

            return output;
        }
    }
}
