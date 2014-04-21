using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Eksamen {
    public enum EnergyClassType {
        A,
        B,
        C,
        D
    }
    public abstract class Vehicle {
        public enum LicenceType {
            A,
            B,
            BE,
            C,
            CE,
            D,
            DE
        }

        public enum FuelType {
            Petrol,
            Diesel
        }

        protected LicenceType _licence;
        protected FuelType _fuel;
        protected string _regNumber;
        protected string _name;
        protected decimal _minPrice;
        protected double _engineSize;
        protected double _kmPrLiter;
        protected uint _km;
        protected int _year;
        protected uint _initPrice;
        protected bool _towBar;

        public Action<Vehicle, decimal> notify {
            get;
            set;
        }

        public Seller VehicleSeller {
            get;
            set;
        }
        public Dictionary<int, decimal> Bids = new Dictionary<int, decimal>();
        public List<Buyer> Biders = new List<Buyer>();

        public decimal MinPrice {
            get {
                return _minPrice;
            }
            set {
                if(value > 0)
                    _minPrice = value;
                else
                    throw new ArgumentOutOfRangeException("MinPrice", value, "Price must be positive.");
            }
        }
        public string Name {
            get {
                return _name;
            }
            set {
                if(string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("Name", "The name is not valid");
                else
                    _name = value;
            }
        }

        public uint Km {
            get {
                return _km;
            }
            set {
                if(value < 0)
                    throw new ArgumentOutOfRangeException("Km", value, "Mileage cannot be negative");
                else
                    _km = value;
            }
        }

        public string RegNumber {
            get {
                return "**" + _regNumber.Substring(3, 3) + "**";
            }
            set {
                if(value.Substring(0, 2).All(char.IsLetter) && value.Substring(2, 5).All(char.IsNumber))
                    _regNumber = value;
                else
                    throw new InvalidRegNoException(value);
            }
        }

        public int Year {
            get {
                return _year;
            }
        }

        public uint InitPrice {
            get {
                return _initPrice;
            }
            set {
                if(value < 0)
                    value = 0;
                _initPrice = value;
            }
        }

        public virtual bool TowBar {
            get {
                return _towBar;
            }
            set {
                _towBar = value;
            }
        }

        public virtual LicenceType Licence {
            get {
                return _licence;
            }
            set {
                _licence = value;
            }
        }

        public virtual double EngineSize {
            get {
                return _engineSize;
            }
            set {
                _engineSize = value;
            }
        }

        public double KmPrLiter {
            get {
                return _kmPrLiter;
            }
            set {
                _kmPrLiter = value;
            }
        }

        public virtual FuelType Fuel {
            get {
                return _fuel;
            }
            set {
                _fuel = value;
            }
        }

        public virtual EnergyClassType EnergyClass {
            get {
                return calcEnergyClass(1.0);
            }
        }
        //CONSTRUCTOR
        public Vehicle(string inputName, string inputRegNumber, int inputYear,
                       LicenceType inputLicence, FuelType inputFuel, decimal inputMinPrice) {
            Name = inputName;
            RegNumber = inputRegNumber;
            _year = inputYear;
            Licence = inputLicence;
            Fuel = inputFuel;
            MinPrice = inputMinPrice;
        }

        //METHODS

        protected EnergyClassType calcEnergyClass(double factor) {
            EnergyClassType res = new EnergyClassType();
            double kpl = _kmPrLiter*factor; 
            if(_year < 2010) {
                if(_fuel == FuelType.Diesel) {
                    if(kpl >= 23)
                        res = EnergyClassType.A;
                    else if(kpl >= 18)
                        res = EnergyClassType.B;
                    else if(kpl >= 13)
                        res = EnergyClassType.C;
                    else
                        res = EnergyClassType.D;
                } else {
                    if(kpl >= 18)
                        res = EnergyClassType.A;
                    else if(kpl >= 14)
                        res = EnergyClassType.B;
                    else if(kpl >= 10)
                        res = EnergyClassType.C;
                    else
                        res = EnergyClassType.D;
                }
            } else {
                if(_fuel == FuelType.Diesel) {
                    if(kpl >= 25)
                        res = EnergyClassType.A;
                    else if(kpl >= 20)
                        res = EnergyClassType.B;
                    else if(kpl >= 15)
                        res = EnergyClassType.C;
                    else
                        res = EnergyClassType.D;
                } else {
                    if(kpl >= 20)
                        res = EnergyClassType.A;
                    else if(kpl >= 16)
                        res = EnergyClassType.B;
                    else if(kpl >= 12)
                        res = EnergyClassType.C;
                    else
                        res = EnergyClassType.D;
                }
            }
            return res;
        }
    }
}
