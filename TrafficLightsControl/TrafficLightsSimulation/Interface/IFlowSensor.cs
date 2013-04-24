using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrafficLightsSimulation.Interface
{
    public interface IFlowSensor
    {
        void NotifyInflow();
        void NotifyOutflow();

        Int32 GetInflow();
        Int32 GetOutflow();
    }
}
