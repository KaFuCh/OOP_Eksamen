using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Eksamen {
    public class Business : IBusiness {
        private string _cvr;
        private decimal _balance;

        public string CVR {
            get {
                return _cvr;
            }
            set {
                if(value.Length == 8 && value.All(char.IsDigit) && CheckCVR(value))
                    _cvr = value;
                else
                    throw new ArgumentOutOfRangeException("CVR", value, "The CVR Number is not valid");
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

        public void pay(decimal cost) {
            if(_balance + Credit - cost >= 0)
                _balance -= cost;
            else
                throw new ArgumentOutOfRangeException("Balance", cost, "Insuffient funds");
        }

        public decimal Credit {
            get;
            set;
        }

        //METHODS
        public bool CheckCVR(string cvr) {
            int res = 0;
            for(int i = 0; i < cvr.Count() - 1; i++)
                res += (cvr[cvr.Count() - i - 2] - '0') * ((i % 6) + 2);

            return (11 - res % 11 == cvr[cvr.Count() - 1] - '0');
        }
    }
}
