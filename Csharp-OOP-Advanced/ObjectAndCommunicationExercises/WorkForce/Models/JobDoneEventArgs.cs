
using System;

namespace WorkForce.Models
{
    public class JobDoneEventArgs:EventArgs
    {
        public JobDoneEventArgs(Job job)
        {
            this.Job = job;
        }

        public Job Job { get; set; }
    }
}
