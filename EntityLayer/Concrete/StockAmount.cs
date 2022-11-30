﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class StockAmount
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }// public Product? Product { get; set; }
        public int StockScore { get; set; }
        public int SoldScore { get; set; }
    }
}