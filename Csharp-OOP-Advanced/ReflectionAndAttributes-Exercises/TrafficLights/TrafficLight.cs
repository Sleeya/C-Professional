using System;
using System.Collections.Generic;
using System.Text;

namespace TrafficLights
{
    public class TrafficLight
    {
        private List<string> lights;

        public TrafficLight(params string[] lights)
        {
            this.Lights = new List<string>(lights);
        }

        public List<string> Lights
        {
            get => this.lights;
            private set => this.lights = value;
        }

        public string Shift()
        {
            for (int i = 0; i < this.Lights.Count; i++)
            {
                if (this.Lights[i] == "Red")
                {
                    this.Lights[i] = "Green";
                }
                else if (this.Lights[i] == "Green")
                {
                    this.Lights[i] = "Yellow";
                }
                else if (this.Lights[i] == "Yellow")
                {
                    this.Lights[i] = "Red";
                }
            }
            return $"{string.Join(" ",this.Lights)}";
        }
    }
}
