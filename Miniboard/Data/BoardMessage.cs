using System;

namespace Miniboard.Data
{
    public class BoardMessage
    {
        public int Id { get; set; }
        public string Name{ get; set; }
        public DateTime Timestamp { get; set; }
        public string Message { get; set; }
    }
}