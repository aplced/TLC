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
                distanceToLights--;
            }
            else
            {
                ITrafficLight light = crntLane.GetOutTrafficLight(heading);
                if (light != null)
                {
                    if (light.GetTrafficLightState() == TrafficLightState.Green)
                    {
                        crntLane = light.GetTrafficLane(heading);
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
                else
                {
                    throw new Exception("Course unreachable!");
                }
            }
        }

        public void SetStartLane(ITrafficLane lane)
        {
            crntLane = lane;
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
