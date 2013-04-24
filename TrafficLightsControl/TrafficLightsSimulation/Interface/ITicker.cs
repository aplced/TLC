using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrafficLightsSimulation.Interface
{
    public delegate void Tick();

    public interface ITicker
    {
        event Tick OnTick;
    }
}
