using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoExplorer.Shared.Model
{
    public class Photo
    {
        public string Id { get; set; } = string.Empty;
        public string Path { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
