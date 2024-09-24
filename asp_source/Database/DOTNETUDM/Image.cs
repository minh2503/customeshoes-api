using System;
using System.Collections.Generic;

namespace tapluyen.api.Database.DOTNETUDM
{
    public partial class Image
    {
        public Guid Id { get; set; }
        public string FileName { get; set; } = null!;
        public string? FileDescription { get; set; }
        public string FileExtention { get; set; } = null!;
        public string? FileSizeInBytes { get; set; }
        public string FilePath { get; set; } = null!;
    }
}
