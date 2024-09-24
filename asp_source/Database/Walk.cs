using System;
using System.Collections.Generic;

namespace tapluyen.api.Database
{
    public partial class Walk
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public double LengthInKm { get; set; }
        public Guid DifficultyId { get; set; }
        public Guid RegionId { get; set; }

        public virtual Difficulty Difficulty { get; set; } = null!;
        public virtual Region Region { get; set; } = null!;
    }
}
