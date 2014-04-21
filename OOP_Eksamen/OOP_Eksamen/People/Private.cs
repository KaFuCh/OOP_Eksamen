using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Eksamen {
    public class Private : IPrivate {
        //PROPERTIES
        private string _cpr;
        private decimal _balance;

        public string CPR {
            get {
                return _cpr.Substring(0, 6) + "-****";
            }
            set {
                if(value.Length == 10 && value.All(char.IsDigit) && CheckCPR(value))
                    _cpr = value;
                else
                    throw new ArgumentOutOfRangeException("CPR", value, "The CPR Number is not valid");
            }
        }

        public decimal Balance {
            get {
                return _balance;
            }
            set {
                _balance = value;
            }
        }

        //METHODS
        public void pay(decimal cost) {
            if(_balance - cost >= 0)
                _balance -= cost;
            else
                throw new ArgumentOutOfRangeException("Balance", cost, "Insuffient funds");
        }

        public bool CheckCPR(string cpr) {
            int res = 0;
            for(int i = 0; i < cpr.Count() - 1; i++)
                res += (cpr[cpr.Count() - i - 2] - '0') * ((i % 6) + 2);

            return (11 - res % 11 == cpr[cpr.Count() - 1] - '0');
        }
    }
}
