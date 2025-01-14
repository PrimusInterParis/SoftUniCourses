﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.DTO
{
    public class PartInputModel
    {

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public int SupplierId { get; set; }

        /*
            *   "name": "Turbocharger",
                "price": 0.4,
                "quantity": 10,
                "supplierId": 2
         */
    }
}
