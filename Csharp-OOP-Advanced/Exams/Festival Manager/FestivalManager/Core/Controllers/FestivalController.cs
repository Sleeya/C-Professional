namespace FestivalManager.Core.Controllers
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Contracts;
	using Entities.Contracts;
    using FestivalManager.Entities.Factories;
    using FestivalManager.Entities.Factories.Contracts;

    public class FestivalController : IFestivalController
	{
		private const string TimeFormat = "mm\\:ss";
		private const string TimeFormatLong = "{0:D2}:{1:D2}";
        private const string PrintTimeFormat = "mm:ss";
		
		private readonly IStage stage;
        private readonly IInstrumentFactory instrumentFactory;
        private readonly IPerformerFactory performerFactory;
        private readonly ISetFactory setFactory;
        private readonly ISongFactory songFactory;

		public FestivalController(IStage stage)
		{
			this.stage = stage;

            this.instrumentFactory = new InstrumentFactory();
            this.performerFactory = new PerformerFactory();
            this.setFactory = new SetFactory();
            this.songFactory = new SongFactory();
		}

		public string ProduceReport()
		{
            var builder = new StringBuilder();

			var totalFestivalLength = new TimeSpan(this.stage.Sets.Sum(s => s.ActualDuration.Ticks));

            builder.AppendLine($"Festival length: {(int)totalFestivalLength.TotalMinutes:D2}:{totalFestivalLength.Seconds:D2}");

			foreach (var set in this.stage.Sets)
			{
                builder.AppendLine($"--{set.Name} ({(int)set.ActualDuration.TotalMinutes:D2}:{set.ActualDuration.Seconds:D2}):");

				var performersOrderedDescendingByAge = set.Performers.OrderByDescending(p => p.Age);
				foreach (var performer in performersOrderedDescendingByAge)
				{
					var instruments = string.Join(", ", performer.Instruments
						.OrderByDescending(i => i.Wear));

                    builder.AppendLine($"---{performer.Name} ({instruments})");
				}

				if (!set.Songs.Any())
                    builder.AppendLine("--No songs played");
				else
				{
                    builder.AppendLine("--Songs played:");
					foreach (var song in set.Songs)
					{
                        builder.AppendLine($"----{song.Name} ({song.Duration.ToString(TimeFormat)})") ;
					}
				}
			}

			return builder.ToString().TrimEnd();
		}

        // {name} {type}
        public string RegisterSet(string[] args)
		{
            string setName = args[0];
            string setType = args[1];

            ISet set = this.setFactory.CreateSet(setName, setType);

            this.stage.AddSet(set);

            return $"Registered {setType} set";

        }

        // {name} {age} {instrument1} {instrument2} {instrumentN}
        public string SignUpPerformer(string[] args)
		{
			var name = args[0];
			var age = int.Parse(args[1]);

            var performer = this.performerFactory.CreatePerformer(name, age);

            var instrumentsParams = args.Skip(2).ToArray();

			var instruments = instrumentsParams
                .Select(i => this.instrumentFactory.CreateInstrument(i))
				.ToArray();

			foreach (var instrument in instruments)
			{
				performer.AddInstrument(instrument);
			}

			this.stage.AddPerformer(performer);

			return $"Registered performer {performer.Name}";
		}

        // {name} {mm:ss}
        public string RegisterSong(string[] args)
		{
            string name = args[0];
            TimeSpan duration = TimeSpan.ParseExact(args[1], TimeFormat, CultureInfo.InvariantCulture);

            ISong song = this.songFactory.CreateSong(name, duration);

            this.stage.AddSong(song);

			return $"Registered song {name} ({duration:mm\\:ss})";
		}

        //{songName} {setName}
        public string AddSongToSet(string[] args)
		{
			var songName = args[0];
			var setName = args[1];

			if (!this.stage.HasSet(setName))
			{
				throw new InvalidOperationException("Invalid set provided");
			}

			if (!this.stage.HasSong(songName))
			{
				throw new InvalidOperationException("Invalid song provided");
			}

			var set = this.stage.GetSet(setName);
			var song = this.stage.GetSong(songName);

			set.AddSong(song);

			return $"Added {song.Name} ({song.Duration:mm\\:ss}) to {set.Name}";
		}

        // {performerName} {setName}
        public string AddPerformerToSet(string[] args)
		{
            var performerName = args[0];
            var setName = args[1];

            if (!this.stage.HasPerformer(performerName))
            {
                throw new InvalidOperationException("Invalid performer provided");
            }

            if (!this.stage.HasSet(setName))
            {
                throw new InvalidOperationException("Invalid set provided");
            }

            IPerformer performer = this.stage.GetPerformer(performerName);
            ISet set = this.stage.GetSet(setName);

            set.AddPerformer(performer);

            return $"Added {performer.Name} to {set.Name}";
        }

		public string RepairInstruments(string[] args)
		{
			var instrumentsToRepair = this.stage.Performers
				.SelectMany(p => p.Instruments)
				.Where(i => i.Wear < 100)
				.ToArray();

			foreach (var instrument in instrumentsToRepair)
			{
				instrument.Repair();
			}

			return $"Repaired {instrumentsToRepair.Length} instruments";
		}
    }
}