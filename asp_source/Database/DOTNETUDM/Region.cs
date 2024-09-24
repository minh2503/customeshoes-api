using System;
using System.Collections.Generic;

namespace tapluyen.api.Database.DOTNETUDM
{
    public partial class Region
    {
        public Region()
        {
            Walks = new HashSet<Walk>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string? RegionImageUrl { get; set; }

        public virtual ICollection<Walk> Walks { get; set; }
    }
}
