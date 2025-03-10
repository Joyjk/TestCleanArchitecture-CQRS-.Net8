﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Domain.Model
{
    public class Product : BaseClass
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
    }
}
