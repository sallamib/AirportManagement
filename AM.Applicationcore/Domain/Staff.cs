﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Applicationcore.Domain
{
    public class Staff : Passenger
    {
        public DateTime EmploymentDate { get; set; }
        public string Function { get; set; }
        [DataType(DataType.Currency)]
        public float  Salary  { get; set; }

    }
}
