using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrafficLightsSimulation.Interface
{
    public interface ITrafficLane
    {
        Int32 GetCapacityMax();
        Int32 GetInflow();
        Int32 GetOutflow();

        void SetId(String iLId);
        String GetId();

        void SetFlowSensor(IFlowSensor ifSensor);
        IFlowSensor GetFlowSensor();

        void AddInTrafficLight(ITrafficLight tLight);
        List<ITrafficLight> GetInTrafficLight();

        void AddOutTrafficLight(ITrafficLight tLight);
        ITrafficLight GetOutTrafficLight(Directions dir);

        bool IsSpaceOccupied(Int32 space);
        void FreeSpace(Int32 space);
        void OccupySpace(Int32 space);
    }
}
