using System.Collections.Generic;

namespace XL
{
    public class Row
    {
        public Row()
        {
            Data = new Dictionary<string, string>();
        }
        public int Id { get; set; } 
        public int SheetId { get; set; } 
        public Dictionary<string, string> Data { get; set; }
    }
}
