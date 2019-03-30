namespace FestivalManager.Entities
{
	using System;
	using Contracts;

	public class Song : ISong
    {
        private string name;
        private TimeSpan duration;

		public Song(string name, TimeSpan duration)
		{
			this.Name = name;
			this.Duration = duration;
		}

		public string Name
        {
            get => this.name;
            private set => this.name = value;
        }

        public TimeSpan Duration
        {
            get => this.duration;
            private set => this.duration = value;
        }

        public override string ToString()
	    {
		    return $"{this.Name} ({this.Duration:mm\\:ss})";
	    }
    }
}
