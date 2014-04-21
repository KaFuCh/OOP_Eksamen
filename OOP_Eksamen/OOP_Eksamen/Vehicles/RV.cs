using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Eksamen {
    public class RV : Vehicle {
        public enum HeatingSystemType {
            No,
            Gas,
            Electric,
            Oil
        }

        public uint NoOfSeats {
            get;
            set;
        }
        public uint NoOfSleepSpots {
            get;
            set;
        }
        public HeatingSystemType HeatingSystem {
            get;
            set;
        }

        public bool Toilet {
            get;
            set;
        }

        public RV(string inputName, string inputRegNumber, int inputYear,
                  LicenceType inputLicence, FuelType inputFuel, decimal inputMinPrice,
                  HeatingSystemType inputHS)
            : base(inputName, inputRegNumber, inputYear, inputLicence, inputFuel, inputMinPrice) {
            HeatingSystem = inputHS;
        }

        public override LicenceType Licence {
            get {
                return _licence;
            }
            set {
                if(value == LicenceType.B)
                    _licence = value;
                else
                    throw new ArgumentOutOfRangeException("Licence", value, "The licence type is not valid for the vehicle type.");
            }
        }

        public override EnergyClassType EnergyClass {
            get {
                if(HeatingSystem == HeatingSystemType.Oil)
                    return calcEnergyClass(0.7);
                else if(HeatingSystem == HeatingSystemType.Electric)
                    return calcEnergyClass(0.8);
                else if(HeatingSystem == HeatingSystemType.Gas)
                    return calcEnergyClass(0.9);
                else
                    throw new MemberAccessException("Cannot calculate energy class. Heating system not set.");
            }
        }

        public override double EngineSize {
            set {
                if(value >= 2.4 && value <= 6.2)
                    _engineSize = value;
                else
                    throw new ArgumentOutOfRangeException("EngineSize", value, "The engine size is not valid for the vehicle type.");
            }
        }

        public override string ToString() {
            string output = "------------------------------";

            output += string.Format("\nRV: {0}, {1}", RegNumber, Name);

            if(this.Year != 0)
                output += string.Format("\n  Made in " + Year);
            if(this.InitPrice != 0)
                output += string.Format("\n  Initial price: " + InitPrice);
            if(this.EngineSize != 0)
                output += string.Format("\n  Engine size: " + EngineSize);
            if(this.InitPrice != 0)
                output += string.Format("\n  Initial price: " + InitPrice);
            if(this.Km != 0)
                output += string.Format("\n  Mileage: " + Km + " km");
            if(this.KmPrLiter != 0)
                output += string.Format("\n  Km/L: " + KmPrLiter);

            if(this.NoOfSeats != 0)
                output += string.Format("\n  Number of seats: " + NoOfSeats);
            if(this.NoOfSleepSpots != 0)
                output += string.Format("\n  Number of sleeping spots: " + NoOfSleepSpots);

            output += string.Format("\n  Energy class: " + EnergyClass);
            output += string.Format("\n  Licence required: " + Licence);
            output += string.Format("\n  Fuel: " + Fuel);
            output += string.Format("\n  Has towbar: " + TowBar);
            output += string.Format("\n  Heating system uses " + this.HeatingSystem);
            output += string.Format("\n  Has toilet: " + Toilet);

            if(this.MinPrice != 0)
                output += string.Format("\n  Minimum price: {0:C}", MinPrice);

            output += "\n------------------------------";

            return output;
        }
    }
}
