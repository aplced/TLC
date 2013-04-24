using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TrafficLightsSimulation.Interface;

namespace TrafficLightsSimulation.Implementation
{
    class STLight: ITrafficLight
    {
        STLightProperties props;
        Dictionary<Directions, ITrafficLane> governedLanes = new Dictionary<Directions, ITrafficLane>();

        public STLight(STLightProperties iProps)
        {
            props = iProps;
        }

        public void AddTrafficLane(Directions dir, ITrafficLane lane)
        {
            ITrafficLane laneExistsCheck;
            if (!(governedLanes.TryGetValue(dir, out laneExistsCheck) && laneExistsCheck != null))
            {
                governedLanes.Add(dir, lane);
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public Directions GetDirections()
        {
            return props.GovernedDir;
        }

        public ITrafficLane GetTrafficLane(Directions dir)
        {
            return governedLanes[dir];
        }

        public int GetGreenMin()
        {
            return props.GreenMin;
        }

        public int GetGreenMax()
        {
            return props.GreenMax;
        }

        public int GetRedMin()
        {
            return props.RedMin;
        }

        public int GetRedMax()
        {
            return props.RedMax;
        }

        public TrafficLightState GetTrafficLightState()
        {
            return props.State;
        }

        public void SetTrafficLightState(TrafficLightState state)
        {
            props.State = state;
        }
    }
}
