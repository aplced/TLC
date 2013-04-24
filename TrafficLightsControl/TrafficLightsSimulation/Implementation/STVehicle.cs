using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TrafficLightsSimulation.Interface;

namespace TrafficLightsSimulation.Implementation
{
    public class STVehicle: IVehicle
    {
        Directions heading;
        int crntCourse;
        List<Directions> course;

        Int32 distanceToLights;
        ITrafficLane crntLane;

        public STVehicle(ITicker ticker)
        {
            heading = Directions.Ahead;
            ticker.OnTick += new Tick(ticker_OnTick);
        }

        void ticker_OnTick()
        {
            if (distanceToLights > 0)
            {
                if (!crntLane.IsSpaceOccupied(distanceToLights - 1))
                {
                    crntLane.FreeSpace(distanceToLights--);
                    crntLane.OccupySpace(distanceToLights);
                }
            }
            else
            {
                ITrafficLight light = crntLane.GetOutTrafficLight(heading);
                if (light != null)
                {
                    if (light.GetTrafficLightState() == TrafficLightState.Green)
                    {
                        var nextLane = light.GetTrafficLane(heading);

                        if (nextLane.IsSpaceOccupied(nextLane.GetCapacityMax()))
                        {
                            crntLane.FreeSpace(distanceToLights);
                            nextLane.OccupySpace(nextLane.GetCapacityMax());
                            
                            crntLane = nextLane;
                            distanceToLights = crntLane.GetCapacityMax();

                            crntCourse++;
                            if (crntCourse < course.Count)
                            {
                                heading = course[crntCourse];
                            }
                            else
                            {
                                //Destination reached...
                            }
                        }
                    }
                }
                else
                {
                    throw new Exception("Course unreachable!");
                }
            }
        }

        public void SetStartLane(ITrafficLane lane)
        {
            if (!lane.IsSpaceOccupied(lane.GetCapacityMax()))
            {
                lane.OccupySpace(lane.GetCapacityMax());
                crntLane = lane;
            }
        }

        public ITrafficLane GetCurrentLane()
        {
            return crntLane;
        }

        public Directions GetHeading()
        {
            return heading;
        }

        public void SetCourse(List<Directions> iCourse)
        {
            crntCourse = 0;
            course = iCourse;
            heading = course[crntCourse];
        }
    }
}
