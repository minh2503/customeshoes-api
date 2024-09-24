using System;
using System.Collections.Generic;

namespace tapluyen.api.Database
{
    public partial class Difficulty
    {
        public Difficulty()
        {
            Walks = new HashSet<Walk>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Walk> Walks { get; set; }
    }
}
