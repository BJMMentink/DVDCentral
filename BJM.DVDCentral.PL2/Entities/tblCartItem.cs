﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BJM.DVDCentral.PL2.Entities
{
    public class tblCartItem
    {
        public Guid Id { get; set; }
        public Guid CartId { get; set; }
        public Guid MovieId { get; set; }
        public int Qty { get; set; }
        public virtual tblCart Cart { get; set; } 
        public virtual tblMovie Movie { get; set; } 
    }
}