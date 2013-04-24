using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TrafficLightsSimulation.Interface;

namespace TrafficLightsSimulation.Implementation
{
    public class STLightProperties
    {
        public TrafficLightState State;

        public Directions GovernedDir;

        public Int32 GreenMin;
        public Int32 GreenMax;
        
        public Int32 RedMin;
        public Int32 RedMax;
    }
}
