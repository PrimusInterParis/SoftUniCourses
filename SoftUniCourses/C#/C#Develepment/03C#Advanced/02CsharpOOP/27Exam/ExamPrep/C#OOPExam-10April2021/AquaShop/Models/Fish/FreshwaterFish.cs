﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Fish
{
    public class FreshwaterFish : Fish
    {
        public FreshwaterFish(string name, string species, decimal price)
            : base(name, species, price)
        {

        }

        public override int Size => 3;

        public override void Eat()
        {
            this.Size += 3;
        }
    }
}
