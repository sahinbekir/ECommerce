﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class ProductRating
    {
        public int ProductRatingId { get; set; }
        public int ProductId { get; set; }
        public int ProductTotalScore { get; set; }
        public int ProductRatingCount { get; set; }
    }
}