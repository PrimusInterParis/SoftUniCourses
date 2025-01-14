﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
   public class Seat : ICar
    {
        private string model;
        private string color;
        private int battery;

        public Seat(string model, string color)
        {
            this.Model = model;
            this.Color = color;
        }

        public string Model
        {
            get => this.model;
            private set => this.model = value;
        }

        public string Color
        {
            get => this.color;
            private set => this.color = value;
        }

        public string Start()
        {
            return "Engine start";
        }

        public string Stop()
        {
            return "Breaaak!";
        }


     

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.Color} {nameof(Seat)} {this.Model}");
            sb.AppendLine($"{this.Start()}");
            sb.AppendLine($"{this.Stop()}");

            return sb.ToString().TrimEnd();
        }
    }
}
