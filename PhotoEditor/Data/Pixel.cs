﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPhotoshop
{
    public struct Pixel
    {
        double r, g, b;
        public Pixel(double r, double g, double b)
        {
            this.r = this.g = this.b = 0;
            this.R = r;
            this.G = g;
            this.B = b;

        }
        private double Check(double value)
        {
            if (value < 0 || value > 1) throw new ArgumentException();
            return value;
        }

        public static double Trim(double value)
        {
            if (value < 0) value = 0;
            if (value > 1) value = 1;
            return value;
        }

        public double R
        {
            get { return r; }
            set { r = Check(value); }
        }

        public double G
        {
            get { return g; }
            set { g = Check(value); }
        }

        public double B
        {
            get { return b; }
            set { b = Check(value); }
        }
        
    }
}
