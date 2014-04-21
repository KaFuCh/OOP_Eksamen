using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Eksamen {
    public class Truck : Vehicle {
        public int LoadCapacity {
            get;
            set;
        }
        public int Height {
            get;
            set;
        }
        public int Weight {
            get;
            set;
        }
        public int Length {
            get;
            set;
        }

        public Truck(string inputName, string inputRegNumber, int inputYear,
                     LicenceType inputLicence, FuelType inputFuel, decimal inputMinPrice)
            : base(inputName, inputRegNumber, inputYear, inputLicence, inputFuel, inputMinPrice) {
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

        public override string ToString() {
            string output = string.Format("Truck: {0}, {1}", RegNumber, Name);

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
            if(this.VehicleSeller != null)
                output += string.Format("\n  Seller: " + VehicleSeller);

            output += "\n------------------------------";

            return output;
        }

        public override double EngineSize {
            set {
                if(value >= 4.2 && value <= 15)
                    _engineSize = value;
                else
                    throw new ArgumentOutOfRangeException("EngineSize", value, "The engine size is not valid for the vehicle type.");
            }
        }
    }
}
