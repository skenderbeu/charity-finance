﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceEntities
{
    public class Income : Transaction
    {
        public string PayingInSlip { get; set; }
        public GiftAidStatus GiftAidStatus { get; set; }
    }
}
