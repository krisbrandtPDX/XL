using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace XL
{
    public class Dir
    {
        public Dir(string path = @"C:\Data")
        {
            Path = path;
            Timestamp = DateTime.Now;
        }
        public int Id { get; set; }
        public string Path { get; set; }
        public DateTime Timestamp { get; set; }
      }
}

