﻿using System;

namespace SharedLibrary
{
    public class TemperatureModel //  måste public för access från andra project
    {
        public double Temperature { get; set; }
        public double Humidity { get; set; } //влажность
    }
}
