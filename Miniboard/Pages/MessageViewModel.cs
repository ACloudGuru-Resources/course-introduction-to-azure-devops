using System;

namespace Miniboard.Pages
{
    public class MessageViewModel
    {
        public string Name { get; }
        public DateTime Timestamp { get; }
        public string Message { get; }

        public MessageViewModel(string name, DateTime timestamp, string message)
        {
            Name = name;
            Timestamp = timestamp;
            Message = message;
        }
    }
}