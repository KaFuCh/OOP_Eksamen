using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Eksamen {
    public class Truck : Vehicle {
        //PROPERTIES
        public int LoadCapacity {
            get;
            set;
        }
        public uint Height {
            get;
            set;
        }
        public uint Weight {
            get;
            set;
        }
        public uint Length {
            get;
            set;
        }
        public override Vehicle.FuelType Fuel {
            get {
                return _fuel;
            }
            set {
                if(value == FuelType.Diesel)
                    _fuel = value;
                else
                    throw new ArgumentOutOfRangeException("Fuel", value, "Trucks must be fueled by diesel");
            }
        }
        public override LicenceType Licence {
            get {
                return _licence;
            }
            set {
                if(value == LicenceType.CE || (value == LicenceType.C && !TowBar))
                    _licence = value;
                else
                    throw new ArgumentOutOfRangeException("Licence", value, "The licence type is not valid for the vehicle type.");
            }
        }
        public override double EngineSize {
            set {
                if(value >= 4.2 && value <= 15)
                    _engineSize = value;
                else
                    throw new ArgumentOutOfRangeException("EngineSize", value, "The engine size is not valid for the vehicle type.");
            }
        }

        //CONSTRUCTORS
        public Truck(string inputName, string inputRegNumber, int inputYear,
                     LicenceType inputLicence, FuelType inputFuel, decimal inputMinPrice,
                     uint inputWeight)
            : base(inputName, inputRegNumber, inputYear, inputLicence, inputFuel, inputMinPrice) {
            Weight = inputWeight;
        }

        //METHODS
        public override string ToString() {
            string output = "------------------------------";

            output += string.Format("\nTruck: {0}, {1}", RegNumber, Name);

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

            if(this.Height != 0)
                output += string.Format("\n  Height: {N0} m", Height);
            if(this.Length != 0)
                output += string.Format("\n  Length: {N0} m", Length);
            if(this.Weight != 0)
                output += string.Format("\n  Weight: {0:N0} kg", Weight);
            if(this.LoadCapacity != 0)
                output += string.Format("\n  Load capacity: " + LoadCapacity + " kg");

            output += string.Format("\n  Energy class: " + EnergyClass);
            output += string.Format("\n  Licence required: " + Licence);
            output += string.Format("\n  Fuel: " + Fuel);
            output += string.Format("\n  Has towbar: " + TowBar);

            if(this.MinPrice != 0)
                output += string.Format("\n  Minimum price: {0:C}", MinPrice);

            output += "\n------------------------------";

            return output;
        }
    }
}
