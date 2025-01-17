﻿using System;
using System.Collections.Generic;

namespace BJM.DVDCentral.PL2.Entities;


    public class tblCustomer : IEntity
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZIP { get; set; }
    public string Phone { get; set; }
    public Guid UserId { get; set; }
    public virtual ICollection<tblOrder> Orders { get; set; }

}

