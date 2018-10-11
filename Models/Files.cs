using System;
using System.Collections.Generic;

namespace coreArch.Models
{
    public partial class Files
    {
        public int Id { get; set; }
        public int ChildId { get; set; }
        public int FileSize { get; set; }
        public string Document { get; set; }
    }
}
