using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Eksamen {

    enum LicenceType {
        A,
        B,
        BE,
        C,
        CE,
        D,
        DE
    };

    enum FuelType{
        Petrol,
        Diesel
    };

    enum EnergyClassType{
        A,
        B,
        C,
        D
    };

    public abstract class Vehicle {
        private LicenceType _licence;
        private FuelType _fuel;
        private string _regNumber;
        private string _name;
        private double _engineSize;
        private double _kmPrLiter;
        private uint _km;
        private int _year;
        private uint _initPrice;
        private bool _towBar;

        public string Name {
            get {
                return _name;
            }
            set {
                if(string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException();
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
                    throw new ArgumentOutOfRangeException();
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
                    throw new Exception(); //SKAL LAVES CUSTOM
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

        public bool TowBar {
            get {
                return _towBar;
            }
            set {
                _towBar = value;
            }
        }

        public LicenceType Licence {
            get {
                return _licence;
            }
            set {
                _licence = value;
            }
        }

        public double EngineSize {
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

        public FuelType Fuel {
            get {
                return _fuel;
            }
            set {
                _fuel = value;
            }
        }

        public EnergyClassType EnergyClass {
            get {
                return calcEnergyClass();
            }
        }

        private EnergyClassType calcEnergyClass() {
            EnergyClassType res = new EnergyClassType();
            if(_year < 2010) {
                if(_fuel == FuelType.Diesel) {
                    if(_kmPrLiter >= 23)
                        res = EnergyClassType.A;
                    else if(_kmPrLiter >= 18)
                        res = EnergyClassType.B;
                    else if(_kmPrLiter >= 13)
                        res = EnergyClassType.C;
                    else
                        res = EnergyClassType.D;
                } else {
                    if(_kmPrLiter >= 18)
                        res = EnergyClassType.A;
                    else if(_kmPrLiter >= 14)
                        res = EnergyClassType.B;
                    else if(_kmPrLiter >= 10)
                        res = EnergyClassType.C;
                    else
                        res = EnergyClassType.D;
                }
            } else {
                if(_fuel == FuelType.Diesel) {
                    if(_kmPrLiter >= 25)
                        res = EnergyClassType.A;
                    else if(_kmPrLiter >= 20)
                        res = EnergyClassType.B;
                    else if(_kmPrLiter >= 15)
                        res = EnergyClassType.C;
                    else
                        res = EnergyClassType.D;
                } else {
                    if(_kmPrLiter >= 20)
                        res = EnergyClassType.A;
                    else if(_kmPrLiter >= 16)
                        res = EnergyClassType.B;
                    else if(_kmPrLiter >= 12)
                        res = EnergyClassType.C;
                    else
                        res = EnergyClassType.D;
                }
            }
            return res;
        }

        public override string ToString() {
            return this._name;
        }
    }
}
