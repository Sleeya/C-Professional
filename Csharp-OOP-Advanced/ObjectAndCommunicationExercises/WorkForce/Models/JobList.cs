using System;
using System.Collections;
using System.Collections.Generic;

namespace WorkForce.Models
{
    public class JobList:IEnumerable<Job>
    {
        private List<Job> jobs;

        public JobList()
        {
            this.jobs = new List<Job>();
        }

        public void Add(Job job)
        {
            this.jobs.Add(job);
        }

        public IEnumerator<Job> GetEnumerator()
        {
            for (int i = 0; i < this.jobs.Count; i++)
            {
                yield return this.jobs[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void OnJobeDone(object sender, JobDoneEventArgs args)
        {
            Console.WriteLine($"Job {args.Job.Name} done!");
            this.jobs.Remove(args.Job);
        }
    }
}
