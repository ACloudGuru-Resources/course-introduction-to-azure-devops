using System.Collections.Generic;

namespace Miniboard.Pages
{
    public class RecentMessagesViewModel
    {
        public IEnumerable<MessageViewModel> Messages { get; }

        public RecentMessagesViewModel(IEnumerable<MessageViewModel> messageViewModel)
        {
            Messages = messageViewModel;
        }
    }
}