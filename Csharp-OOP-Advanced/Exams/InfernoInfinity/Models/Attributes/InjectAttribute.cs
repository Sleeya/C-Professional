using System;
using System.Collections.Generic;
using System.Text;

namespace InfernoInfinity.Models.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    class InjectAttribute : Attribute
    {
        public InjectAttribute(string author, int revision, string description, params string[] reviewers)
        {
            this.Author = author;
            this.Revision = revision;
            this.Description = description;
            this.Reviewers = reviewers;
        }

        public string Author { get; }
        public int Revision { get; }
        public string Description { get; }
        public string[] Reviewers { get; }
    }
}
