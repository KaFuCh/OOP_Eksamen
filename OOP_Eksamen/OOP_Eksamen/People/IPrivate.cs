using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Eksamen {
    public interface IPrivate{

        // PROPERTIES
        protected string _cpr;
        protected decimal _balance;

        public string CPR {
            get {
                return _cpr.Substring(0, 6) + "-****";
            }
            set {
                if(value.Length == 10 && value.All(char.IsDigit) && CheckID(value))
                    _cpr = value;
                else
                    throw new ArgumentOutOfRangeException("CPR", value, "The CPR Number is not valid");
            }
        }

        public decimal Balance {
            set {
                if(_balance - value >= 0)
                    _balance -= value;
                else
                    throw new ArgumentOutOfRangeException("Balance", value, "Insuffient funds");
            }
        }

        // METHODS
        public bool CheckID(string id) {
            int res = 0;
            for(int i = 0; i < id.Count() - 1; i++)
                res += (id[id.Count() - i - 2] - '0') * ((i % 6) + 2);

            return (11 - res % 11 == id[id.Count() - 1] - '0');
        }
    }
}
