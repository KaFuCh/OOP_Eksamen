using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Eksamen {
    public abstract class Person {
        protected double _balance;
        public double Balance {
            get {
                return _balance;
            }
            set {
                if(_balance-value >= 0)
                    _balance -= value;
                else
                    throw new ArgumentOutOfRangeException("Balance", value, "Insuffient funds");
            }
        }

        public bool CheckID(string id) {
            int res = 0;
            for(int i = 0; i < id.Count() - 1; i++)
                res += int.Parse(id[id.Count() - i - 2].ToString()) * ((i % 6) + 2);

            return (11 - res % 11 == int.Parse(id[id.Count() - 1].ToString()));
        }
    }
}
