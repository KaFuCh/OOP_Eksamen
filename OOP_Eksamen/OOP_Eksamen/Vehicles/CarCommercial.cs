using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Eksamen {
    class CarCommercial : Car{
        //FIELDS
        private uint _loadCapacity;

        //PROPERTIES
        public bool SafetyBar {
            get;
            set;
        }
        public uint LoadCapacity {
            get {
                return _loadCapacity;
            }
            set {
                if(_licence == LicenceType.B && value > 750)
                    throw new ArgumentOutOfRangeException("LoadCapacity", value, "Incorrect load capacity or licence type.");
                else
                    _loadCapacity = value;
            }
        }
        public override int NoOfSeats {
            get {
                return _noOfSeats;
            }
            set {
                if(value == 2)
                    _noOfSeats = value;
                else
                    throw new ArgumentOutOfRangeException("Number of seats", value, "The number of seats is not valid for the vehicle type.");
            }
        }

        public override LicenceType Licence {
            get {
                return _licence;
            }
            set {
                if(value == LicenceType.BE || (value == LicenceType.B && LoadCapacity < 751))
                    _licence = value;
                else
                    throw new ArgumentOutOfRangeException("Licence", value, "The licence type is not valid for the vehicle type.");
            }
        }
        public override bool TowBar {
            get {
                return _towBar;
            }
            set {
                if(value == true)
                    _towBar = value;
                else
                    throw new ArgumentOutOfRangeException("Towbar", value, "Commercial bar must have towbar");

            }
        }

        //CONSTRUCTORS
        public CarCommercial(string inputName, string inputRegNumber, int inputYear,
                             LicenceType inputLicence, FuelType inputFuel, decimal inputMinPrice)
            : base(inputName, inputRegNumber, inputYear, inputLicence, inputFuel, inputMinPrice) {
            _towBar = true;
        }

        //METHODS
        public override string ToString() {
            string output = "------------------------------";
            output += string.Format("\nCommercial car: {0}, {1}", RegNumber, Name);

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
            output += string.Format("\n  Has safetybar: " + SafetyBar);

            if(this.MinPrice != 0)
                output += string.Format("\n  Minimum price: {0:C}", MinPrice);

            output += "\n------------------------------";

            return output;
        }
    }
}
