﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrafficLightsSimulation.Interface
{
    public interface IVehicle
    {
        void SetStartLane(ITrafficLane lane);

        Directions GetHeading();
        void SetCourse(List<Directions> course);
    }
}
