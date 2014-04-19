﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Eksamen {
    public abstract class Buyer{
        public abstract decimal Balance {
            get;
            set;
        }
        public abstract decimal ReservedBalance {
            get;
            set;
        }
        public virtual bool reserveBalance(decimal bid, int auctionNo, AuctionHouse AH) {
            throw new NotImplementedException("Reserve balance function is not implemented");
        }

    }
}
