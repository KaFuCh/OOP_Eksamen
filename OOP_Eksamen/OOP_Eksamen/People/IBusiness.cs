using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Eksamen {
    public interface IBusiness{
        
        // PROPERTIES
        protected string _cvr;
        protected decimal _balance;

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

        public decimal Balance {
            set {
                if(_balance + Credit - value >= 0)
                    _balance -= value;
                else
                    throw new ArgumentOutOfRangeException("Balance", value, "Insuffient funds");
            }
        }

        public decimal Credit {
            get;
            set;
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
    