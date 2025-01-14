﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _01
{
    public class Rectangle : IDrawable
    {

        private int width;
        private int height;

        public Rectangle(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }

        public int Width
        {
            get => this.width;
            set => this.width = value;
        }

        public int Height
        {
            get => this.height;
            set => this.height = value;
        }

        public void Draw()
        {
            DrawLine(this.width, '*', '*');
            for (int i = 1; i < this.height - 1; ++i)
            {
                DrawLine(this.width, '*', ' ');
            }
            DrawLine(this.width, '*', '*');

        }

        private void DrawLine(int width, char end, char mid)
        {
            Console.Write(end);
            for (int i = 0; i < width - 1; ++i)
            {
                Console.Write(mid);
            }

            Console.WriteLine(end);
        }
    }
}
