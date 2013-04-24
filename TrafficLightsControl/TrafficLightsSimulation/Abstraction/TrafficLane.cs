using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TrafficLightsSimulation.Interface;

namespace TrafficLightsSimulation.Abstraction
{
    public abstract class TrafficLane
    {
        protected IFlowSensor flowSensor;

        public TrafficLane(IFlowSensor iFlowSensor)
        {
            flowSensor = iFlowSensor;
        }
    }
}
