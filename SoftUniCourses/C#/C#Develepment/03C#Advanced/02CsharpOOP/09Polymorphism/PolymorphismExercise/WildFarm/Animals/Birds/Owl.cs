﻿using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm.Animals.Birds
{
    public class Owl : Bird
    {
        private const double FOOD_MODIFIER = 0.25;

        private static HashSet<string> AllowedFoods = new HashSet<string>()
        {
            nameof(Meat)
        };


        public Owl(
            string name,
            double weight,
            double wingSize)
            : base(name, weight, AllowedFoods, FOOD_MODIFIER, wingSize)
        {
        }

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
    }
}

