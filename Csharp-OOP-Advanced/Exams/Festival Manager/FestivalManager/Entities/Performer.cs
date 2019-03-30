namespace FestivalManager.Entities
{
	using System.Collections.Generic;
	using Contracts;
	using Instruments;

	public class Performer :IPerformer
	{
		private readonly List<IInstrument> instruments;
        private string name;
        private int age;

        public Performer(string name, int age)
		{
			this.Name = name;
			this.Age = age;

			this.instruments = new List<IInstrument>();
		}

		public string Name
        {
            get => this.name;
            private set => this.name = value;
        }

		public int Age
        {
            get => this.age;
            private set => this.age = value;
        }

        public IReadOnlyCollection<IInstrument> Instruments => this.instruments;

		public void AddInstrument(IInstrument instrument)
		{
			this.instruments.Add(instrument);
		}

		public override string ToString()
		{
			return this.Name;
		}
	}
}
