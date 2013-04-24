using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TrafficLightsSimulation.Interface;

namespace TrafficLightsSimulation.Abstraction
{
    public abstract class TrafficLightControl
    {
        ITrafficLight trafficLight;

        public TrafficLightControl(ITrafficLight tLight)
        {
            trafficLight = tLight;
        }
    }
}
