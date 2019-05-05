using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Miniboard.Data;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Miniboard.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IContextFactory _contextFactory;
        [BindProperty]
        public NewMessageViewModel NewMessageViewModel { get; set; } = new NewMessageViewModel();

        public RecentMessagesViewModel RecentMessagesViewModel { get; private set; }

        public IndexModel(IContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task OnGetAsync()
        {
            await GetMessagesAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await GetMessagesAsync();
                return Page();
            }

            using (var context = _contextFactory.CreateContext())
            {
                context.BoardMessages.Add(new BoardMessage
                {
                    Name = NewMessageViewModel.Name,
                    Timestamp = DateTime.UtcNow,
                    Message = NewMessageViewModel.Message
                });

                await context.SaveChangesAsync();
            }

            return RedirectToPage();
        }

        private async Task GetMessagesAsync()
        {
            using (var context = _contextFactory.CreateContext())
            {
                var messages = await context.BoardMessages
                    .OrderByDescending(x => x.Timestamp)
                    .Take(25)
                    .ToArrayAsync();

                RecentMessagesViewModel = new RecentMessagesViewModel(messages.Select(x => new MessageViewModel(
                    x.Name,
                    x.Timestamp,
                    x.Message)));
            }
        }
    }
}
