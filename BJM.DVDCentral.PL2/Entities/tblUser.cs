﻿using System;
using System.Collections.Generic;

namespace BJM.DVDCentral.PL2.Entities;

public class tblUser : IEntity
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Password { get; set; }
}

