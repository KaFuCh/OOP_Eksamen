using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Eksamen {
    public abstract class Business : Person{
        private string _cvr;
        public string CVR {
            get {
                return _cvr;
            }
            set {
                if(value.Length == 8 && value.All(char.IsDigit) && CheckID(value))
                    _cvr = value;
                else
                    throw new ArgumentOutOfRangeException("CVR", value, "The CVR Number is not valid");
            }
        }

        public override double Balance {
            set {
                if(_balance + Credit - value >= 0)
                    _balance -= value;
                else
                    throw new ArgumentOutOfRangeException("Balance", value, "Insuffient funds");
            }
        }

        public double Credit {
            get;
            set;
        }
    }
}
    