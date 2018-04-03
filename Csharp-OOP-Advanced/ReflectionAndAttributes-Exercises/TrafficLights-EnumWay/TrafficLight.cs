using System;
using System.Collections.Generic;
using System.Text;
using TrafficLights_EnumWay;

namespace TrafficLights
{
    public class TrafficLight
    {
        private List<LightsEnum> lights;

        public TrafficLight(ICollection<LightsEnum> lights)
        {
            this.Lights = new List<LightsEnum>(lights);
        }

        public List<LightsEnum> Lights
        {
            get => this.lights;
            private set => this.lights = value;
        }

        public string Shift()
        {
            for (int i = 0; i < this.Lights.Count; i++)
            {
                this.Lights[i]++;
                this.Lights[i] = (int)this.Lights[i] > 2 ? 0 : this.Lights[i];
            }
            return $"{string.Join(" ", this.Lights)}";
        }
    }
}
