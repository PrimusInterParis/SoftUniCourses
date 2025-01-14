﻿using System;
using System.Collections.Generic;
using System.Text;
using EasterRaces.Models.Cars.Contracts;

namespace EasterRaces.Models.Cars
{
    public abstract class Car : ICar
    {
        private string model;
        private int horsePower;
        private double cubicCentimeters;
        private int minHorsePower;
        private int maxHorsePower;

        protected Car(
            string model,
            int horsePower,
            double cubicCentimeters,
            int minHorsePower,
            int maxHorsePower)

        {
            this.minHorsePower = minHorsePower;
            this.maxHorsePower = maxHorsePower;
            this.Model = model;
            this.HorsePower = horsePower;
            this.CubicCentimeters = cubicCentimeters;

        }

        public string Model
        {
            get
            {
                return this.model;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 4)
                {
                    throw new ArgumentException(string.Format(Utilities.Messages.ExceptionMessages.InvalidModel, value, 4));
                }

                this.model = value;
            }
        }

        public int HorsePower
        {
            get
            {
                return this.horsePower;
            }
            private set
            {
                if (value < this.minHorsePower || value > this.maxHorsePower)
                {
                    throw new ArgumentException(string.Format(Utilities.Messages.ExceptionMessages.InvalidHorsePower, value));
                }

                this.horsePower = value;

            }
        }

        public double CubicCentimeters
        {
            get => this.cubicCentimeters;
            private set => this.cubicCentimeters = value;

        }




        public double CalculateRacePoints(int laps)
        {
            return this.CubicCentimeters / HorsePower * laps;
        }

        public override bool Equals(object? obj)
        {
            var other = (ICar)obj;

            return this.Model == other.Model;
        }
    }
}
