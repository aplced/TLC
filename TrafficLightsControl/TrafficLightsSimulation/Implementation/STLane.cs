using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TrafficLightsSimulation.Interface;
using TrafficLightsSimulation.Abstraction;

namespace TrafficLightsSimulation.Implementation
{
    class STLane : TrafficLane, ITrafficLane
    {
        STLaneProperties props;
        Boolean[] occupiedSpaces;

        List<ITrafficLight> inTrafficLights = new List<ITrafficLight>();
        List<ITrafficLight> outTrafficLights = new List<ITrafficLight>();

        public STLane(STLaneProperties iProps, IFlowSensor iFlowSensor)
            : base(iFlowSensor)
        {
            props = iProps;

            occupiedSpaces = new Boolean[props.CapacityMax];
            for (int i = 0; i < props.CapacityMax; i++ )
            {
                occupiedSpaces[i] = false;
            }
        }

        public void SetId(String iLId)
        {
            props.Id = iLId;
        }

        public String GetId()
        {
            return props.Id;
        }

        public void SetFlowSensor(IFlowSensor ifSensor)
        {
            flowSensor = ifSensor;
        }

        public IFlowSensor GetFlowSensor()
        {
            return flowSensor;
        }

        public int GetCapacityMax()
        {
            return props.CapacityMax;
        }

        public int GetInflow()
        {
            if (flowSensor != null)
                return flowSensor.GetInflow();
            else
                return -1;
        }

        public int GetOutflow()
        {
            if (flowSensor != null)
                return flowSensor.GetInflow();
            else
                return -1;
        }

        public void AddInTrafficLight(ITrafficLight tLight)
        {
            inTrafficLights.Add(tLight);
        }

        public List<ITrafficLight> GetInTrafficLight()
        {
            return inTrafficLights;
        }

        public void AddOutTrafficLight(ITrafficLight tLight)
        {
            outTrafficLights.Add(tLight);
        }

        public ITrafficLight GetOutTrafficLight(Directions dir)
        {
            foreach (ITrafficLight light in outTrafficLights)
            {
                if (light.GetDirections().HasFlag(dir))
                    return light;
            }
            return null;
        }


        public bool IsSpaceOccupied(int space)
        {
            return occupiedSpaces[space];
        }

        public void FreeSpace(int space)
        {
            occupiedSpaces[space] = false;
        }

        public void OccupySpace(int space)
        {
            occupiedSpaces[space] = true;
        }
    }
}
