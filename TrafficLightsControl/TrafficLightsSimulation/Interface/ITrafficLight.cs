using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrafficLightsSimulation.Interface
{
    public enum TrafficLightState
    {
        Green,
        Yellow,
        Red
    }

    public enum Directions
    {
        Left = 1,
        Right = 2,
        Ahead = 4
    }

    public interface ITrafficLight
    {
        Directions GetDirections();
        ITrafficLane GetTrafficLane(Directions dir);

        Int32 GetGreenMin();
        Int32 GetGreenMax();
        
        Int32 GetRedMin();
        Int32 GetRedMax();

        TrafficLightState GetTrafficLightState();
        void SetTrafficLightState(TrafficLightState state);
    }
}
